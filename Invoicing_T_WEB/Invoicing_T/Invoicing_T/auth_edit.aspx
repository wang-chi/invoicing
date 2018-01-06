<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="auth_edit.aspx.cs" Inherits="Invoicing_T.auth_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>權限資料修改</h1>
        <form id="form1" runat="server">
            <asp:HiddenField ID="HiddenF_ActionState" runat="server" />
            <asp:HiddenField ID="HiddenF_rid" runat="server" />
            <div class="form-group row">
                <div>
                    <label class="label">權限ID：</label>
                </div>
                <div>
                    <asp:Label ID="a_id" runat="server" Text='<%# Eval("a_id") %>' />
                </div>
            </div>
            <div class="form-group row">
                <div>
                    <label class="label">權限名稱：</label>
                </div>
                <div>
                    <asp:TextBox ID="auth_name_input" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div>
                    <label class="label">權限頁面：</label>
                </div>
                <div>
                    <asp:TextBox ID="auth_page_input" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Button ID="btnUpdate" class="btn btn-danger" runat="server" Text="修改" OnClick="btn_Click" Visible="false" />
                <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" Text="刪除" OnClick="btn_Click" Visible="false" />
            </div>
        </form>
    </main>
</asp:Content>
