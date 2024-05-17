using PetShopCRM.Application.DTOs;

namespace PetShopCRM.Web.Services.Interfaces;

public interface IEmailService
{
    Task<ResponseDTO<bool>> SendAsync(string receiverEmail, string subject, string body, bool useHtml = false);
}
