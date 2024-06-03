using PetShopCRM.Web.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PetShopCRM.Web.Models.Clinic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc;

namespace PetShopCRM.Web.Models.Pet;

public class PetVM
{
    public int Id { get; set; }
    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Nome")]
    public string Name { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Tutor")]
    public int GuardianId { get; set; }
    public string Guardian { get; set; }

    [DisplayName("Foto")]
    [RequiredIfInput(nameof(Identifier), false, ErrorMessage = ValidationKeysUtil.RequiredPetPhoto)]
    public IFormFile? Photo { get; set; }

    [DisplayName("Identificador")]
    public string? Identifier { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Espécie")]
    public int SpecieId { get; set; }
    public string Specie { get; set; }

    [DisplayName("Sexo")]
    public string? Sex { get; set; }

    [DisplayName("Cor")]
    public string? Color { get; set; }

    [DisplayName("Peso")]
    public string? Weight { get; set; }

    [DisplayName("Idade")]
    public string? Age { get; set; }

    [DisplayName("Raça")]
    public string? Breed { get; set; }

    [DisplayName("Observação")]
    public string? Obs { get; set; }

    [DisplayName("É cadastrado?")]
    public int? Spayed { get; set; }
    public string UrlPhoto { get; set; }    
    public SelectList GuardianList { get; set; }
    public SelectList SpecieList { get; set; }
    public int LastUpdate { get; set; }
    public string Route { get; set; }

    [ValidateNever]
    public bool ShowReportImgUpdate { get; set; }

    public static List<PetVM> ToList(List<Domain.Models.Pet> listClinic) => listClinic.Select(pet => new PetVM
    {
        Id = pet.Id,
        Name = pet.Name,
        GuardianId = pet.GuardianId,
        Identifier = pet.Identifier,
        SpecieId = pet.SpecieId,
        Guardian = pet.Guardian?.Name ?? string.Empty,
        Specie = pet.Specie?.Name ?? string.Empty,
        UrlPhoto = pet.UrlPhoto
    }).ToList();

    public Domain.Models.Pet ToModel() => new() { Id = this.Id, Name = this.Name, GuardianId = this.GuardianId, Identifier = this.Identifier, SpecieId = this.SpecieId, Sex = Sex != "0" ? Sex : null, Age = this.Age, Breed = this.Breed, Color = this.Color, Obs = this.Obs, Spayed = this.Spayed.HasValue && Spayed.HasValue ? (Spayed == 1 ? true : (Spayed == 0 ? false : (bool?)null)) : (bool?)null, Weight = this.Weight, UrlPhoto = this.UrlPhoto, ShowReportImgUpdate = this.ShowReportImgUpdate };

    public Domain.Models.Pet ToModel(Domain.Models.Pet model)
    {
        model.Id = this.Id;
        model.Name = this.Name ?? model.Name;
        model.GuardianId = this.GuardianId;
        model.Identifier = this.Identifier;
        model.SpecieId = this.SpecieId;
        model.Sex = this.Sex != "0" ? this.Sex : model.Sex;
        model.Age = this.Age ?? model.Age;
        model.Breed = this.Breed ?? model.Breed;
        model.Color = this.Color ?? model.Color;
        model.Obs = this.Obs ?? model.Obs;
        model.Spayed = this.Spayed.HasValue ? (this.Spayed == 1 ? true : (this.Spayed == 0 ? false : (bool?)null)) : model.Spayed;
        model.Weight = this.Weight ?? model.Weight;
        model.UrlPhoto = this.UrlPhoto ?? model.UrlPhoto;
        model.ShowReportImgUpdate = this.ShowReportImgUpdate;
        return model;
    }


    public PetVM ToVM(Domain.Models.Pet model)
    {
        var pet = new PetVM(); ;
        pet.Id = model.Id;
        pet.Name = model.Name;
        pet.GuardianId = model.GuardianId;
        pet.Identifier = model.Identifier;
        pet.SpecieId = model.SpecieId;
        pet.Sex = model.Sex;
        pet.Age = model.Age;
        pet.Weight = model.Weight;
        pet.Color = model.Color;
        pet.Obs = model.Obs;
        pet.Breed = model.Breed;
        pet.Spayed = model.Spayed == null ? 2 : (bool)model.Spayed ? 1 : 0;
        pet.UrlPhoto = model.UrlPhoto;
        pet.ShowReportImgUpdate = model.ShowReportImgUpdate ?? false;

        if (model.UpdatedDateImg != null)
        {
            var dataRetroativa = model.UpdatedDateImg;
            // Calcula a diferença
            TimeSpan diferenca = DateTime.Now.Subtract((DateTime)dataRetroativa);
            // Obtém a quantidade total de dias como um número inteiro
            int totalDias = (int)diferenca.TotalDays;
            pet.LastUpdate = totalDias;
        }


        return pet;

    }

}


