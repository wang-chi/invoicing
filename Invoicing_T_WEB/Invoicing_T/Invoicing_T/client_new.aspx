<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="false" CodeBehind="client_new.aspx.cs" Inherits="Invoicing_T.client_new" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>客戶資料新增</h1>
        <div>
            <form id="form1" runat="server">
                <div class="form-group">
                    <asp:Label ID="Label6" runat="server" Text="客戶編號"></asp:Label>
                    <asp:TextBox ID="InputID" runat="server" Width="150px" MaxLength="5"></asp:TextBox>
                    <asp:Label ID="Msg_ExistID" runat="server" Text="編號已存在" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="客戶名稱"></asp:Label>
                    <asp:TextBox ID="InputName" runat="server" Width="150px" MaxLength="20"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="客戶電話"></asp:Label>
                    <asp:TextBox ID="InputPhone" runat="server" Width="150px" MaxLength="10"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="客戶地址"></asp:Label>
                    <asp:TextBox ID="InputAddress" runat="server" Width="150px" MaxLength="40"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label10" runat="server" Text="客戶電子信箱"></asp:Label>
                    <asp:TextBox ID="InputEmail" runat="server" Width="150px" MaxLength="40"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="InputEmail" Display="Dynamic" ErrorMessage="電子郵件地址的格式錯誤。" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="AllValidators" Font-Size="9pt" ForeColor="Red">無效的格式！</asp:RegularExpressionValidator>
                </div>
                <div>
                    <asp:Label ID="Label13" runat="server" Text="*有資料未填寫" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
                </div>
                <div style="margin: auto">
                    <asp:Button ID="Button3" class="btn btn-success" runat="server" Text="新增客戶" OnClick="btn_insert_client" ValidationGroup="AllValidators" />
                </div>
            </form>
        </div>
    </main>
</asp:Content>
