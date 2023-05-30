namespace myfinance_web_dotnet_infra.Interfaces.Base
{
  public interface IRepository<TEntity> where TEntity : class
  {
	void Upsert(TEntity entity);
	void Delete(int Id);
	List<TEntity> ListAll();
	TEntity ListOne(int Id);
  }
}