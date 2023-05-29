using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet_service.Interfaces
{
  public interface ITransactionService
  {
	void Cadastrar(Transaction Entidade);
	void Excluir(int Id);
	List<Transaction> ListarRegistros();
	Transaction RetornarRegistro(int Id);
  }
}