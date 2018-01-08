<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="purchases_returns_manage.aspx.cs" Inherits="Invoicing_T.purchases_returns_manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <form runat="server">
            <h1>退貨單查詢</h1>
            <asp:Label ID="Label3" runat="server" Text="請以退貨單編號查詢："></asp:Label>
            <asp:TextBox ID="InputPurchasesReturns" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="查詢"  OnClick="btn_search" />
            <asp:Button ID="btn_insert_purchases_returns" class="btn btn-primary" runat="server" Text="新增" OnClick="btn_insert_purchases_returns_Click" />

            <h1>總覽</h1>
            <div>
                <asp:ListView ID="IvPurchasesReturnsInfo" runat="server" GroupItemCount="1"
                    GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr class="success">
                                    <th width="25%">
                                        <asp:Label ID="Label8" runat="server" Text="檢視"></asp:Label></th>
                                    <th width="25%">
                                        <asp:Label ID="Label10" runat="server" Text="退貨單編號"></asp:Label></th>
                                    <th width="25%">
                                        <asp:Label ID="Label14" runat="server" Text="進貨單來源"></asp:Label></th>
                                    <th width="25%">
                                        <asp:Label ID="Label5" runat="server" Text="業務員編號"></asp:Label></th>
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
                                <asp:LinkButton ID="lbtnUpdate" runat="server" class="btn btn-danger btn-sm" PostBackUrl='<%# "purchases_returns_edit.aspx?ActionState=UpDate&pr_id="+Eval("pr_id")%>' ToolTip="修改">
                                    <asp:Label ID="Label7" runat="server" Text="檢視"></asp:Label>
                                </asp:LinkButton>
                            </td>
                            
                            <td><%# Eval("pr_id") %></td>
                            <td><%# Eval("pur_id") %></td>
                            <td><%# Eval("m_id") %></td>
                            
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </form>
    </main>
</asp:Content>
