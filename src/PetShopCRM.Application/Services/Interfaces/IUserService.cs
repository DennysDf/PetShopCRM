using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.DTOs.User;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IUserService
{
    Task<User> AddAsync(User user);
    Task<ResponseDTO<User>> ValidateUser(UserLoginDTO userLogin);

    Task<ResponseDTO<User>> GetUserById(int id);

    Task<ResponseDTO<User>> UpdateAsync(ProfileDTO modelProfile);
}
