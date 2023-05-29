using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet_service.Interfaces
{
  public interface IPlanAccountService
  {
	void Upsert(PlanAccount Entidade);
	void Delete(int Id);
	List<PlanAccount> ListAll();
	PlanAccount ListOne(int Id);
  }
}