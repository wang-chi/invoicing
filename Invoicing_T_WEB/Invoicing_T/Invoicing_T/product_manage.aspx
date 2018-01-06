<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="product_manage.aspx.cs" Inherits="Invoicing_T.product_manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <form runat="server">
            <h1>商品資料</h1>

            <div>
                <asp:Label ID="Label3" runat="server" Text="請以商品ID查詢："></asp:Label>
                <asp:TextBox ID="InputProductID" runat="server" aria-label="Search"></asp:TextBox>
                <asp:Button ID="btn_search" class="btn btn-success" runat="server" Text="查詢" OnClick="btn_search_Click" />
                <asp:Button ID="btn_insert_product" class="btn btn-primary" runat="server" Text="新增" OnClick="btn_insert_product_Click" />
            </div>
            <h1>總覽</h1>
            <div>
                <asp:ListView ID="lvproductInfo" runat="server" GroupItemCount="1" GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr class="success">
                                    <th width="10%">
                                        <asp:Label ID="Label2" runat="server" Text="編輯"></asp:Label></th>
                                    <th width="10%">
                                        <asp:Label ID="Label4" runat="server" Text="刪除"></asp:Label></th>
                                    <th width="20%">
                                        <asp:Label ID="Label10" runat="server" Text="商品ID"></asp:Label></th>

                                    <th width="20%">
                                        <asp:Label ID="Label27" runat="server" Text="商品分類ID"></asp:Label></th>
                                    <th width="40%">
                                        <asp:Label ID="Label1" runat="server" Text="商品名稱"></asp:Label></th>


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
                                <asp:LinkButton ID="lbtnUpdate" runat="server" CssClass="btn btn-danger btn-sm" PostBackUrl='<%# "product_edit.aspx?ActionState=UpDate&p_id="+Eval("p_id")%>' ToolTip="修改">
                                    <asp:Label ID="Label7" runat="server" Text="修改"></asp:Label>
                                </asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-danger btn-sm" PostBackUrl='<%# "product_edit.aspx?ActionState=Delete&p_id="+Eval("p_id")%>' ToolTip="刪除">
                                    <asp:Label ID="Label5" runat="server" Text="刪除"></asp:Label>
                                </asp:LinkButton>
                            </td>

                            <td>
                                <asp:Label ID="p_id" runat="server" Text='<%# Eval("p_id") %>'></asp:Label></td>

                            <td><%# Eval("pt_id") %></td>
                            <td><%# Eval("p_name") %></td>

                        </tr>
                    </ItemTemplate>
                </asp:ListView>

            </div>
        </form>
    </main>

</asp:Content>

