<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="false" CodeBehind="client_edit.aspx.cs" Inherits="Invoicing_T.client_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>客戶資料修改</h1>
        <form id="form1" runat="server">
            <asp:HiddenField ID="HiddenF_ActionState" runat="server" />
            <asp:HiddenField ID="HiddenF_rid" runat="server" />
            <div class="form-group">
                <label>客戶ID：</label>
                <asp:Label ID="c_id" runat="server" Text='<%# Eval("c_id") %>' />
            </div>
            <div class="form-group">
                <label>客戶名稱：</label>
                <asp:TextBox ID="c_name" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>客戶地址：</label>
                <asp:TextBox ID="c_address" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>客戶電話：</label>
                <asp:TextBox ID="c_phone" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>客戶電子信箱：</label>
                <asp:TextBox ID="c_email" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnUpdate" class="btn btn-danger" runat="server" Text="修改" OnClick="btn_Click" Visible="false" />
                <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" Text="刪除" OnClick="btn_Click" Visible="false" />
            </div>
        </form>
    </main>
</asp:Content>
