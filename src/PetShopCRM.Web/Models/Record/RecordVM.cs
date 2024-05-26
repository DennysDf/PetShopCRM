using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PetShopCRM.Web.Models.Record;

public class RecordVM
{
    public int Id { get; set; }
    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Data do atendimento")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Motivo da Consulta")]
    public string ReasonConsultation { get; set; }
        
    [DisplayName("Histórico Clínico")]
    public string? ClinicalHistory { get; set; }

    [DisplayName("Exame Físico")]
    public string? PhysicalExam { get; set; }

    [DisplayName("Diagnóstico")]
    public string? Diagnosis { get; set; }

    [DisplayName("Prescrição")]
    public string? Prescription { get; set; }

    [DisplayName("Observações")]
    public string? Observation { get; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Procedimento")]
    public int ProcedureHealthPlanId { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Pet")]
    public int PetId { get; set; }

    public SelectList ListProcedureHealthPlan { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]    
    public SelectList ListPets { get; set; }
    public int HealthPlanId { get; set; }
    public SelectList ListHealthPlan { get; set; }


    public PetShopCRM.Domain.Models.Record ToModel(RecordVM model) => new Domain.Models.Record() 
    { 
        ClinicalHistory = this.ClinicalHistory,
        PhysicalExam = this.PhysicalExam,
        Diagnosis = this.Diagnosis,
        Prescription = this.Prescription,
        Date = this.Date,
        PetId = this.PetId,
        Observation = this.Observation,
        ReasonConsultation = this.ReasonConsultation,
        ProcedureHealthPlanId = this.ProcedureHealthPlanId
    };
}
