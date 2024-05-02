using PetShopCRM.Domain.Models;

namespace PetShopCRM.Web.Reports;

public class SalesReport
{
    private readonly DateTime dateLastMonth = DateTime.Now.AddMonths(-1);

    public int GetQtdPayments(List<Payment> payments) => payments
            .Where(c => c.CreatedDate.Month == DateTime.Now.Month && c.CreatedDate.Year == DateTime.Now.Year)
            .ToList().Count;

    private int GetQtdPaymentsLastMonth(List<Payment> payments) => payments
            .Where(c => c.CreatedDate.Month == dateLastMonth.Month)
            .ToList().Count;

    private bool CompareCurrentMonthWithLastMonth(int qtdPayments, int qtdPaymentsLastMonth) => qtdPayments > qtdPaymentsLastMonth;

    public string GetTypeText(List<Payment> payments)
    {
        var getQtdPayments = GetQtdPayments(payments);
        var getQtdPaymentsLastMonth = GetQtdPaymentsLastMonth(payments);
        var compare = CompareCurrentMonthWithLastMonth(getQtdPayments, getQtdPaymentsLastMonth);
        return GetTypeText(compare);
    }

    private string GetTypeText(bool compare) => compare ? "success" : "danger";


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
        if (getQtdPaymentsLastMonth == 0) return 100;
        return GetPercent(getQtdPayments, getQtdPaymentsLastMonth);
    }

    private double GetPercent(int qtdPayments, int qtdPaymentsLastMonth) => Math.Round(((double)(qtdPayments - qtdPaymentsLastMonth) / qtdPaymentsLastMonth) * 100, 2);
    private double GetPercentMonthLast(int qtdPayments, int qtdPaymentsLastMonth) => Math.Round(((double)(qtdPayments - qtdPaymentsLastMonth) / qtdPaymentsLastMonth) * 100, 2);
}
