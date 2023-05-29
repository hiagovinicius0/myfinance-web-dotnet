using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service
{
  public class PlanAccountService : IPlanAccountService
  {
	private readonly MyFinanceDbContext _dbContext;
	public PlanAccountService(MyFinanceDbContext dbContext)
	{
	  _dbContext = dbContext;
	}
	void IPlanAccountService.Cadastrar(PlanAccount Entidade)
	{
	  var dbSet = _dbContext.PlanAccount;
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

	void IPlanAccountService.Excluir(int Id)
	{
	  var planAccount = new PlanAccount() { Id = Id };
	  _dbContext.Attach(planAccount);
	  _dbContext.Remove(planAccount);
	  _dbContext.SaveChanges();
	}

	List<PlanAccount> IPlanAccountService.ListarRegistros()
	{
	  var dbSet = _dbContext.PlanAccount;
	  if (dbSet == null)
	  {
		throw new FileLoadException();
	  }
	  return dbSet.ToList();
	}

	PlanAccount IPlanAccountService.RetornarRegistro(int Id)
	{
	  //var PlanAccount = _dbContext.PlanAccount.Where(x => x.Id == Id).First();
	  var dbSet = _dbContext.PlanAccount;
	  if (dbSet == null)
	  {
		throw new FileLoadException();
	  }
	  var planAccount = dbSet.Where(x => x.Id == Id).First();
	  if (planAccount == null)
	  {
		throw new KeyNotFoundException();
	  }
	  return planAccount;
	}
  }
}