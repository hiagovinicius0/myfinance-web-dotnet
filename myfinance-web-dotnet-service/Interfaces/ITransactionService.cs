using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet_service.Interfaces
{
  public interface ITransactionService
  {
	void Upsert(Transaction Entidade);
	void Delete(int Id);
	List<Transaction> ListAll();
	Transaction ListOne(int Id);
  }
}