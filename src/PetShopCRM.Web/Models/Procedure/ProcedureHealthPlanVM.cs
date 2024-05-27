using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Util;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetShopCRM.Web.Models.Procedure;

public class ProcedureHealthPlanVM
{
    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Procedimento")]
    public int ProcedureId { get; set; }
    public List<ProcedureHealthPlanListVM> ProcedureHealthPlanList { get; set; }
    public SelectList ProcedureList { get; set; }
    public SelectList ProcedureUnitList { get; set; }

    public string ProcedureName { get; set; }
    public string ProcedureGroup { get; set; }

    public List<ProcedureHealthPlanVM> ToList(List<Domain.Models.Procedure> procedures) => procedures.Select(procedure => new ProcedureHealthPlanVM
    {
        ProcedureId = procedure.Id,
        ProcedureName = procedure.Description,
        ProcedureGroup = procedure.ProcedureGroup.Description,
        ProcedureHealthPlanList = procedure.ProcedureHealthPlans.Select(x => new ProcedureHealthPlanListVM
        {
            Id = x.Id,
            AnnualLimit = x.AnnualLimit,
            Coparticipation = x.Coparticipation,
            CoparticipationFrontEnd = x.Coparticipation.ToString(),
            Lack = x.Lack,
            HealthPlanName = x.HealthPlan.Name,
            HealthPlanValue = x.HealthPlan.Value,
            Observation = x.Observation,
            HasValue = x.Active,
            CoparticipationUnit = x.CoparticipationUnit,
            HealthPlanId = x.HealthPlanId
        }).OrderBy(x => x.HealthPlanId).ToList()
    }).ToList();

    public ProcedureHealthPlanVM ToVM(Domain.Models.Procedure model) => new()
    {
        ProcedureId = model.Id,
        ProcedureName = model.Description,
        ProcedureHealthPlanList = model.ProcedureHealthPlans.Select(x => new ProcedureHealthPlanListVM
        {
            Id = x.Id,
            AnnualLimit = x.AnnualLimit,
            Coparticipation = x.Coparticipation,
            CoparticipationFrontEnd = x.Coparticipation.ToString(),
            Lack = x.Lack,
            HealthPlanId = x.HealthPlan.Id,
            HealthPlanName = x.HealthPlan.Name,
            HealthPlanValue = x.HealthPlan.Value,
            Observation = x.Observation,
            HasValue = x.Active,
            CoparticipationUnit = x.CoparticipationUnit
        }).OrderBy(x => x.HealthPlanId).ToList()
    };

    public Domain.Models.Procedure ToModel(Domain.Models.Procedure procedure)
    {
        var procedureHealthPlans = procedure.ProcedureHealthPlans;
        procedure.ProcedureHealthPlans = new List<ProcedureHealthPlan>();

        foreach (var item in ProcedureHealthPlanList.Where(x => x.Id != 0))
        {
            var procedureHealthPlan = procedureHealthPlans.FirstOrDefault(x => x.Id == item.Id);

            if (procedureHealthPlan is null)
                continue;

            procedureHealthPlan.ProcedureId = procedure.Id;

            procedure.ProcedureHealthPlans.Add(item.ToModel(procedureHealthPlan));
        }

        foreach (var item in ProcedureHealthPlanList.Where(x => x.Id == 0 && x.HasValue))
        {
            procedure.ProcedureHealthPlans.Add(item.ToModel(new ProcedureHealthPlan { ProcedureId = procedure.Id }));
        }

        return procedure;
    }
}

public class ProcedureHealthPlanListVM
{
    public int Id { get; set; }
    public int HealthPlanId { get; set; }
    public bool HasValue { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Coparticipação")]
    public string CoparticipationFrontEnd { get; set; }
    public decimal Coparticipation { get; set; }

    [DisplayName("Limite anual")]
    public int? AnnualLimit { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Carência (dias)")]
    public int? Lack { get; set; }

    public string HealthPlanName { get; set; }
    public decimal HealthPlanValue { get; set; }
    public string? Observation { get; set; }
    public ProcedureCoparticipationUnit CoparticipationUnit { get; set; }

    public ProcedureHealthPlan ToModel(ProcedureHealthPlan procedureHealthPlan)
    {
        procedureHealthPlan.Id = Id;
        procedureHealthPlan.AnnualLimit = AnnualLimit;
        procedureHealthPlan.Coparticipation = CoparticipationFrontEnd.StringToDecimal();
        procedureHealthPlan.Lack = Lack ?? 0;
        procedureHealthPlan.HealthPlanId = HealthPlanId;
        procedureHealthPlan.Observation = Observation;
        procedureHealthPlan.Active = HasValue;
        procedureHealthPlan.CoparticipationUnit = CoparticipationUnit;

        return procedureHealthPlan;
    }
}