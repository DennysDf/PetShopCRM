namespace PetShopCRM.Application.DTOs.User;

public record ProfileDTO(int Id, string Name, string Password, string PasswordNew, string ConfirmPassword, string Email, string Phone, byte[] UrlPhoto);

