using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PetShopCRM.Web.Models.Record;

public class RecordVM
{
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
    [DisplayName("Pets")]
    public SelectList ListPets { get; set; }

   

}
