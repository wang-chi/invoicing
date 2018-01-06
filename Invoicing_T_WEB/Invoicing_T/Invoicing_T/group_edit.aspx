<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="group_edit.aspx.cs" Inherits="Invoicing_T.group_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>角色資料修改</h1>
        <form id="form1" runat="server">
            <asp:HiddenField ID="HiddenF_ActionState" runat="server" />
            <asp:HiddenField ID="HiddenF_rid" runat="server" />
            <div class="form-group">
                <label>群組ID：</label>
                <asp:Label ID="r_id" runat="server" Text='<%# Eval("r_id") %>' />
            </div>
            <div class="form-group">
                <label>群組名稱：</label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnUpdate" class="btn btn-success" runat="server" Text="修改" Visible="false" />
                <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" Text="刪除" Visible="false" />
            </div>
        </form>
    </main>
</asp:Content>
