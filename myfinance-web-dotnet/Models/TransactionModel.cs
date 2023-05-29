using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_dotnet_domain.Models;

public class TransactionModel
{
  public int? Id { get; set; }
  public string? History { get; set; }
  public DateTime Date { get; set; }
  public decimal Value { get; set; }
  public int PlanAccountId { get; set; }
  public string? Type { get; set; }
  public IEnumerable<SelectListItem>? ListPlanAccount { get; set; }
}
