<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="false" CodeBehind="HomePage.aspx.cs" Inherits="Invoicing_T.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>員工資料新增</h1>

        <form id="form1" runat="server">
            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="員工編號"></asp:Label>
                <asp:TextBox ID="InputID" runat="server" Width="150px"></asp:TextBox>
                <asp:Label ID="Msg_ExistID" runat="server" Text="帳號已存在" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="Label11" runat="server" Text="員工密碼"></asp:Label>
                <asp:TextBox ID="InputPWD" runat="server" Width="150px" MaxLength="12"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label12" runat="server" Text="員工狀態"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="True">啟用　</asp:ListItem>
                    <asp:ListItem Selected="True" Value="False">停權　</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="姓　　名"></asp:Label>
                <asp:TextBox ID="InputName" runat="server" Width="150px"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label7" runat="server" Text="性　　別"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="m">男　</asp:ListItem>
                    <asp:ListItem Selected="True" Value="f">女　</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="角　　色"></asp:Label>
                <asp:DropDownList ID="ddlGroup" runat="server" ToolTip="群組選項"></asp:DropDownList>

            </div>
            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="電話號碼"></asp:Label>
                <asp:TextBox ID="InputPhone" runat="server" Width="150px" MaxLength="10"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label10" runat="server" Text="電子信箱"></asp:Label>
                <asp:TextBox ID="InputEmail" runat="server" Width="150px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="InputEmail" Display="Dynamic" ErrorMessage="電子郵件地址的格式錯誤。" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="AllValidators" Font-Size="9pt" ForeColor="Red">無效的格式！</asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:Label ID="Label13" runat="server" Text="*有資料未填寫" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
            </div>
            <div style="margin: auto">
                <asp:Button ID="Button3" class="btn btn-success" runat="server" Text="新增員工" OnClick="btn_insert_member" ValidationGroup="AllValidators" />
            </div>

        </form>



    </main>

</asp:Content>
