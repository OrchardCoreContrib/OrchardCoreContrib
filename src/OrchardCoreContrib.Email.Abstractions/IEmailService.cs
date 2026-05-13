using OrchardCore.Email;
using OrchardCore.Infrastructure;

namespace OrchardCoreContrib.Email;

public interface IEmailService
{
    Task<Result> SendAsync(MailMessage message);
}
