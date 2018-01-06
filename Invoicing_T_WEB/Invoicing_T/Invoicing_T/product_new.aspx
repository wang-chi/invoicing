<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="product_new.aspx.cs" Inherits="Invoicing_T.product_new" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>商品資料新增</h1>
        <div>
            <form id="form1" runat="server">
                <div class="form-group">
                    <asp:Label ID="Label6" runat="server" Text="商品編號"></asp:Label>
                    <asp:TextBox ID="InputID" runat="server" Width="150px" MaxLength="5"></asp:TextBox>
                    <asp:Label ID="Msg_ExistID" runat="server" Text="編號已存在" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="商品類別編號"></asp:Label>
                    <asp:TextBox ID="InputTypeID" runat="server" Width="150px" MaxLength="5"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="商品名稱"></asp:Label>
                    <asp:TextBox ID="InputName" runat="server" Width="150px" MaxLength="20"></asp:TextBox>
                </div>

                <div>
                    <asp:Label ID="Label13" runat="server" Text="*有資料未填寫" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
                </div>

                <div style="margin: auto">
                    <asp:Button ID="btn_insert_product" class="btn btn-success" runat="server" Text="新增商品" ValidationGroup="AllValidators" OnClick="btn_insert_product_Click" />
                </div>

            </form>

        </div>

    </main>

</asp:Content>

