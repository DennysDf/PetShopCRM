using PetShopCRM.Application.DTOs;
using PetShopCRM.Web.Models.Endereco;

namespace PetShopCRM.Web.Services.Interfaces;

public interface IAddressService
{
    Task<ResponseDTO<AddressModel>> GetByCEP(string CEP);
}
