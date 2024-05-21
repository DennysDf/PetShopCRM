using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Util;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

    public List<HealthPlansVM> ToList(List<HealthPlan> listPlan) => listPlan.Select(listPlan => new HealthPlansVM
    {
        Name = listPlan.Name,
        Id = listPlan.Id,
        Description = listPlan.Description,
        Value = listPlan.Value

    }).ToList();

    public HealthPlan ToModel() => new HealthPlan() { Id = this.Id, Name = this.Name, Value = this.Value, Description = this.Description };

    public HealthPlansVM ToVM(HealthPlan model) => new HealthPlansVM { Id = model.Id, Name = model.Name, Description = model.Description, ValueFrontEnd = model.Value.ToString() };
}