using PetShopCRM.Web.Models.Pet;

namespace PetShopCRM.Web.Models.Payment
{
    public class PaymentHistoryVM
    {
        public int PaymentId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string PlanName { get; set; }
        public string PetName { get; set; }
        public string GuardianName { get; set; }

        public static List<PaymentHistoryVM> ToList(List<Domain.Models.PaymentHistory> paymentHistories) => paymentHistories.Select(paymentHistory => new PaymentHistoryVM
        {
            PaymentId = paymentHistory.PaymentId,
            Description = paymentHistory.Event,
            Date = paymentHistory.CreatedDate,
            Value = paymentHistory.Value,
            PlanName = paymentHistory.Payment.HealthPlan.Name,
            PetName = paymentHistory.Payment.Pet.Name,
            GuardianName = paymentHistory.Payment.Guardian.Name
        }).ToList();
    }
}
