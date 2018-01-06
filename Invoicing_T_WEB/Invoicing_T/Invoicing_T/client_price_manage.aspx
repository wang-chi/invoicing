<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="client_price_manage.aspx.cs" Inherits="Invoicing_T.client_price_manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <form runat="server">
            <h1>銷貨價格查詢</h1>
            <asp:Label ID="Label3" runat="server" Text="請以銷貨單編號查詢："></asp:Label>
            <asp:TextBox ID="InputClientPrice" runat="server"></asp:TextBox>
            <asp:Button ID="btn_search_2" class="btn btn-success" runat="server" Text="查詢" OnClick="btn_search" />
            <h1>總覽</h1>
            <div>
                <asp:ListView ID="IvClientPriceInfo" runat="server" GroupItemCount="1"
                    GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr class="success">
                                    <th width="20%">
                                        <asp:Label ID="Label10" runat="server" Text="銷貨價格編號"></asp:Label></th>
                                    <th width="20%">
                                        <asp:Label ID="Label14" runat="server" Text="商品編號"></asp:Label></th>
                                    <th width="20%">
                                        <asp:Label ID="Label4" runat="server" Text="客戶編號"></asp:Label></th>
                                    <th width="20%">
                                        <asp:Label ID="Label5" runat="server" Text="銷貨價格"></asp:Label></th>
                                    <th width="20%">
                                        <asp:Label ID="Label6" runat="server" Text="銷貨日期"></asp:Label></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("cp_id") %></td>
                            <td><%# Eval("p_id") %></td>
                            <td><%# Eval("c_id") %></td>
                            <td><%# Eval("price") %></td>
                            <td><%# Eval("createdate") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </form>
    </main>
</asp:Content>