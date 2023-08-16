using SpendRegister.Models;

namespace SpendRegister.Services
{
    public interface ISpendService 
    {
        Task<List<Spend>> GetSpends();

        Task SaveSpends(List<Spend> spends);
    }
}
