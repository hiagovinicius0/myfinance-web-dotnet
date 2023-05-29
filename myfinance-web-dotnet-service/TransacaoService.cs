using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service
{
  public class TransactionService : ITransactionService
  {
	private readonly MyFinanceDbContext _dbContext;
	public TransactionService(MyFinanceDbContext dbContext)
	{
	  _dbContext = dbContext;
	}
	void ITransactionService.Upsert(Transaction entity)
	{
	  var dbSet = _dbContext.Transaction;
	  if (dbSet == null)
	  {
		throw new FileLoadException();
	  }
	  if (entity.Id == null)
	  {
		dbSet.Add(entity);
		_dbContext.SaveChanges();
		return;
	  }

	  dbSet.Attach(entity);
	  _dbContext.Entry(entity).State = EntityState.Modified;
	  _dbContext.SaveChanges();
	}

	void ITransactionService.Delete(int Id)
	{
	  var transaction = new Transaction() { Id = Id };
	  _dbContext.Attach(transaction);
	  _dbContext.Remove(transaction);
	  _dbContext.SaveChanges();
	}

	List<Transaction> ITransactionService.ListAll()
	{
	  var dbSet = _dbContext.Transaction;
	  if (dbSet == null)
	  {
		throw new FileLoadException();
	  }
	  return dbSet.ToList();
	}

	Transaction ITransactionService.ListOne(int Id)
	{
	  var dbSet = _dbContext.Transaction;
	  if (dbSet == null)
	  {
		throw new FileLoadException();
	  }
	  var transaction = dbSet.Where(x => x.Id == Id).First();
	  if (transaction == null)
	  {
		throw new KeyNotFoundException();
	  }
	  return transaction;
	}
  }
}