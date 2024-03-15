namespace PetShopCRM.Web.Services.Interfaces;

public interface ILoggedUserService
{
    int Id {  get; }
    string Name { get; }
    string Role {  get; }
    string Image {  get; }
}
