using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Infrastructure.Settings;
using PetShopCRM.Web.Services.Interfaces;

namespace PetShopCRM.Web.Services;

public class EmailService(IOptions<AppSettings> appSettings, IConfigurationService configurationService) : IEmailService
{
    public async Task<ResponseDTO<bool>> SendAsync(string receiverEmail, string subject, string body, bool useHtml = false)
    {
        try
        {
            using var smtpClient = new SmtpClient();

            await ConectSmtpClientAsync(smtpClient);

            var result = await AuthenticateSmtpClientAsync(smtpClient);

            if (!result.Success)
                return new ResponseDTO<bool>(false, result.Message, false);

            var configSenderEmail = configurationService.GetByKey(ConfigurationKey.SmtpSenderEmail);

            if (string.IsNullOrEmpty(configSenderEmail?.Value))
                return new ResponseDTO<bool>(false, Resources.Text.EmailSenderNotFound, false);

            var configSystemName = configurationService.GetByKey(ConfigurationKey.SystemName);

            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress(configSystemName?.Value ?? configSenderEmail?.Value, configSenderEmail?.Value));
            mailMessage.To.Add(new MailboxAddress(receiverEmail, receiverEmail));
            mailMessage.Subject = subject;
            mailMessage.Body = new TextPart(useHtml ? "html" : "plain")
            {
                Text = body
            };

            await smtpClient.SendAsync(mailMessage);
            await smtpClient.DisconnectAsync(true);

            return new ResponseDTO<bool>(true, Resources.Text.EmailSuccess, true);
        }
        catch (Exception ex)
        {
            return new ResponseDTO<bool>(false, ex.Message, false);
        }
    }

    private async Task ConectSmtpClientAsync(SmtpClient smtpClient)
    {
        await smtpClient.ConnectAsync(appSettings.Value.Smtp.Host, appSettings.Value.Smtp.Port, MailKit.Security.SecureSocketOptions.StartTls);
    }

    private async Task<ResponseDTO<bool>> AuthenticateSmtpClientAsync(SmtpClient smtpClient)
    {
        var configEmailUser = configurationService.GetByKey(ConfigurationKey.SmtpUser);
        var configEmailPassword = configurationService.GetByKey(ConfigurationKey.SmtpPassword);

        var validateResult = ValidateSmtpCredentials(configEmailUser?.Value, configEmailPassword?.Value);

        if (!validateResult.Success)
            return new ResponseDTO<bool>(false, validateResult.Message, false);

        await smtpClient.AuthenticateAsync(configEmailUser?.Value, configEmailPassword?.Value);
        
        return new ResponseDTO<bool>(true, string.Empty, true);
    }

    private (bool Success, string Message) ValidateSmtpCredentials(string? user, string? password)
    {
        if (string.IsNullOrEmpty(user) && string.IsNullOrEmpty(password))
        {
            return (false, Resources.Text.EmailUserAndPasswordNotFound);
        }

        if (string.IsNullOrEmpty(user))
        {
            return (false, Resources.Text.EmailUserNotFound);
        }

        if (string.IsNullOrEmpty(password))
        {
            return (false, Resources.Text.EmailPasswordNotFound);
        }

        return (true, string.Empty);
    }
}
