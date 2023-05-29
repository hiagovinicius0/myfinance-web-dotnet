using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet_service.Interfaces
{
  public interface IPlanAccountService
  {
	void Cadastrar(PlanAccount Entidade);
	void Excluir(int Id);
	List<PlanAccount> ListarRegistros();
	PlanAccount RetornarRegistro(int Id);
  }
}