using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.JSInterop;

namespace Sakuri.Services
{
    public interface ILocalStorageService
    {
        Task<T> GetItem<T>(string key);
        Task SetItem<T>(string key, T value);
        Task RemoveItem<T>(string key);
    }
    public class LocalStorageService
    {
        private IJSRuntime _runtime;

        public LocalStorageService(IJSRuntime runtime)
        {
            _runtime = runtime;
        }

        public async Task<T> GetItem<T>(string key)
        {
            var json = await _runtime.InvokeAsync<string>("localstorage.getItem", key);
            if (json == null)
            {
                return default;
            }
            return JsonSerializer.Deserialize<T>(json);
        }
        public async Task SetItem<T>(string key, T value)
        {
            await _runtime.InvokeVoidAsync("localstorage.setItem", key, JsonSerializer.Serialize(value));
        }
        public async Task RemoveItem(string key)
        {
            await _runtime.InvokeVoidAsync("localstorage.removeItem", key);
        }

    }
}
