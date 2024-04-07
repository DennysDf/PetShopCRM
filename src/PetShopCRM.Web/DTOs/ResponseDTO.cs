namespace PetShopCRM.Web.DTOs;

public record ResponseDTO<T>(bool Success, string Message, T? Data);