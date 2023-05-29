using System.ComponentModel.DataAnnotations.Schema;

namespace myfinance_web_dotnet_domain.Entities;

[Table("planaccount")]
public class PlanAccount
{
	[System.ComponentModel.DataAnnotations.Key]
	[Column("id")]
	public int? Id { get; set; }

	[Column("description")]
	public string? Description { get; set; }

	[Column("type")]
	public string? Type { get; set; }
}
