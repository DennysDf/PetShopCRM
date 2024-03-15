using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Interfaces;

namespace PetShopCRM.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<User> AddAsync(User user)
    {
        ArgumentNullException.ThrowIfNull(user);

        await userRepository.AddOrUpdateAsync(user);

        return user;
    }

    public async Task<ResponseDTO<User>> ValidateUser(UserLoginDTO userLogin)
    {
        var user = await userRepository.GetByLoginAndPasswordAsync(userLogin.UserLogin, userLogin.UserPassword);

        var isValid = user is { Active: true };

        var response = new ResponseDTO<User>(isValid, isValid ? Resources.Message.UserValid : Resources.Message.UserInvalid, user);

        return response;
    }
}