using PetShopCRM.Web.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PetShopCRM.Web.Models.Clinic;
using Microsoft.AspNetCore.Mvc.Rendering;

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

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Identificador")]
    public string Identifier { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Espécie")]
    public int SpecieId { get; set; }
    public string Specie { get; set; }

    public SelectList GuardianList { get; set; }
    public SelectList SpecieList { get; set; }


    public List<PetVM> ToList(List<Domain.Models.Pet> listClinic) => listClinic.Select(pet => new PetVM
    {
        Id = pet.Id,
        Name = pet.Name,                
        GuardianId  = pet.GuardianId,   
        Identifier = pet.Identifier,
        SpecieId = pet.SpecieId

    }).ToList();

    public Domain.Models.Pet ToModel() => new Domain.Models.Pet() { Id = this.Id, Name = this.Name, GuardianId = this.GuardianId, Identifier = this.Identifier, SpecieId = this.SpecieId  };

    public PetVM ToVM(Domain.Models.Pet model) => new PetVM { Id = model.Id, Name = model.Name, GuardianId = model.GuardianId, Identifier = model.Identifier, SpecieId = model.SpecieId };
}
