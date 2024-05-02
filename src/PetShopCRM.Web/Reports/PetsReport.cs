using PetShopCRM.Domain.Models;

namespace PetShopCRM.Web.Reports;

public class PetsReport
{
    private readonly DateTime dateLastMonth = DateTime.Now.AddMonths(-1);

    public int GetQtdPets(List<Pet> pets) => pets
            .Where(c => c.CreatedDate.Month == DateTime.Now.Month && c.CreatedDate.Year == DateTime.Now.Year)
            .ToList().Count;

    private int GetQtdPetsLastMonth(List<Pet> pets) => pets
            .Where(c => c.CreatedDate.Month == dateLastMonth.Month)
            .ToList().Count;

    private bool CompareCurrentMonthWithLastMonth(int qtdPets, int qtdPetsLastMonth) => qtdPets > qtdPetsLastMonth;

    public string GetTypeText(List<Pet> pets)
    {
        var getQtdPets = GetQtdPets(pets);
        var getQtdPetsLastMonth = GetQtdPetsLastMonth(pets);
        var compare = CompareCurrentMonthWithLastMonth(getQtdPets, getQtdPetsLastMonth);
        return GetTypeText(compare);
    }

    private string GetTypeText(bool compare) => compare ? "success" : "danger";


    public string GetArrow(List<Pet> pets)
    {
        var getQtdPets = GetQtdPets(pets);
        var getQtdPetsLastMonth = GetQtdPetsLastMonth(pets);
        var compare = CompareCurrentMonthWithLastMonth(getQtdPets, getQtdPetsLastMonth);
        return GetArrow(compare);
    }
    private string GetArrow(bool compare) => compare ? "up" : "down";

    public double GetPercent(List<Pet> pets)
    {
        var getQtdPets = GetQtdPets(pets);
        var getQtdPetsLastMonth = GetQtdPetsLastMonth(pets);
        if (getQtdPetsLastMonth == 0) return 100;
        return GetPercent(getQtdPets, getQtdPetsLastMonth);
    }

    private double GetPercent(int qtdPets, int qtdPetsLastMonth) => Math.Round(((double)(qtdPets - qtdPetsLastMonth) / qtdPetsLastMonth) * 100, 2);
    
}
