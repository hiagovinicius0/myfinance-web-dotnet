using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_domain.Models;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet.Controllers
{
  [Route("[controller]")]
  public class TransactionController : Controller
  {
	private readonly ILogger<TransactionController> _logger;
	private readonly ITransactionService _transactionService;
	private readonly IPlanAccountService _planAccountService;

	public TransactionController(
		ILogger<TransactionController> logger,
		ITransactionService transactionService,
		IPlanAccountService planAccountService
	)
	{
	  _logger = logger;
	  _transactionService = transactionService;
	  _planAccountService = planAccountService;
	}

	[HttpGet]
	[Route("Index")]
	public IActionResult Index()
	{
	  var listTransactions = _transactionService.ListAll();
	  List<TransactionModel> listTransactionModel = new List<TransactionModel>();
	  foreach (var item in listTransactions)
	  {
		var itemTransaction = new TransactionModel()
		{
		  Id = item.Id,
		  Date = item.Date,
		  History = item.History,
		  PlanAccountId = item.PlanAccountId,
		  Value = item.Value,
		  Type = item.PlanAccount!.Type,
		};
		listTransactionModel.Add(itemTransaction);
	  }
	  return View(listTransactionModel);
	}

	[HttpGet]
	[Route("Create")]
	[Route("Create/{Id}")]
	public IActionResult Create(int? Id)
	{
	  var listPlanAccount = new SelectList(_planAccountService.ListAll(), "Id", "Description");
	  if (Id == null)
	  {
		var transactionModelVoid = new TransactionModel()
		{
		  Date = DateTime.UtcNow,
		  ListPlanAccount = listPlanAccount
		};

		return View(transactionModelVoid);
	  }

	  var transaction = _transactionService.ListOne((int)Id);

	  return View(new TransactionModel()
	  {
		Id = transaction.Id,
		Date = transaction.Date,
		History = transaction.History,
		PlanAccountId = transaction.PlanAccountId,
		Value = transaction.Value,
		ListPlanAccount = listPlanAccount
	  });
	}

	[HttpPost]
	[Route("Create")]
	[Route("Create/{Id}")]
	public IActionResult Create(TransactionModel model)
	{
	  _transactionService.Upsert(new Transaction()
	  {
		Id = model.Id,
		Date = model.Date,
		History = model.History,
		PlanAccountId = model.PlanAccountId,
		Value = model.Value,
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
	  _transactionService.Delete((int)Id);
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