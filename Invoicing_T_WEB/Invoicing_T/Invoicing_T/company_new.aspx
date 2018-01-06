<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="company_new.aspx.cs" Inherits="Invoicing_T.company_new" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>公司資料新增</h1>
        <form id="form1" runat="server">
            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="公司帳號"></asp:Label>
                <asp:TextBox ID="InputID" runat="server" Width="150px"></asp:TextBox>
                <asp:Label ID="Msg_ExistID" runat="server" Text="帳號已存在" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="Label11" runat="server" Text="公司名稱"></asp:Label>
                <asp:TextBox ID="InputName" runat="server" Width="150px"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label13" runat="server" Text="*有資料未填寫" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
            </div>
            <div style="margin: auto">
                <asp:Button ID="Button3" class="btn btn-primary" runat="server" Text="新增分公司" OnClick="btn_insert_company" ValidationGroup="AllValidators" />
            </div>
        </form>
    </main>
</asp:Content>
