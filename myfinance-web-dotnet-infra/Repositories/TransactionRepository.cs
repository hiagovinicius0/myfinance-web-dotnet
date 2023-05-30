using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra.Interfaces;

namespace myfinance_web_dotnet_infra.Repositories
{
  public class TransactionRepository : Repository<Transaction>, ITransactionRepository
  {
	private new readonly MyFinanceDbContext _dbContext;
	public TransactionRepository(MyFinanceDbContext dbContext) : base(dbContext)
	{
	  _dbContext = dbContext;
	}
	public List<Transaction> ListAllTransactions()
	{
	  var dbSet = _dbContext.Transaction!.Include(x => x.PlanAccount);
	  if (dbSet == null)
	  {
		throw new FileLoadException();
	  }
	  return dbSet.ToList();
	}
  }
}