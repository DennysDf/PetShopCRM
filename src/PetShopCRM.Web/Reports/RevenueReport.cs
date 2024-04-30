using PetShopCRM.Domain.Models;

namespace PetShopCRM.Web.Reports;

public class RevenueReport
{
    private readonly DateTime dateLastMonth = DateTime.Now.AddMonths(-1);
    public double GetQtdPayments(List<Payment> payments) => (double)payments
            .Where(c => c.CreatedDate.Month == DateTime.Now.Month && c.CreatedDate.Year == DateTime.Now.Year)
            .Sum(c => c.HealthPlan.Value);

    private double GetQtdPaymentsLastMonth(List<Payment> payments) =>  (double)payments
            .Where(c => c.CreatedDate.Month == dateLastMonth.Month)
            .Sum(c => c.HealthPlan.Value);

    private bool CompareCurrentMonthWithLastMonth(double qtdPayments, double qtdPaymentsLastMonth) => qtdPayments > qtdPaymentsLastMonth;

    public string GetTypeText(List<Payment> payments)
    {
        var getQtdPayments = GetQtdPayments(payments);
        var getQtdPaymentsLastMonth = GetQtdPaymentsLastMonth(payments);
        var compare = CompareCurrentMonthWithLastMonth(getQtdPayments, getQtdPaymentsLastMonth);
        return GetTyText(compare);
    }

    private string GetTyText(bool compare) => compare ? "success" : "danger";


    public string GetArrow(List<Payment> payments)
    {
        var getQtdPayments = GetQtdPayments(payments);
        var getQtdPaymentsLastMonth = GetQtdPaymentsLastMonth(payments);
        var compare = CompareCurrentMonthWithLastMonth(getQtdPayments, getQtdPaymentsLastMonth);
        return GetArrow(compare);
    }
    private string GetArrow(bool compare) => compare ? "up" : "down";


    public double GetPercent(List<Payment> payments)
    {
        var getQtdPayments = GetQtdPayments(payments);
        var getQtdPaymentsLastMonth = GetQtdPaymentsLastMonth(payments);
        return GetPercent(getQtdPayments, getQtdPaymentsLastMonth);
    }

    private double GetPercent(double qtdPayments, double qtdPaymentsLastMonth) => Math.Round(((double)(qtdPayments - qtdPaymentsLastMonth) / qtdPaymentsLastMonth) * 100, 2);

    private double GetPercentMonthLast(double getQtdPaymentsLastMonth, double getQtdPaymentsLastMonth2) => Math.Round(((double)(getQtdPaymentsLastMonth - getQtdPaymentsLastMonth2) / getQtdPaymentsLastMonth2) * 100, 2);
}
