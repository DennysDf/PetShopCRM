using System.Numerics;

namespace PetShopCRM.Web.Models.User;

public class UserGuardianVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Identifier { get; set; }
    public string Specie { get; set; }
    public string HealthPlan { get; set; }
    public string Url { get; set; }
    public string Sexy { get; set; }

    public List<UserGuardianVM> ToViewModel(List<Domain.Models.Pet> model)
    {
       var  listGuard = new List<UserGuardianVM>();

        foreach (var item in model)
        {
            var healthPlan = item.Payments.Count != 0 ? item.Payments.First().HealthPlan.Name : null;

            var guardian = new UserGuardianVM()
            {
                Id = item.Id,
                Identifier = item.Identifier, 
                Name = item.Name, 
                Specie = item.Specie.Name,
                HealthPlan = healthPlan,
                Url = item.UrlPhoto,
                Sexy = item.Sexy == "F" ? "Femea":"Macho"
            };

            listGuard.Add(guardian);
        }

        return listGuard;
    }

}
