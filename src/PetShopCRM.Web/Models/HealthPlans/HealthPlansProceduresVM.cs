using PetShopCRM.Domain.Enums;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Web.Models.HealthPlans;

public class HealthPlansProcedureVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public List<ListHealthPlansProceduresVM?> ListHealthPlansProcedures { get; set; }

    public HealthPlansProcedureVM ToVM(HealthPlan model) => new() 
    { 
        Id = model.Id,
        Name = model.Name,
        Value = model.Value.ToString(),
        ListHealthPlansProcedures = new ListHealthPlansProceduresVM().ToList(model)

    };
}

public class ListHealthPlansProceduresVM
{    
    public string Procedure { get; set; }
    public string Group { get; set; }
    public int? AnnualLimit { get; set; }
    public int? Lack { get; set; }
    public decimal Coparticipation { get; set; }
    public ProcedureCoparticipationUnit CoparticipationUnit { get; set; }

    public List<ListHealthPlansProceduresVM?> ToList(HealthPlan healthPlan)
    {
        var listHealthPlansProcedures  = new List<ListHealthPlansProceduresVM>();

        foreach (var item in healthPlan.ProcedureHealthPlans)
        {
            listHealthPlansProcedures.Add(new ListHealthPlansProceduresVM() 
            { 
                AnnualLimit = item.AnnualLimit,
                Coparticipation = item.Coparticipation,
                Group = item.Procedure.ProcedureGroup.Description,
                Lack = item.Lack,
                Procedure = item.Procedure.Description,
                CoparticipationUnit = item.CoparticipationUnit
            });

        }

        return listHealthPlansProcedures;
    }
}
