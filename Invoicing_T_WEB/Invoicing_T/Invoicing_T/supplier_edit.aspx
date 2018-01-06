<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="false" CodeBehind="supplier_edit.aspx.cs" Inherits="Invoicing_T.supplier_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>廠商資料修改</h1>

        <form id="form1" runat="server">
            <asp:HiddenField ID="HiddenF_ActionState" runat="server" />
            <asp:HiddenField ID="HiddenF_rid" runat="server" />
            <div class="form-group">
                <label>廠商ID：</label>
                <asp:Label ID="s_id" runat="server" Text='<%# Eval("s_id") %>' />
            </div>
            <div class="form-group">
                <label>廠商名稱：</label>
                <asp:TextBox ID="s_name" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>廠商地址：</label>
                <asp:TextBox ID="s_address" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>廠商地電話：</label>
                <asp:TextBox ID="s_phone" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>廠商電子信箱：</label>
                <asp:TextBox ID="s_email" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnUpdate" class="btn btn-danger" runat="server" Text="修改" OnClick="btn_Click" Visible="false" />
                <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" Text="刪除" OnClick="btn_Click" Visible="false" />
            </div>
        </form>
    </main>
</asp:Content>
