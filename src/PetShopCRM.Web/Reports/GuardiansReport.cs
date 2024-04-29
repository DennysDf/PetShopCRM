using Microsoft.IdentityModel.Tokens;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Web.Reports;

public class GuardiansReport()
{
    private readonly DateTime dateLastMonth = DateTime.Now.AddMonths(-1);
    private readonly DateTime dateLastMonth2 = DateTime.Now.AddMonths(-2);

    public int GetQtdGuardians(List<Guardian> guardians) => guardians
            .Where(c => c.CreatedDate.Month == DateTime.Now.Month && c.CreatedDate.Year == DateTime.Now.Year)
            .ToList().Count;

    private int GetQtdGuardiansLastMonth(List<Guardian> guardians) =>   guardians
            .Where(c => c.CreatedDate.Month == dateLastMonth.Month)
            .ToList().Count;

    private int GetQtdGuardiansLastMonth2(List<Guardian> guardians) => guardians
         .Where(c => c.CreatedDate.Month == dateLastMonth2.Month)
         .ToList().Count;

    private bool CompareCurrentMonthWithLastMonth(int qtdGuardians, int qtdGuardiansLastMonth) => qtdGuardians > qtdGuardiansLastMonth;

    public string GetTypeText(List<Guardian> guardians)
    {
        var getQtdGuardians = GetQtdGuardians(guardians);
        var getQtdGuardiansLastMonth = GetQtdGuardiansLastMonth(guardians);
        var compare = CompareCurrentMonthWithLastMonth(getQtdGuardians, getQtdGuardiansLastMonth);
        return GetTyText(compare);
    }

    private string GetTyText(bool compare) => compare ? "success" : "danger";


    public string GetArrow(List<Guardian> guardians)
    {
        var getQtdGuardians = GetQtdGuardians(guardians);
        var getQtdGuardiansLastMonth = GetQtdGuardiansLastMonth(guardians);
        var compare = CompareCurrentMonthWithLastMonth(getQtdGuardians, getQtdGuardiansLastMonth);
        return GetArrow(compare);
    }
    private string GetArrow(bool compare) => compare ? "up" : "down";


    public double GetPercent(List<Guardian> guardians)
    {
        var getQtdGuardians = GetQtdGuardians(guardians);
        var getQtdGuardiansLastMonth = GetQtdGuardiansLastMonth(guardians);
        return GetPercent(getQtdGuardians, getQtdGuardiansLastMonth);
    }

    public double GetPercent2Months(List<Guardian> guardians)
    {
        var getQtdGuardiansLastMonth = GetQtdGuardiansLastMonth(guardians);
        var getQtdGuardiansLastMonth2 = GetQtdGuardiansLastMonth2(guardians);

        return GetPercentMonthLast(getQtdGuardiansLastMonth, getQtdGuardiansLastMonth2);
    }

    private double GetPercent(int qtdGuardians, int qtdGuardiansLastMonth) => Math.Round(((double)(qtdGuardians - qtdGuardiansLastMonth) / qtdGuardiansLastMonth) * 100, 2);
    private double GetPercentMonthLast(int qtdGuardians, int qtdGuardiansLastMonth) => Math.Round(((double)(qtdGuardians - qtdGuardiansLastMonth) / qtdGuardiansLastMonth) * 100, 2);

    

}
