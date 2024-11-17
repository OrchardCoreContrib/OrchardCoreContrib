﻿using MailKit.Net.Proxy;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using OrchardCore.Email;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace OrchardCoreContrib.Email.Services;

/// <summary>
/// Represents a SMTP service that allows to send emails.
/// </summary>
/// <remarks>
/// Initializes a new instance of a <see cref="SmtpService"/>.
/// </remarks>
/// <param name="options">The <see cref="IOptions{SmtpSettings}"/>.</param>
/// <param name="logger">The <see cref="ILogger{SmtpService}"/>.</param>
/// <param name="stringLocalizer">The <see cref="IStringLocalizer{SmtpService}"/>.</param>
public class SmtpService(
    IOptions<SmtpSettings> options,
    ILogger<SmtpService> logger,
    IStringLocalizer<SmtpService> stringLocalizer) : ISmtpService
{
    private const string EmailExtension = ".eml";

    private static readonly char[] EmailsSeparator = [',', ';'];

    private readonly SmtpSettings _options = options.Value;
    private readonly ILogger _logger = logger;
    private readonly IStringLocalizer S = stringLocalizer;

    /// <summary>
    /// Sends the specified message to an SMTP server for delivery.
    /// </summary>
    /// <param name="message">The message to be sent.</param>
    /// <returns>A <see cref="SmtpResult"/> that holds information about the sent message, for instance if it has sent successfully or if it has failed.</returns>
    /// <remarks>This method allows to send an email without setting <see cref="MailMessage.To"/> if <see cref="MailMessage.Cc"/> or <see cref="MailMessage.Bcc"/> is provided.</remarks>
    public async Task<SmtpResult> SendAsync(MailMessage message)
    {
        if (_options == null)
        {
            return SmtpResult.Failed(S["SMTP settings must be configured before an email can be sent."]);
        }

        SmtpResult result;
        try
        {
            var senderAddress = String.IsNullOrWhiteSpace(message.From)
                ? _options.DefaultSender
                : message.From;

            if (!String.IsNullOrWhiteSpace(senderAddress))
            {
                message.From = senderAddress;
            }

            var mimeMessage = FromMailMessage(message);

            if (mimeMessage.From.Count == 0 && mimeMessage.Cc.Count == 0 && mimeMessage.Bcc.Count == 0)
            {
                return SmtpResult.Failed(S["The mail message should have at least one of these headers: To, Cc or Bcc."]);
            }

            switch (_options.DeliveryMethod)
            {
                case SmtpDeliveryMethod.Network:
                    await SendOnlineMessageAsync(mimeMessage);
                    break;
                case SmtpDeliveryMethod.SpecifiedPickupDirectory:
                    await SendOfflineMessageAsync(mimeMessage, _options.PickupDirectoryLocation);
                    break;
                default:
                    throw new NotSupportedException($"The '{_options.DeliveryMethod}' delivery method is not supported.");
            }

            result = SmtpResult.Success;
        }
        catch (Exception ex)
        {
            result = SmtpResult.Failed(S["An error occurred while sending an email: '{0}'", ex.Message]);
        }

        return result;
    }

    private MimeMessage FromMailMessage(MailMessage message)
    {
        var submitterAddress = String.IsNullOrWhiteSpace(message.Sender)
            ? _options.DefaultSender
            : message.Sender;

        var mimeMessage = new MimeMessage();

        if (!String.IsNullOrEmpty(submitterAddress))
        {
            mimeMessage.Sender = MailboxAddress.Parse(submitterAddress);
        }

        if (!string.IsNullOrWhiteSpace(message.From))
        {
            foreach (var address in message.From.Split(EmailsSeparator, StringSplitOptions.RemoveEmptyEntries))
            {
                mimeMessage.From.Add(MailboxAddress.Parse(address));
            }
        }

        if (!string.IsNullOrWhiteSpace(message.To))
        {
            foreach (var address in message.To.Split(EmailsSeparator, StringSplitOptions.RemoveEmptyEntries))
            {
                mimeMessage.To.Add(MailboxAddress.Parse(address));
            }
        }

        if (!string.IsNullOrWhiteSpace(message.Cc))
        {
            foreach (var address in message.Cc.Split(EmailsSeparator, StringSplitOptions.RemoveEmptyEntries))
            {
                mimeMessage.Cc.Add(MailboxAddress.Parse(address));
            }
        }

        if (!string.IsNullOrWhiteSpace(message.Bcc))
        {
            foreach (var address in message.Bcc.Split(EmailsSeparator, StringSplitOptions.RemoveEmptyEntries))
            {
                mimeMessage.Bcc.Add(MailboxAddress.Parse(address));
            }
        }

        if (string.IsNullOrWhiteSpace(message.ReplyTo))
        {
            foreach (var address in mimeMessage.From)
            {
                mimeMessage.ReplyTo.Add(address);
            }
        }
        else
        {
            foreach (var address in message.ReplyTo.Split(EmailsSeparator, StringSplitOptions.RemoveEmptyEntries))
            {
                mimeMessage.ReplyTo.Add(MailboxAddress.Parse(address));
            }
        }

        mimeMessage.Subject = message.Subject;

        var body = new BodyBuilder();

        if (message.IsHtmlBody)
        {
            body.HtmlBody = message.Body;
        }
        else
        {
            body.TextBody = message.Body;
        }

        foreach (var attachment in message.Attachments)
        {
            if (attachment.Stream != null)
            {
                body.Attachments.Add(attachment.Filename, attachment.Stream);
            }
        }

        mimeMessage.Body = body.ToMessageBody();

        return mimeMessage;
    }

    protected virtual async Task SendOnlineMessageAsync(MimeMessage message)
    {
        var secureSocketOptions = _options.AutoSelectEncryption
            ? SecureSocketOptions.Auto
            : _options.EncryptionMethod switch
            {
                SmtpEncryptionMethod.None => SecureSocketOptions.None,
                SmtpEncryptionMethod.SslTls => SecureSocketOptions.SslOnConnect,
                SmtpEncryptionMethod.StartTls => SecureSocketOptions.StartTls,
                _ => SecureSocketOptions.Auto
            };

        using var client = new SmtpClient();
        if (_options.Proxy != null)
        {
            client.ProxyClient = new Socks5Client(_options.Proxy.Host, _options.Proxy.Port);
        }

        client.ServerCertificateValidationCallback = CertificateValidationCallback;

        await client.ConnectAsync(_options.Host, _options.Port, secureSocketOptions);

        if (_options.RequireCredentials)
        {
            if (_options.UseDefaultCredentials)
            {
                _options.UserName = _options.Password = String.Empty;
            }

            await client.AuthenticateAsync(_options.UserName, _options.Password);
        }

        await client.SendAsync(message);

        await client.DisconnectAsync(true);
    }

    protected virtual async Task SendOfflineMessageAsync(MimeMessage message, string pickupDirectory)
    {
        var mailPath = Path.Combine(pickupDirectory, Guid.NewGuid().ToString() + EmailExtension);

        await message.WriteToAsync(mailPath, CancellationToken.None);
    }

    protected bool CertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
            return true;

        _logger.LogError(string.Concat("SMTP Server's certificate {CertificateSubject} issued by {CertificateIssuer} ",
            "with thumbprint {CertificateThumbprint} and expiration date {CertificateExpirationDate} ",
            "is considered invalid with {SslPolicyErrors} policy errors"),
            certificate.Subject, certificate.Issuer, certificate.GetCertHashString(),
            certificate.GetExpirationDateString(), sslPolicyErrors);

        if (sslPolicyErrors.HasFlag(SslPolicyErrors.RemoteCertificateChainErrors) && chain?.ChainStatus != null)
        {
            foreach (var chainStatus in chain.ChainStatus)
            {
                _logger.LogError("Status: {Status} - {StatusInformation}", chainStatus.Status, chainStatus.StatusInformation);
            }
        }

        return false;
    }

}
