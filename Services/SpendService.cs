using Blazored.LocalStorage;
using SpendRegister.Models;
using System.Text.Json;

namespace SpendRegister.Services
{
    public class SpendService : ISpendService
    {
        private readonly ILocalStorageService _storageService;

        public SpendService(ILocalStorageService storageService) 
        { 
            this._storageService = storageService;
        }

        private string spendsLocalStorageKey => "spendKey";

        public async Task<List<Spend>> GetSpends()
        {
            var spendsJson = await _storageService.GetItemAsync<string>(spendsLocalStorageKey);
            if (string.IsNullOrEmpty(spendsJson))
            {
                return new();
            }
            return JsonSerializer.Deserialize<List<Spend>>(spendsJson);
        }

        public async Task SaveSpends(List<Spend> spends)
        {
            var spendsJson = JsonSerializer.Serialize(spends);

            await _storageService.SetItemAsync(spendsLocalStorageKey, spendsJson);
        }
    }
}
