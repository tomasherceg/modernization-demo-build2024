using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Modernization.BackendClient.Model;

namespace Modernization.BackendClient
{
    public class ApiClient(HttpClient client)
    {

        public HttpClient HttpClient { get; } = client;


        public Task<PagedResponse<ProductModel>> GetProductsAsync(int skip, int take)
        {
            return HttpClient.GetFromJsonAsync<PagedResponse<ProductModel>>($"/products?skip={skip}&take={take}");
        }

        public PagedResponse<ProductModel> GetProducts(int skip, int take) => GetProductsAsync(skip, take).GetAwaiter().GetResult();
        
        public Task<ProductModel> GetProductAsync(Guid id)
        {
            return HttpClient.GetFromJsonAsync<ProductModel>($"/products/{id}");
        }

        public ProductModel GetProduct(Guid id) => GetProductAsync(id).GetAwaiter().GetResult();

        public Task<decimal?> GetProductPriceAsync(Guid id, string currency)
        {
            return HttpClient.GetFromJsonAsync<decimal?>($"/products/{id}/price/{currency}");
        }

        public decimal? GetProductPrice(Guid id, string currency) => GetProductPriceAsync(id, currency).GetAwaiter().GetResult();

        public Task UpdateProductPriceAsync(Guid id, string currency, decimal newPrice)
        {
            return HttpClient.PutAsJsonAsync($"/products/{id}/price/{currency}", newPrice);
        }

        public void UpdateProductPrice(Guid id, string currency, decimal newPrice) => UpdateProductPriceAsync(id, currency, newPrice).GetAwaiter().GetResult();
    }
}
