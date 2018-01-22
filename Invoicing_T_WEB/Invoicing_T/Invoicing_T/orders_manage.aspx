<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="orders_manage.aspx.cs" Inherits="Invoicing_T.order_manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <form runat="server">
            <h1>銷貨單查詢</h1>
            <asp:Label ID="Label3" runat="server" Text="請以銷貨單編號查詢："></asp:Label>
            <asp:TextBox ID="InputOrders" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="查詢" OnClick="btn_search" />
            <asp:Button ID="btn_insert_orders" class="btn btn-primary" runat="server" Text="新增" OnClick="btn_insert_orders_Click"/>

            <h1>總覽</h1>
            <div>
                <asp:ListView ID="IvOrdersInfo" runat="server" GroupItemCount="1"
                    GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr class="success">
                                    <th width="10%">
                                        <asp:Label ID="Label8" runat="server" Text="編輯"></asp:Label></th>
                                    <th width="10%">
                                        <asp:Label ID="Label1" runat="server" Text="刪除"></asp:Label></th>
                                    <th width="16%">
                                        <asp:Label ID="Label10" runat="server" Text="銷貨單編號"></asp:Label></th>
                                    <th width="16%">
                                        <asp:Label ID="Label14" runat="server" Text="客戶編號"></asp:Label></th>
                                    <th width="16%">
                                        <asp:Label ID="Label5" runat="server" Text="業務員編號"></asp:Label></th>
                                    <th width="16%">
                                        <asp:Label ID="Label6" runat="server" Text="是否已交貨"></asp:Label></th>
                                    <th width="16%">
                                        <asp:Label ID="Label4" runat="server" Text="交貨日"></asp:Label></th>

                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lbtnUpdate" runat="server" class="btn btn-danger btn-sm" PostBackUrl='<%# "orders_edit.aspx?ActionState=UpDate&or_id="+Eval("or_id")%>' ToolTip="修改">
                                    <asp:Label ID="Label7" runat="server" Text="修改"></asp:Label>
                                </asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-danger btn-sm" PostBackUrl='<%# "orders_edit.aspx?ActionState=Delete&or_id="+Eval("or_id")%>' ToolTip="刪除">
                                    <asp:Label ID="Label2" runat="server" Text="刪除"></asp:Label>
                                </asp:LinkButton>
                            </td>
                            <td><%# Eval("or_id") %></td>
                            <td><%# Eval("c_id") %></td>
                            <td><%# Eval("m_id") %></td>
                            <td><%# Eval("accept") %></td>
                            <td><%# Eval("deliverydate") %></td>

                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </form>
    </main>
</asp:Content>
