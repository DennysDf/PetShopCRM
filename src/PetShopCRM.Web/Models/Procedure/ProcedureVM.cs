using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.Web.Util;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShopCRM.Web.Models.Procedure;

public class ProcedureVM()
{
    public int Id { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Procedimento")]
    public string Description { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Grupo")]
    public int GroupId { get; set; }
    public string Group { get; set; }
    public SelectList GroupList { get; set; }

    public List<ProcedureVM> ToList(List<Domain.Models.Procedure> procedures) => procedures.Select(procedure => new ProcedureVM
    {
        Description = procedure.Description,
        Id = procedure.Id,
        GroupId = procedure.ProcedureGroupId,
        Group = procedure.ProcedureGroup.Description
    }).ToList();

    public Domain.Models.Procedure ToModel() => new() { Id = this.Id, Description = this.Description, ProcedureGroupId = this.GroupId };

    public ProcedureVM ToVM(Domain.Models.Procedure model) => new() { Id = model.Id, Description = model.Description, GroupId = model.ProcedureGroupId };

}
