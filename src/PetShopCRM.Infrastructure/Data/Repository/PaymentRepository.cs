using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;

namespace PetShopCRM.Infrastructure.Data.Repository;

public class PaymentRepository(PetShopDbContext context) : RepositoryBase<Payment>(context), IPaymentRepository
{
}
