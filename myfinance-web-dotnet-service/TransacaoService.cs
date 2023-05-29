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
	void ITransactionService.Cadastrar(Transaction Entidade)
	{
	  var dbSet = _dbContext.Transaction;
	  if (dbSet == null)
	  {
		throw new FileLoadException();
	  }
	  if (Entidade.Id == null)
	  {
		dbSet.Add(Entidade);
		_dbContext.SaveChanges();
		return;
	  }

	  dbSet.Attach(Entidade);
	  _dbContext.Entry(Entidade).State = EntityState.Modified;
	  _dbContext.SaveChanges();
	}

	void ITransactionService.Excluir(int Id)
	{
	  var transaction = new Transaction() { Id = Id };
	  _dbContext.Attach(transaction);
	  _dbContext.Remove(transaction);
	  _dbContext.SaveChanges();
	}

	List<Transaction> ITransactionService.ListarRegistros()
	{
	  var dbSet = _dbContext.Transaction;
	  if (dbSet == null)
	  {
		throw new FileLoadException();
	  }
	  return dbSet.ToList();
	}

	Transaction ITransactionService.RetornarRegistro(int Id)
	{
	  //var Transaction = _dbContext.Transaction.Where(x => x.Id == Id).First();
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