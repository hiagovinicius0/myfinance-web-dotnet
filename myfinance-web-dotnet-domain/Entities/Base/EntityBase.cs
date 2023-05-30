using System.ComponentModel.DataAnnotations.Schema;

namespace myfinance_web_dotnet_domain.Entities.Base
{
  public class EntityBase
  {
	[System.ComponentModel.DataAnnotations.Key]
	[Column("id")]
	public int? Id { get; set; }
  }
}