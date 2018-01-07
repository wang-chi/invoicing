<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="supplier_new.aspx.cs" Inherits="Invoicing_T.supplier_new" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>廠商資料新增</h1>
        <div>
            <form id="form1" runat="server">
                <div class="form-group row">
                    <div>
                        <asp:Label ID="Label6" runat="server" Text="廠商編號"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="Id" runat="server" Text="Label"></asp:Label>
                    </div>
                    <asp:Label ID="Msg_ExistID" runat="server" Text="編號已存在" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
                </div>
                <div class="form-group row">
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="廠商名稱"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="InputName" class="form-control" runat="server" Width="150px" MaxLength="20"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div>
                        <asp:Label ID="Label5" runat="server" Text="廠商電話"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="InputPhone" class="form-control" runat="server" Width="150px" MaxLength="10"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div>
                        <asp:Label ID="Label3" runat="server" Text="廠商地址"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="InputAddress" class="form-control" runat="server" Width="150px" MaxLength="40"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div>
                        <asp:Label ID="Label10" runat="server" Text="廠商電子信箱"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="InputEmail" class="form-control" runat="server" Width="150px" MaxLength="40"></asp:TextBox>
                    </div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="InputEmail" Display="Dynamic" ErrorMessage="電子郵件地址的格式錯誤。" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="AllValidators" Font-Size="9pt" ForeColor="Red">無效的格式！</asp:RegularExpressionValidator>
                </div>
                <div>
                    <asp:Label ID="Label13" runat="server" Text="*有資料未填寫" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
                </div>

                <div style="margin: auto">
                    <asp:Button ID="Button3" class="btn btn-success" runat="server" Text="新增廠商" OnClick="btn_insert_supplier" ValidationGroup="AllValidators" />
                </div>

            </form>

        </div>

    </main>
</asp:Content>
