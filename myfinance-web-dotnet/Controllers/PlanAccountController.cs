using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet_domain.Models;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet.Controllers
{
  [Route("[controller]")]
  public class PlanAccountController : Controller
  {
	private readonly ILogger<PlanAccountController> _logger;
	private readonly IPlanAccountService _planAccountService;

	public PlanAccountController(ILogger<PlanAccountController> logger, IPlanAccountService planAccountService)
	{
	  _logger = logger;
	  _planAccountService = planAccountService;
	}

	[HttpGet]
	[Route("Index")]
	public IActionResult Index()
	{
	  var listPlanAccounts = _planAccountService.ListarRegistros();
	  List<PlanAccountViewModel> listPlanAccountModel = new List<PlanAccountViewModel>();
	  foreach (var item in listPlanAccounts)
	  {
		var itemPlanAccount = new PlanAccountViewModel()
		{
		  Id = item.Id,
		  Description = item.Description,
		  Type = item.Type
		};
		listPlanAccountModel.Add(itemPlanAccount);
	  }
	  return View(listPlanAccountModel);
	}

	public IActionResult Privacy()
	{
	  return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
	  return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
  }
}