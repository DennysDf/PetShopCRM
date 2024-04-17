using PetShopCRM.Web.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PetShopCRM.Web.Models.Guardian;

namespace PetShopCRM.Web.Models.Clinic;

public class ClinicVM
{
    public int Id { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Nome")]
    public string Name { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Endereço")]
    public string Address { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Telefone")]
    public string Phone { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Responsável")]
    public string Responsible { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("CNPJ")]
    public string CNPJ { get; set; }


    public List<ClinicVM> ToList(List<Domain.Models.Clinic> listClinic) => listClinic.Select(clinic => new ClinicVM
    {
        Name = clinic.Name,
        Address = clinic.Address,
        CNPJ = clinic.CNPJ,
        Responsible = clinic.Responsible,
        Id = clinic.Id,
        Phone = clinic.Phone
    }).ToList();

    public Domain.Models.Clinic ToModel() => new Domain.Models.Clinic() { Id = this.Id, Name = this.Name, Address = this.Address, CNPJ = this.CNPJ, Responsible = this.Responsible, Phone = this.Phone };

    public ClinicVM ToVM(Domain.Models.Clinic model) => new ClinicVM { Id = model.Id, Name = model.Name, Address = model.Address, CNPJ = model.CNPJ, Responsible = model.Responsible, Phone = model.Phone };
}
