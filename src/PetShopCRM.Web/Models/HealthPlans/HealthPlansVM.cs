using PetShopCRM.Web.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PetShopCRM.Web.Models.Guardian;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.Web.Models.Specie;

namespace PetShopCRM.Web.Models.HealthPlans;

public class HealthPlansVM 
{
    public int Id { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Nome")]
    public string Name { get; set; }

    public decimal Value { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Valor")]
    public string ValueFrontEnd { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Descrição")]
    public string Description { get; set; }

    public List<HealthPlansVM> ToList(List<Domain.Models.HealthPlan> listPlan) => listPlan.Select(listPlan => new HealthPlansVM
    {
        Name = listPlan.Name,
        Id = listPlan.Id,
        Description = listPlan.Description,
        Value = listPlan.Value
        
    }).ToList();

    public Domain.Models.HealthPlan ToModel() => new Domain.Models.HealthPlan() { Id = this.Id, Name = this.Name, Value = this.Value, Description = this.Description  };

    public HealthPlansVM ToVM(Domain.Models.HealthPlan model) => new HealthPlansVM { Id = model.Id, Name = model.Name, Description = model.Description, ValueFrontEnd = model.Value.ToString()};
}

public class ProceduresVM()
{
    public int Id { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Procedimento")]
    public string Name { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Grupo")]
    public int GroupId { get; set; }
    public string Group { get; set; }
    public SelectList GroupList { get; set; }
    public List<ProceduresVM> ToList(List<Domain.Models.Benefit> benefit) => benefit.Select(benefit => new ProceduresVM
    {
        Name = benefit.Procedure,
        Id = benefit.Id,
        GroupId = benefit.GroupId,
        Group = benefit.Group.Description

    }).ToList();

    public Domain.Models.Benefit ToModel() => new() { Id = this.Id, Procedure = this.Name, GroupId = this.GroupId };

    public ProceduresVM ToVM(Domain.Models.Benefit model) => new() { Id = model.Id, Name = model.Procedure, GroupId = model.GroupId };

}
