<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="member_new.aspx.cs" Inherits="Invoicing_T.member_new" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>員工資料新增</h1>

        <form id="form1" runat="server">
            <div class="form-group row">
                <div>
                    <asp:Label ID="Label6" class="label" runat="server" Text="員工編號"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="InputID" class="form-control" runat="server" Width="150px"></asp:TextBox>
                </div>
                <asp:Label ID="Msg_ExistID" runat="server" Text="帳號已存在" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
            </div>
            <div class="form-group row">
                <div>
                    <asp:Label ID="Label11" class="label" runat="server" Text="員工密碼"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="InputPWD" class="form-control" runat="server" Width="150px" MaxLength="12"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div>
                    <asp:Label ID="Label12" class="label" runat="server" Text="員工狀態"></asp:Label>
                </div>
                <div>
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="True">啟用</asp:ListItem>
                        <asp:ListItem Selected="True" Value="False">停權</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="form-group row">
                <div>
                    <asp:Label ID="Label1" class="label" runat="server" Text="姓　　名"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="InputName" class="form-control" runat="server" Width="150px"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div>
                    <asp:Label ID="Label7" class="label" runat="server" Text="性　　別"></asp:Label>
                </div>
                <div>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="m">男　</asp:ListItem>
                        <asp:ListItem Selected="True" Value="f">女　</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="form-group row">
                <div>
                    <asp:Label ID="Label2" class="label" runat="server" Text="角　　色"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="ddlGroup" class="form-control" runat="server" ToolTip="群組選項"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <div>
                    <asp:Label ID="Label5" class="label" runat="server" Text="電話號碼"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="InputPhone" class="form-control" runat="server" Width="150px" MaxLength="10"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div>
                    <asp:Label ID="Label10" class="label" runat="server" Text="電子信箱"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="InputEmail" class="form-control" runat="server" Width="150px"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="InputEmail" Display="Dynamic" ErrorMessage="電子郵件地址的格式錯誤。" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="AllValidators" Font-Size="9pt" ForeColor="Red">無效的格式！</asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:Label ID="Label13" runat="server" Text="*有資料未填寫" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
            </div>
            <div style="margin: auto">
                <asp:Button ID="Button3" class="btn btn-success" runat="server" Text="新增員工" OnClick="insert_member_Click" ValidationGroup="AllValidators" />

            </div>


        </form>



    </main>

</asp:Content>
