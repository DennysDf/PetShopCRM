using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.DTOs.User;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;

namespace PetShopCRM.Application.Services;

public class UserService(IUnitOfWork unitOfWork) : IUserService
{
    public async Task<User> AddAsync(User user)
    {
        ArgumentNullException.ThrowIfNull(user);

        await unitOfWork.UserRepository.AddOrUpdateAsync(user);

        await unitOfWork.SaveChangesAsync();

        return user;
    }

    public async Task<ResponseDTO<User>> GetUserByIdAsync(int id)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(id);        
        return new ResponseDTO<User>(user != null,Resources.Message.UserNotFound, user);
        
    }

    public async Task<ResponseDTO<User>> ValidateAsync(UserLoginDTO userLogin)
    {
        var user = await unitOfWork.UserRepository.GetByLoginAndPasswordAsync(userLogin.UserLogin, userLogin.UserPassword);

        var isValid = user is { Active: true };

        var response = new ResponseDTO<User>(isValid, isValid ? Resources.Message.UserValid : Resources.Message.UserInvalid, user);

        return response;
    }

    public async Task<ResponseDTO<User>> UpdateAsync(ProfileDTO modelProfile)
    {
        var userDb = await unitOfWork.UserRepository.GetByIdAsync(modelProfile.Id);
        userDb.Name = modelProfile.Name;
        userDb.Email = modelProfile.Email;
        userDb.Phone = modelProfile.Phone;
        userDb.Password = modelProfile.Password ?? userDb.Password;
        userDb.UrlPhoto =




        var user = await unitOfWork.UserRepository.AddOrUpdateAsync();

    }
}