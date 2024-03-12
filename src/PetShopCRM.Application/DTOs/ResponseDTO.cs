namespace PetShopCRM.Application.DTOs;

public record ResponseDTO<T>(bool Success, string Message, T Data);
