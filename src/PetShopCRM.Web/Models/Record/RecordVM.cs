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
    public string? Observation { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Procedimento")]
    public int ProcedureHealthPlanId { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Pet")]
    public int PetId { get; set; }

    public string Name { get; set; }
    public string Identifier { get; set; }
    public string Specie { get; set; }
    public string Guardian { get; set; }
    public string HealthPlan { get; set; }
    public string Procedure { get; set; }
    public string Clinic { get; set; }
    public SelectList ListProcedureHealthPlan { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]    
    public SelectList ListPets { get; set; }
    public int HealthPlanId { get; set; }
    public SelectList ListHealthPlan { get; set; }

    [Required(ErrorMessage = ValidationKeysUtil.Required)]
    [DisplayName("Clínica")]
    public int ClinicId { get; set; }
    public SelectList ListClinics { get; set; }

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
        ProcedureHealthPlanId = this.ProcedureHealthPlanId,
        ClinicId = this.ClinicId
    };

    public RecordVM ToVM(List<Domain.Models.Record> model) => model.Select(c => new RecordVM { Name = c.Pet.Name, Identifier = c.Pet.Identifier, Specie = c.Pet.Specie.Name, Guardian = c.Pet.Guardian.Name, ReasonConsultation = c.ReasonConsultation, Date = c.Date, Diagnosis = c.Diagnosis, ClinicalHistory = c.ClinicalHistory, Observation = c.Observation, Prescription = c.Prescription, PhysicalExam = c.PhysicalExam, Procedure = c.ProcedureHealthPlan.Procedure.Description, Clinic = c.Clinic.Name, HealthPlan = c.ProcedureHealthPlan.HealthPlan.Name }).First();

    public RecordVM ToVM(Domain.Models.Record model) 
    {
        var vm = new RecordVM();
        vm.Date = model.Date;
        vm.ClinicId = model.ClinicId;
        vm.PetId = model.PetId;
        vm.ProcedureHealthPlanId = model.ProcedureHealthPlanId;
        vm.ReasonConsultation = model.ReasonConsultation;
        vm.ClinicalHistory = model.ClinicalHistory;
        vm.Observation = model.Observation;
        vm.Diagnosis = model.Diagnosis;
        vm.PhysicalExam = model.PhysicalExam;
        vm.Prescription = model.Prescription;

        return  vm;

    }
}
