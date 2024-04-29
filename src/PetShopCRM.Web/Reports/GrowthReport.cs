using PetShopCRM.Domain.Models;

namespace PetShopCRM.Web.Reports;

public class GrowthReport
{
    private readonly GuardiansReport guardiansReport = new();
    private readonly SalesReport salesReport = new();
    private readonly RevenueReport revenueReport = new();

    public double GetPercent( List<Guardian> guardians, List<Payment> payments)
    {       
        var percentGuardians = guardiansReport.GetPercent(guardians);
        var percentSales= salesReport.GetPercent(payments);
        var percentRevenue = revenueReport.GetPercent(payments);

        return Math.Round((percentGuardians + percentRevenue + percentSales) / 3,2);
    }

    private double GetPercentLastMonth(List<Guardian> guardians, List<Payment> payments)
    {
        var percentGuardians = guardiansReport.GetPercent2Months(guardians);
        var percentSales = salesReport.GetPercent2Months(payments);
        var percentRevenue = revenueReport.GetPercent2Months(payments);
        return Math.Round((percentGuardians + percentRevenue + percentSales) / 3, 2);
    }

    public double GetPercentDifference(List<Guardian> guardians, List<Payment> payments)
    {
        var percent = GetPercent(guardians, payments);
        var percentLastMonth = GetPercentLastMonth(guardians, payments);

        return Math.Round(((double)(percent - percentLastMonth) / percentLastMonth) * 100, 2);
    }

    private bool CompareCurrentMonthWithLastMonth(double qtdGrowth, double qtdGrowthLastMonth) => qtdGrowth > qtdGrowthLastMonth;

    public string GetTypeText(List<Guardian> guardians, List<Payment> payments)
    {
        var getQtdPayments = GetPercent(guardians, payments);
        var getQtdPaymentsLastMonth = GetPercentLastMonth(guardians, payments);
        var compare = CompareCurrentMonthWithLastMonth(getQtdPayments, getQtdPaymentsLastMonth);
        return GetTyText(compare);
    }

    private string GetTyText(bool compare) => compare ? "success" : "danger";


    public string GetArrow(List<Guardian> guardians, List<Payment> payments)
    {
        var getQtdPayments = GetPercent(guardians, payments);
        var getQtdPaymentsLastMonth = GetPercentLastMonth(guardians, payments);
        var compare = CompareCurrentMonthWithLastMonth(getQtdPayments, getQtdPaymentsLastMonth);
        return GetArrow(compare);
    }
    private string GetArrow(bool compare) => compare ? "up" : "down";


}
