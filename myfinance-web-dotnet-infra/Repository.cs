using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities.Base;
using myfinance_web_dotnet_infra.Interfaces.Base;

namespace myfinance_web_dotnet_infra
{
  public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
  {
	protected DbContext _dbContext;
	protected DbSet<TEntity> _dbSetContext;
	protected Repository(DbContext dbContext)
	{
	  _dbContext = dbContext;
	  _dbSetContext = _dbContext.Set<TEntity>();
	}
	public void Delete(int Id)
	{
	  var entity = new TEntity() { Id = Id };
	  _dbContext.Attach(entity);
	  _dbContext.Remove(entity);
	  _dbContext.SaveChanges();
	}

	public List<TEntity> ListAll()
	{
	  return _dbSetContext.ToList();
	}

	public TEntity ListOne(int Id)
	{
	  var dbSet = _dbSetContext;
	  if (dbSet == null)
	  {
		throw new FileLoadException();
	  }
	  var entity = dbSet.Where(x => x.Id == Id).First();
	  if (entity == null)
	  {
		throw new KeyNotFoundException();
	  }
	  return entity;
	}

	public void Upsert(TEntity entity)
	{
	  if (_dbSetContext == null)
	  {
		throw new FileLoadException();
	  }
	  if (entity.Id == null)
	  {
		_dbSetContext.Add(entity);
		_dbContext.SaveChanges();
		return;
	  }

	  _dbSetContext.Attach(entity);
	  _dbContext.Entry(entity).State = EntityState.Modified;
	  _dbContext.SaveChanges();
	}
  }
}