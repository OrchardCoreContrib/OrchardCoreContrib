using OrchardCore.Email;
using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Email;

public interface IEmailService
{
    Task<Result> SendAsync(MailMessage message);
}
