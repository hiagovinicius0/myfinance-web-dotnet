using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra.Interfaces;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service
{
  public class PlanAccountService : IPlanAccountService
  {
	private readonly IPlanAccountRepository _iPlanAccountRepository;
	public PlanAccountService(IPlanAccountRepository iPlanAccountRepository)
	{
	  _iPlanAccountRepository = iPlanAccountRepository;
	}

	public void Delete(int Id)
	{
	  _iPlanAccountRepository.Delete(Id);
	}

	public List<PlanAccount> ListAll()
	{
	  return _iPlanAccountRepository.ListAll();
	}

	public PlanAccount ListOne(int Id)
	{
	  return _iPlanAccountRepository.ListOne(Id);
	}

	public void Upsert(PlanAccount entity)
	{
	  _iPlanAccountRepository.Upsert(entity);
	}
  }
}