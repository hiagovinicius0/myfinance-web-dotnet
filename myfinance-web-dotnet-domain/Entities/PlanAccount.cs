using System.ComponentModel.DataAnnotations.Schema;
using myfinance_web_dotnet_domain.Entities.Base;

namespace myfinance_web_dotnet_domain.Entities;

[Table("planaccount")]
public class PlanAccount : EntityBase
{
  [Column("description")]
  public string? Description { get; set; }

  [Column("type")]
  public string? Type { get; set; }
}
