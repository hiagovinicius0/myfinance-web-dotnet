using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra.Interfaces.Base;

namespace myfinance_web_dotnet_infra.Interfaces
{
  public interface ITransactionRepository : IRepository<Transaction>
  {
	public List<Transaction> ListAllTransactions();
  }
}