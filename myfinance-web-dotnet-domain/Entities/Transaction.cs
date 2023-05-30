using System.ComponentModel.DataAnnotations.Schema;
using myfinance_web_dotnet_domain.Entities.Base;

namespace myfinance_web_dotnet_domain.Entities;
[Table("transaction")]
public class Transaction : EntityBase
{
  [Column("history")]
  public string? History { get; set; }

  [Column("date")]
  public DateTime Date { get; set; }

  [Column("value")]
  public decimal Value { get; set; }

  [Column("planaccountid")]
  public int PlanAccountId { get; set; }

  public PlanAccount? PlanAccount { get; set; }
}
