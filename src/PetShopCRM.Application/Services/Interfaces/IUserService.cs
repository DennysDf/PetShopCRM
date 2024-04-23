using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.DTOs.User;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IUserService
{
    Task<User> AddAsync(User user);
    Task<ResponseDTO<User>> ValidateAsync(UserLoginDTO userLogin);

    Task<ResponseDTO<User>> GetUserByIdAsync(int id);

    Task<ResponseDTO<User>> UpdateAsync(ProfileDTO modelProfile);

    Task<List<User>> GetAllAsync();
}
