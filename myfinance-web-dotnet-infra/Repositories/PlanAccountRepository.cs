using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra.Interfaces;

namespace myfinance_web_dotnet_infra.Repositories
{
  public class PlanAccountRepository : Repository<PlanAccount>, IPlanAccountRepository
  {
	public PlanAccountRepository(MyFinanceDbContext dbContext) : base(dbContext)
	{
	}
  }
}