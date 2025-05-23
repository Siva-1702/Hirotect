using MortgageCalculator.Web.Repos;
using MortgageCalculator.Dto;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MortgageCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMortgageRepo mortgageRepo;

        public HomeController()
        {
            mortgageRepo = new MortgageRepo();
        }

        public ActionResult Index()
        {
            var activeMortgages = mortgageRepo.GetAllMortgages()
                .Where(m => m.EffectiveStartDate <= DateTime.Today && m.EffectiveEndDate >= DateTime.Today)
                .OrderBy(m => m.MortgageType)
                .ThenBy(m => m.InterestRepayment)
                .ToList();

            // Pass active mortgages to view
            ViewBag.ActiveMortgages = activeMortgages;

            // Pass mortgage types (enum) for autocomplete dropdown
            var mortgageTypes = Enum.GetNames(typeof(MortgageType));
            ViewBag.MortgageTypes = mortgageTypes;

            return View();
        }
    }
}
