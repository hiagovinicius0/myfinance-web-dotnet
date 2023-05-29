using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet_domain.Entities;
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
	  var listPlanAccounts = _planAccountService.ListAll();
	  List<PlanAccountModel> listPlanAccountModel = new List<PlanAccountModel>();
	  foreach (var item in listPlanAccounts)
	  {
		var itemPlanAccount = new PlanAccountModel()
		{
		  Id = item.Id,
		  Description = item.Description,
		  Type = item.Type
		};
		listPlanAccountModel.Add(itemPlanAccount);
	  }
	  return View(listPlanAccountModel);
	}

	[HttpGet]
	[Route("Create")]
	[Route("Create/{Id}")]
	public IActionResult Create(int? Id)
	{
	  if (Id == null)
	  {
		var planAccountModelVoid = new PlanAccountModel();

		return View(planAccountModelVoid);
	  }

	  var planAccount = _planAccountService.ListOne((int)Id);

	  return View(new PlanAccountModel()
	  {
		Description = planAccount.Description,
		Id = planAccount.Id,
		Type = planAccount.Type
	  });
	}

	[HttpPost]
	[Route("Create")]
	[Route("Create/{Id}")]
	public IActionResult Create(PlanAccountModel model)
	{
	  _planAccountService.Upsert(new PlanAccount()
	  {
		Id = model.Id,
		Description = model.Description,
		Type = model.Type
	  });
	  return RedirectToAction("Index");
	}

	[HttpGet]
	[Route("Delete/{Id}")]
	public IActionResult Delete(int? Id)
	{
	  if (Id == null)
	  {
		throw new KeyNotFoundException();
	  }
	  _planAccountService.Delete((int)Id);
	  return RedirectToAction("Index");
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