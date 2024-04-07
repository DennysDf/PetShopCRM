using PetShopCRM.Web.DTOs;
using PetShopCRM.Web.Models.Endereco;
using PetShopCRM.Web.Services.Interfaces;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PetShopCRM.Web.Services;

public class AddressService : IAddressService
{
    public async Task<ResponseDTO<AddressModel>> GetByCEP(string CEP)
    {
        var request = new HttpRequestMessage(HttpMethod.Get,$"https://brasilapi.com.br/api/cep/v1/{CEP}");
        using (var client = new HttpClient())
        {
            var responseBrasilApi = await client.SendAsync(request);
            var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
            var objResponse = JsonSerializer.Deserialize<AddressModel>(contentResp);

            if (responseBrasilApi.IsSuccessStatusCode)
                return new ResponseDTO<AddressModel>(true,"certo", objResponse);
            else
                return new ResponseDTO<AddressModel>(false, "Errado", objResponse);
        }
    }
}
