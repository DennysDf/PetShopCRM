using PetShopCRM.Domain.Models;

namespace PetShopCRM.Web.Reports;

public class RevenueReport
{
    private readonly DateTime dateLastMonth = DateTime.Now.AddMonths(-1);
    public decimal GetQtdPayments(List<PaymentHistory> payments) => (decimal)payments
            .Where(c => c.CreatedDate.Month == DateTime.Now.Month && c.CreatedDate.Year == DateTime.Now.Year)
            .Sum(c => c.Value);

    private decimal GetQtdPaymentsLastMonth(List<PaymentHistory> payments) =>  (decimal)payments
            .Where(c => c.CreatedDate.Month == dateLastMonth.Month)
            .Sum(c => c.Value);

    private bool CompareCurrentMonthWithLastMonth(decimal qtdPayments, decimal qtdPaymentsLastMonth) => qtdPayments > qtdPaymentsLastMonth;

    public string GetTypeText(List<PaymentHistory> payments)
    {
        var getQtdPayments = GetQtdPayments(payments);
        var getQtdPaymentsLastMonth = GetQtdPaymentsLastMonth(payments);
        var compare = CompareCurrentMonthWithLastMonth(getQtdPayments, getQtdPaymentsLastMonth);
        return GetTyText(compare);
    }

    private string GetTyText(bool compare) => compare ? "success" : "danger";


    public string GetArrow(List<PaymentHistory> payments)
    {
        var getQtdPayments = GetQtdPayments(payments);
        var getQtdPaymentsLastMonth = GetQtdPaymentsLastMonth(payments);
        var compare = CompareCurrentMonthWithLastMonth(getQtdPayments, getQtdPaymentsLastMonth);
        return GetArrow(compare);
    }
    private string GetArrow(bool compare) => compare ? "up" : "down";


    public decimal GetPercent(List<PaymentHistory> payments)
    {
        var getQtdPayments = GetQtdPayments(payments);
        var getQtdPaymentsLastMonth = GetQtdPaymentsLastMonth(payments);
        if (getQtdPaymentsLastMonth == 0) return 100;
        return GetPercent(getQtdPayments, getQtdPaymentsLastMonth);
    }

    private decimal GetPercent(decimal qtdPayments, decimal qtdPaymentsLastMonth) => Math.Round(((decimal)(qtdPayments - qtdPaymentsLastMonth) / qtdPaymentsLastMonth) * 100, 2);

    private decimal GetPercentMonthLast(decimal getQtdPaymentsLastMonth, decimal getQtdPaymentsLastMonth2) => Math.Round(((decimal)(getQtdPaymentsLastMonth - getQtdPaymentsLastMonth2) / getQtdPaymentsLastMonth2) * 100, 2);
}
