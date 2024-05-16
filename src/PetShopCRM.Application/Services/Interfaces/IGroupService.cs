using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IGroupService
{
    Task<List<Group>> GetAllAsync();
    Task<Group> AddOrUpdateAsync(Group group);
    Task<ResponseDTO<Group>> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
}
