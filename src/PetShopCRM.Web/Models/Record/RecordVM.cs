﻿using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PetShopCRM.Web.Models.Record;

public class RecordVM
{
    public int Id { get; set; }
    public string? Route { get; set; }

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

    public Domain.Models.Record ToModel(Domain.Models.Record model)
    {
        model.Id = this.Id;
        model.ClinicalHistory = this.ClinicalHistory;
        model.PhysicalExam = this.PhysicalExam;
        model.Diagnosis = this.Diagnosis;
        model.Prescription = this.Prescription;
        model.Date = this.Date;
        model.PetId = this.PetId;
        model.Observation = this.Observation;
        model.ReasonConsultation = this.ReasonConsultation;
        model.ProcedureHealthPlanId = this.ProcedureHealthPlanId;
        model.ClinicId = this.ClinicId;

        return model;
    }

    public RecordVM ToVM(List<Domain.Models.Record> model) => model.Select(c => new RecordVM { Name = c.Pet.Name, Identifier = c.Pet.Identifier, Specie = c.Pet.Specie.Name, Guardian = c.Pet.Guardian.Name, ReasonConsultation = c.ReasonConsultation, Date = c.Date, Diagnosis = c.Diagnosis, ClinicalHistory = c.ClinicalHistory, Observation = c.Observation, Prescription = c.Prescription, PhysicalExam = c.PhysicalExam, Procedure = c.ProcedureHealthPlan.Procedure.Description, Clinic = c.Clinic.Name, HealthPlan = c.ProcedureHealthPlan.HealthPlan.Name }).First();

    public RecordVM ToVM(Domain.Models.Record model)
    {
        this.Date = model.Date;
        this.ClinicId = model.ClinicId;
        this.PetId = model.PetId;
        this.ProcedureHealthPlanId = model.ProcedureHealthPlanId;
        this.ReasonConsultation = model.ReasonConsultation;
        this.ClinicalHistory = model.ClinicalHistory;
        this.Observation = model.Observation;
        this.Diagnosis = model.Diagnosis;
        this.PhysicalExam = model.PhysicalExam;
        this.Prescription = model.Prescription;

        return this;

    }
}
