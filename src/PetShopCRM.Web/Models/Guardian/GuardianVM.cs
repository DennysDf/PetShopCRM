using PetShopCRM.Web.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PetShopCRM.Domain.Models;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace PetShopCRM.Web.Models.Guardian;

public class GuardianVM
{
    public int Id { get; set; }
    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Nome")]
    public string Name { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Data de Nascimento")]
    public string DateBirth { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("CPF")]
    public string CPF { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Telefone")]
    public string Phone { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Endereço")]
    public string Address { get; set; }

    public List<GuardianVM> ToList(List<Domain.Models.Guardian> listGuardian)  =>listGuardian.Select(guardian => new GuardianVM
        {
            Name = guardian.Name,
            Address = guardian.Address,
            CPF = guardian.CPF,
            DateBirth = guardian.DateBirth,
            Id = guardian.Id,
            Phone = guardian.Phone
        }).ToList();

    public Domain.Models.Guardian ToModel() => new Domain.Models.Guardian() { Id = this.Id, Name = this.Name, Address = this.Address, CPF = this.CPF, DateBirth = this.DateBirth, Phone = this.Phone };

    public GuardianVM ToVM(Domain.Models.Guardian model) => new GuardianVM { Id = model.Id, Name = model.Name, Address = model.Address, CPF = model.CPF, DateBirth = model.DateBirth, Phone = model.Phone };
    

}
