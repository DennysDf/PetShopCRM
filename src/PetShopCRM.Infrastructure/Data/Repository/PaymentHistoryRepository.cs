using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;

namespace PetShopCRM.Infrastructure.Data.Repository;

public class PaymentHistoryRepository(PetShopDbContext context) : RepositoryBase<PaymentHistory>(context), IPaymentHistoryRepository
{
}
