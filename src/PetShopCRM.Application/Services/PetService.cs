using Microsoft.EntityFrameworkCore;
using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;
using PetShopCRM.Infrastructure.DTOs.Report;
using System.Text.RegularExpressions;

namespace PetShopCRM.Application.Services;

public class PetService(IUnitOfWork unitOfWork) : IPetService
{
    public async Task<List<Pet>> GetAllAsync()
    {
        var pets = unitOfWork.PetRepository.GetBy()
            .Include(x => x.Guardian)
            .OrderBy(c => c.Name);

        return pets.ToList();
    }

    public async Task<ResponseDTO<List<Pet>>> GetAllCompleteAsync()
    {
        var pets = unitOfWork.PetRepository.GetBy();

        var result = pets
            .Include(x => x.Guardian)
            .Include(x => x.Specie)
            .Include(c => c.Payments.Where(x => x.IsSuccess && x.Active))
                   .ThenInclude(x => x.HealthPlan)
            .OrderBy(c => c.Name)
            .ToList();

        return new ResponseDTO<List<Pet>>(result.Count > 0, "Nenhum resultado encontrado", result);
    }

    public async Task<Pet> AddOrUpdateAsync(Pet model)
    {
        ArgumentNullException.ThrowIfNull(model);
        
        await unitOfWork.PetRepository.AddOrUpdateAsync(model);
        await unitOfWork.SaveChangesAsync();

        return model;
    }

    public async Task<ResponseDTO<Pet>> GetCompleteByIdAsync(int id)
    {
        var pet = await unitOfWork.PetRepository.GetBy(x => x.Id == id)
            .Include(x => x.Guardian)
            .Include(x => x.Specie)
            .Include(x => x.Payments)
                .ThenInclude(x => x.HealthPlan)
            .FirstOrDefaultAsync();

        return new ResponseDTO<Pet>(pet != null, Resources.Message.PetNotFound, pet);
    }

    public async Task<ResponseDTO<Pet>> GetByIdAsync(int id)
    {
        var model = await unitOfWork.PetRepository.GetByIdAsync(id);
        return new ResponseDTO<Pet>(model != null, Resources.Message.PetNotFound, model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var delete = await unitOfWork.PetRepository.DeleteOrRestoreAsync(id);
        await unitOfWork.SaveChangesAsync();
        return delete;
    }

    public  List<PetUpdateImgDTO>? GetPetsForUpdateImg()
    {
        var pets = unitOfWork.PetRepository.GetBy();

        var result = pets
            .Include(c => c.Guardian)
            .Include(x => x.Specie)
            .Where(c => c.Active && c.UrlPhoto != null && (c.ShowReportImgUpdate ?? false))
            .Select(c => new PetUpdateImgDTO(c.Id, c.Name, c.Guardian.Name, (DateTime.Now - (DateTime)c.UpdatedDateImg).Days, (DateTime)c.UpdatedDateImg, "55"+ Regex.Replace(c.Guardian.Phone, @"\D", "") )).ToList();

        return result;
    }

    public async Task<List<Pet>> GetAllForPlansAsync()
    {
        var pets = unitOfWork.PetRepository.GetBy()
            .Include(x => x.Guardian)
            .Include(x => x.Payments)
                .ThenInclude(c => c.HealthPlan)
            .Where(c => c.Payments.Where(c => c.IsSuccess && c.Active).Any())
            .OrderBy(c => c.Name);

        return pets.ToList();
    }
}
