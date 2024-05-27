using PetShopCRM.Application.DTOs;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IEmailService
{
    Task<ResponseDTO<bool>> SendAsync(string receiverEmail, string subject, string body, bool useHtml = false);
}
