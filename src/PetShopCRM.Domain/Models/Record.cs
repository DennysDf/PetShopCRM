namespace PetShopCRM.Domain.Models;

public class Record : EntityBase
{
    public DateTime Date { get; set; }
    public string ReasonConsultation { get; set; }
    public string ClinicalHistory { get; set;}
    public string PhysicalExam { get; set; }
    public string Diagnosis { get; set; }
    public string Prescription { get; set; }
    public string Observation { get; set; }
    public int ProcedureHealthPlanId { get; set; }
    public int PetId { get; set; }
    public int ClinicId { get; set; }
    public ProcedureHealthPlan ProcedureHealthPlan { get; set; }
    public Pet Pet { get; set; }
    public Clinic Clinic { get; set; }
}   
