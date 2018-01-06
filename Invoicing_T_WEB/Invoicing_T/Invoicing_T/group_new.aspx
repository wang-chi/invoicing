<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="false" CodeBehind="group_new.aspx.cs" Inherits="Invoicing_T.group_new" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>群組資料修改</h1>
        <form id="form1" runat="server">
            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="群組帳號" />
                <asp:Label ID="Id" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="Label12" runat="server" Text="已有此群組帳號" Visible="false" Font-Size="9pt" ForeColor="Red" />
            </div>
            <div class="form-group">
                <asp:Label ID="Label11" runat="server" Text="群組名稱"></asp:Label>
                <asp:TextBox ID="InputName" runat="server" Width="150px"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="*資料要填寫齊全" Visible="false" Font-Size="9pt" ForeColor="Red"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="新增群組" OnClick="btn_insert_group" Font-Size="12pt" Height="30px" Width="94px" />
            </div>
        </form>
    </main>
</asp:Content>
