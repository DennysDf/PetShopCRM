using PetShopCRM.Web.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PetShopCRM.Web.Models.Clinic;

namespace PetShopCRM.Web.Models.Specie;

public class SpecieVM
{
    public int Id { get; set; }
    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Nome")]
    public string Name { get; set; }


    public List<SpecieVM> ToList(List<Domain.Models.Specie> species) => species.Select(species => new SpecieVM
    {
        Name = species.Name,        
        Id = species.Id,
        
    }).ToList();

    public Domain.Models.Specie ToModel() => new Domain.Models.Specie() { Id = this.Id, Name = this.Name };

    public SpecieVM ToVM(Domain.Models.Specie model) => new SpecieVM { Id = model.Id, Name = model.Name };
}
