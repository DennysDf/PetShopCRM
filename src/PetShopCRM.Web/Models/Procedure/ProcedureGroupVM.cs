using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Util;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShopCRM.Web.Models.Procedure;

public class ProcedureGroupVM
{
    public int Id { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Grupo")]
    public string Description { get; set; }

    public List<ProcedureGroupVM> ToList(List<ProcedureGroup> groups) => groups.Select(group => new ProcedureGroupVM
    {
        Id = group.Id,
        Description = group.Description,
    }).ToList();

    public ProcedureGroup ToModel() => new() { Id = this.Id, Description = this.Description };

    public ProcedureGroupVM ToVM(Domain.Models.ProcedureGroup model) => new() { Id = model.Id, Description = model.Description };

}
