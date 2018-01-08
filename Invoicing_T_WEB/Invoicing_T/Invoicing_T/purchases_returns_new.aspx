<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="purchases_returns_new.aspx.cs" Inherits="Invoicing_T.purchases_returns_new" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>新增退貨單</h1>
        <form id="form1" runat="server">

            <div class="form-group row">
                <div>
                    <asp:Label ID="Label1" runat="server" Text="退貨單編號："></asp:Label>
                </div>
                <div>
                    <asp:Label ID="prid" runat="server" Text="PR001"></asp:Label>
                </div>
               
            </div>
             <div class="form-group row">
                <div>
                    <asp:Label ID="Label5" runat="server" Text="進貨單來源編號："></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="ddlPurchasesReturns" class="form-control" runat="server" AutoPostBack="true"  ToolTip="群組選項"  OnSelectedIndexChanged="ddlPurchasesReturns_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <div>
                    <asp:Label ID="Label2" runat="server" Text="廠商編號："></asp:Label>
                </div>
                <div>
                    <asp:Label ID="Supplier" runat="server" Text="Label"></asp:Label>
                </div>
            </div>

            <div class="form-group row">
                <div>

                    <asp:Label ID="Label3" runat="server" Text="業務員編號："></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="InputMid" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

            <!--單身 -->

            <div>
                 <asp:ListView ID="lvPReturnsInfo" runat="server" GroupItemCount="1"
                    GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder" Visible="false">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr class="success">
                                    <th width="25%">
                                        <asp:Label ID="Label8" runat="server" Text="商品編號"></asp:Label></th>
                                    <th width="25%">
                                        <asp:Label ID="Label1" runat="server" Text="商品名稱"></asp:Label></th>
                                    <th width="25%">
                                        <asp:Label ID="Label10" runat="server" Text="商品進貨數量"></asp:Label></th>
                                    <th width="25%">
                                        <asp:Label ID="Label14" runat="server" Text="商品退貨數量"></asp:Label></th>
                                    

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
                                <asp:Label ID="pid" runat="server" Text='<%# Eval("p_id") %>' ></asp:Label>
                                <asp:Label ID="purinid" runat="server" Text='<%# Eval("purin_id") %>' Visible="false"></asp:Label>
                            </td>
                            <td>
                                <%# Eval("p_name") %>
                            </td>
                            <td>
                                <%# Eval("purin_qty") %>
                            </td>
                             <td>
                                <asp:TextBox ID="InputCheckQty" runat="server" Text=""></asp:TextBox>
                                 <asp:Label ID="check_id" runat="server" Text="退貨數量不可大於進貨數量" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
                            </td>

                        </tr>
                    </ItemTemplate>
                </asp:ListView>
                </div>
            <div class="form-group">
                    <asp:Button ID="btn_insert_purchases" CssClass="btn btn-primary" runat="server" Text="新增退貨單" OnClick="btn_insert_purchases_returns_Click" />
                </div>


        </form>

    </main>

</asp:Content>
