<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="product_new.aspx.cs" Inherits="Invoicing_T.product_new" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>商品資料新增</h1>
        <div>
            <form id="form1" runat="server">
                <div class="form-group row">
                    <asp:Label ID="Label6" runat="server" Text="商品編號"></asp:Label>
                    <asp:Label ID="InputID" runat="server" Text="P0001"></asp:Label>
                </div>
                <div class="form-group row">
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="商品類別"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="InputTypeID" runat="server" Width="150px" MaxLength="5" Visible="false"></asp:TextBox>
                        <asp:DropDownList ID="ddlProductTypeGroup" class="form-control" runat="server" ToolTip="群組選項"></asp:DropDownList>
                    </div>
                </div>

                <div class="form-group row">
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="商品名稱"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="InputName" runat="server" Width="150px" MaxLength="20"></asp:TextBox>
                    </div>
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

