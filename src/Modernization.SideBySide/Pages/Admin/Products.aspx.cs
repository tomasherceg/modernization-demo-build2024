using Modernization.BackendClient.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Modernization.SideBySide.Admin
{
    public partial class Products : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<ProductModel> GetData(int? startRowIndex, int? maximumRows, out int totalRowCount)
        {
            var pageIndex = (startRowIndex / maximumRows) ?? 0;
            var products = Global.GetApiClient().GetProducts(pageIndex, maximumRows ?? 10);
            totalRowCount = products.TotalRecordCount;
            return products.Results;
        }

        protected void ProductsGrid_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var productId = ((ProductModel)e.Row.DataItem).Id;

                if (e.Row.DataItemIndex == ProductsGrid.EditIndex)
                {
                    var price = Global.GetApiClient().GetProductPrice(productId, SelectedCurrency);
                    ((TextBox)e.Row.FindControl("PriceTextBox")).Text = price?.ToString("n2");
                }
                else
                {
                    var productPrice = Utils.GetProductPriceWithCaching(productId, SelectedCurrency);
                    ((Literal)e.Row.FindControl("PriceLiteral")).Text = productPrice;
                }
            }
        }

        protected void ProductsGrid_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var priceTextBox = (TextBox)ProductsGrid.Rows[e.RowIndex].FindControl("PriceTextBox");
            if (!decimal.TryParse(priceTextBox.Text, out var price))
            {
                e.Cancel = true;
            }
        }

        public void UpdateProductPrice(Guid id)
        {
            var priceTextBox = (TextBox)ProductsGrid.Rows[ProductsGrid.EditIndex].FindControl("PriceTextBox");
            var price = decimal.Parse(priceTextBox.Text);
            Global.GetApiClient().UpdateProductPrice(id, SelectedCurrency, price);
            Utils.ResetProductPriceWithCache(id, SelectedCurrency);
        }
    }
}