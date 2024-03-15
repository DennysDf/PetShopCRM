using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IUserService
{
    Task<User> AddAsync(User user);
    Task<ResponseDTO<User>> ValidateUser(UserLoginDTO userLogin);
}
