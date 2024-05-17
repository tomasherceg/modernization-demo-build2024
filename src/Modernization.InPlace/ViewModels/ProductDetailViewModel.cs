using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using Modernization.BackendClient;
using Modernization.BackendClient.Model;

namespace Modernization.InPlace.ViewModels
{
    public class ProductDetailViewModel(ApiClient apiClient) : SiteViewModel
    {

        [FromRoute("id")]
        public Guid Id { get; set; }

        public ProductModel Product { get; set; }

        public string ProductPrice { get; set; }

        public override async Task PreRender()
        {
            if (!Context.IsPostBack)
            {
                Product = await apiClient.GetProductAsync(Id);
                ProductPrice = Utils.GetProductPriceWithCaching(Id, SelectedCurrency);
            }

            await base.PreRender();
        }
    }
}

