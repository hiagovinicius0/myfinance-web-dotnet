using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra.Interfaces;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service
{
  public class TransactionService : ITransactionService
  {
	private readonly ITransactionRepository _iTransactionRepository;
	public TransactionService(ITransactionRepository iTransactionRepository)
	{
	  _iTransactionRepository = iTransactionRepository;
	}

	public void Delete(int Id)
	{
	  _iTransactionRepository.Delete(Id);
	}

	public List<Transaction> ListAll()
	{
	  return _iTransactionRepository.ListAllTransactions();
	}

	public List<Transaction> ListAllTransactions()
	{
	  throw new NotImplementedException();
	}

	public Transaction ListOne(int Id)
	{
	  return _iTransactionRepository.ListOne(Id);
	}

	public void Upsert(Transaction entity)
	{
	  _iTransactionRepository.Upsert(entity);
	}
  }
}