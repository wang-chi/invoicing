<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="product_type_edit.aspx.cs" Inherits="Invoicing_T.product_type_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>商品類別資料修改</h1>

        <form id="form1" runat="server">
            <asp:HiddenField ID="HiddenF_ActionState" runat="server" />
            <asp:HiddenField ID="HiddenF_rid" runat="server" />
            <div class="form-group">
                <label>商品類別ID：</label>
                <asp:Label ID="pt_id" runat="server" Text='<%# Eval("pt_id") %>' />
            </div>
            <div class="form-group">
                <label>商品類別名稱：</label>
                <asp:TextBox ID="pt_name" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnUpdate" class="btn btn-danger" runat="server" Text="修改" OnClick="btn_Click" Visible="false" />
                <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" Text="刪除" OnClick="btn_Click" Visible="false" />
            </div>
        </form>
    </main>

</asp:Content>
