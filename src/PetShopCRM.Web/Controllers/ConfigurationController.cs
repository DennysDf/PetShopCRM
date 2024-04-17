using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Web.Models.Configuration;
using PetShopCRM.Web.Services.Interfaces;

namespace PetShopCRM.Web.Controllers
{
    [Authorize(policy: nameof(UserType.Admin))]
    public class ConfigurationController(
        IConfigurationService configurationService,
        INotificationService notificationService,
        ILoggedUserService loggedUserService,
        IPaymentService paymentService) : Controller
    {
        public IActionResult Index()
        {
            var configurations = configurationService.GetAll();

            var model = ConfigurationVM.ListDtoToListVM(configurations);

            LoadViewBags();

            return View(model);
        }

        [HttpPost]
        public async Task Save(ConfigurationKey key, string value)
        {
            var response = await configurationService.AddOrUpdateAsync(key, value);

            if (response.Success)
                notificationService.Send(NotificationType.Information, response.Message, loggedUserService.Id);
            else
                notificationService.Send(NotificationType.Error, response.Message, loggedUserService.Id);
        }

        private void LoadViewBags()
        {
            ViewBag.PagarMeUrlWebhook = paymentService.GenerateWebhookUrl($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}");
        }
    }
}
