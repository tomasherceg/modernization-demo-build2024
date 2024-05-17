using Microsoft.Extensions.Caching.Memory;
using Modernization.BackendClient;

namespace Modernization.SideBySide.New.Services
{
    public class ProductPriceCacheService(IMemoryCache cache, ApiClient apiClient)
    {
        public Task<string?> GetProductPriceWithCaching(Guid productId, string selectedCurrency)
        {
            var cacheKey = $"ProductPrice_{selectedCurrency}_{productId}";

            return cache.GetOrCreateAsync(cacheKey, async e =>
            {
                e.SlidingExpiration = TimeSpan.FromMinutes(5);

                var price = await apiClient.GetProductPriceAsync(productId, selectedCurrency);
                return price != null ? $"{price} {selectedCurrency}" : "Price unavailable";
            });
        }
    }
}
