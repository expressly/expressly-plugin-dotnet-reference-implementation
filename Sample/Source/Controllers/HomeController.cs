using System.Web.Mvc;
using Expressly.Api;
using Expressly.SDK.Sample.MVC.Models;

namespace Expressly.SDK.Sample.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly APIContext _expresslyApiContext;


        public HomeController()
        {
            _expresslyApiContext = ExpresslyPlugin.APIContext;
        }


        public ActionResult Index()
        {
            var model = new HomeViewModel();

            if (ExpresslyPlugin.Install())
            {
                model.merchantUuid = _expresslyApiContext.GetMerchantUuid();
                model.apiKey = _expresslyApiContext.GetApiKey();
            }


            return View(model);
        }


        [HttpGet]
        public ActionResult ShowMigrationPopup()
        {
            var model = new MigrationPopUpViewModel();

            if (ExpresslyPlugin.Install())
            {
                model.popUpHtml = ExpresslyProvider.build().GetPopupHtml(_expresslyApiContext, "c03b4bff-d810-4ff9-918c-ce52d4645780");
            }

            return PartialView("~/Views/Home/Partial/_MigrationPopup.cshtml", model);
        }


        [HttpGet]
        public ActionResult HandleMigrationPopup(string campaignCustomerUuid)
        {
            var model = new MigrationPopUpViewModel();

            if (ExpresslyPlugin.Install())
            {
                model.popUpHtml = ExpresslyProvider.build().GetPopupHtml(_expresslyApiContext, campaignCustomerUuid);
            }

            return PartialView("~/Views/Home/Partial/_MigrationPopup.cshtml", model);
        }



        [HttpGet]
        public ActionResult CustomerAlreadyExists(string email)
        {
            return View("~/Views/Home/CustomerAlreadyExists.cshtml", new CustomerAlreadyExistsViewModel { Message = "Customer already exists!" });
        }


        [HttpGet]
        public ActionResult Login(string customerUserReference)
        {
            return View("~/Views/Home/Landing.cshtml", new LandingViewModel { Message = "Customer " + customerUserReference + " successfully log in!" });
        }

    }
}