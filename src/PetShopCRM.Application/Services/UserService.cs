using Microsoft.EntityFrameworkCore;
using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.DTOs.User;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;
using System.Collections;

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

    public async Task<List<User>> GetAllAsync()
    {
        var users = unitOfWork.UserRepository.GetBy();

        return users.ToList();
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
        userDb.UrlPhoto = modelProfile.NamePhoto;

        try
        {
            var user = await unitOfWork.UserRepository.AddOrUpdateAsync(userDb);
            await unitOfWork.SaveChangesAsync();

            return new ResponseDTO<User>(true, Resources.Message.UserSucessUpdate, user);
        }
        catch (Exception ex)
        {
            return new ResponseDTO<User>(false, ex.Message, null);
        }        
    }

    public async Task<User> AddOrUpdateAsync(User model)
    {
        ArgumentNullException.ThrowIfNull(model);
        model.Active = true;
        await unitOfWork.UserRepository.AddOrUpdateAsync(model);

        await unitOfWork.SaveChangesAsync();

        return model;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var delete = await unitOfWork.UserRepository.DeleteOrRestoreAsync(id);
        await unitOfWork.SaveChangesAsync();
        return delete;
    }

    public ResponseDTO<User> GetUserByCPForEmail(string model)
    {
        var users = unitOfWork.UserRepository.GetBy();
        var user = users.Where(c => (c.CPF == model || c.Email == model) && c.Active);
        User userModel = null;
        var email = string.Empty;

        if (user.Any())
        {
            userModel = user.First();
            email = userModel.Email;            
        }

        return new ResponseDTO<User>(user.Any(), email, userModel);

    }
}