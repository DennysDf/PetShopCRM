namespace PetShopCRM.Web.Models.Details;

public class DetailsPetVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public string Identifier { get; set; }
    public string Specie { get; set; }
    public string Sex { get; set; }
    public string Weight { get; set; }
    public string Age { get; set; }
    public string Breed { get; set; }
    public string Spayed { get; set; }
    public string UrlPhoto { get; set; }
    public string Guardian { get; set; }
    public string HealthPlan { get; set; }
    public bool NeedUpdatePhoto { get; set; }

    public int GuardianId { get; set; }
    public int? PaymentId { get; set; }
    public int? HealthPlanId { get; set; }

    public void ToVM(Domain.Models.Pet pet)
    {
        var semResposta = "N/A";

        Id = pet.Id;
        Name = pet.Name;
        Color = pet.Color ?? semResposta;
        Identifier = pet.Identifier ?? semResposta;
        Specie = pet.Specie?.Name ?? semResposta;
        Sex = pet.Sex != null ? pet.Sex == "F" ? "Femea" : "Macho" : semResposta;
        Weight = pet.Weight ?? semResposta;
        Age = pet.Age ?? semResposta;
        Breed = pet.Breed ?? semResposta;
        Spayed = pet.Spayed != null ? pet.Spayed.Value ? "Sim" : "Não" : semResposta;
        UrlPhoto = pet.UrlPhoto;
        Guardian = pet.Guardian.Name;
        GuardianId = pet.GuardianId;
        HealthPlan = pet.Payments?.LastOrDefault(x => x.IsSuccess && x.Active && x.ExternalId != null)?.HealthPlan?.Name ?? semResposta;
        PaymentId = pet.Payments?.LastOrDefault(x => x.IsSuccess && x.Active && x.ExternalId != null)?.Id;
        HealthPlanId = pet.Payments?.LastOrDefault(x => x.IsSuccess && x.Active && x.ExternalId != null)?.HealthPlanId;
        NeedUpdatePhoto = pet.UrlPhoto != null && pet.ShowReportImgUpdate == true && pet.UpdatedDateImg != null && (DateTime.Now - pet.UpdatedDateImg.Value).Days > 30;
    }
}
