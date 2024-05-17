<%@ Page Title="Contoso Shop Admin" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Modernization.SideBySide.Admin.Products" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2>Products</h2>
    
    <asp:GridView ID="ProductsGrid" runat="server"
                  SelectMethod="GetData"
                  UpdateMethod="UpdateProductPrice"
                  OnRowDataBound="ProductsGrid_OnRowDataBound"
                  OnRowUpdating="ProductsGrid_OnRowUpdating"
                  AutoGenerateColumns="False" 
                  DataKeyNames="Id"
                  AutoGenerateEditButton="true"
                  BorderStyle="NotSet"
                  CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="true" />
            <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="true" />
            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <asp:Literal ID="PriceLiteral" runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="PriceTextBox" runat="server" CssClass="form-control" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
</asp:Content>
