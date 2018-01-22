<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="supplier_price_manage.aspx.cs" Inherits="Invoicing_T.supplier_price_manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <form runat="server">
            <h1>進貨價格查詢</h1>
            <asp:Label ID="Label3" runat="server" Text="請以進貨單編號查詢："></asp:Label>
            <asp:TextBox ID="InputSupplier" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="查詢" OnClick="btn_search" />

            <h1>總覽</h1>
            <div>
                <asp:ListView ID="IvSupplierPriceInfo" runat="server" GroupItemCount="1"
                    GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr class="success">
                                    <th width="10%">
                                        <asp:Label ID="Label10" runat="server" Text="進貨價格編號"></asp:Label></th>
                                    <th width="10%">
                                        <asp:Label ID="Label14" runat="server" Text="商品編號"></asp:Label></th>
                                     <th width="20%">
                                        <asp:Label ID="Label1" runat="server" Text="商品名稱"></asp:Label></th>
                                    <th width="20%">
                                        <asp:Label ID="Label4" runat="server" Text="廠商名稱"></asp:Label></th>
                                    <th width="20%">
                                        <asp:Label ID="Label5" runat="server" Text="進貨價格"></asp:Label></th>
                                    <th width="20%">
                                        <asp:Label ID="Label6" runat="server" Text="進貨日期"></asp:Label></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("sp_id") %></td>
                            <td><%# Eval("p_id") %></td>
                            <td><%# Eval("p_name") %></td>
                            <td><%# Eval("s_name") %></td>
                            <td><%# Eval("price") %></td>
                            <td><%# Eval("createdate") %></td>

                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </form>
    </main>
</asp:Content>
