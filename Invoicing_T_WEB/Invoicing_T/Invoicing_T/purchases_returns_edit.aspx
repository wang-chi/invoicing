<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="purchases_returns_edit.aspx.cs" Inherits="Invoicing_T.purchases_returns_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>檢視退貨單</h1>
        <form id="form1" runat="server">
             <asp:HiddenField ID="HiddenF_ActionState" runat="server" />
            <asp:HiddenField ID="HiddenF_rid" runat="server" />
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
                    <asp:Label ID="pur_id" runat="server" Text="Label"></asp:Label>
                </div>
            </div>

            <div class="form-group row">
                <div>

                    <asp:Label ID="Label3" runat="server" Text="業務員編號："></asp:Label>
                    
                </div>
                 <div>
                    <asp:Label ID="mid" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <!--單身 -->

            <div>
                 <asp:ListView ID="lvPReturnsInfoinfo" runat="server" GroupItemCount="1"
                    GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder">
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
                                <%# Eval("p_id") %>
                                
                            </td>
                            <td>
                                <%# Eval("p_name") %>
                            </td>
                            <td>
                                <%# Eval("purin_qty") %>
                            </td>
                             <td>
                                <%# Eval("prin_qty") %>
                            </td>

                        </tr>
                    </ItemTemplate>
                </asp:ListView>
                </div>
           
        </form>

    </main>

</asp:Content>
