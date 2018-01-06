<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product_type_new.aspx.cs" Inherits="Invoicing_T.product_type_new" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增商品類別</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="dashboard.css" rel="stylesheet" />
    <link href="table.css" rel="stylesheet" />
</head>
<body>
    <%Response.WriteFile("header.html");%>
    <div class="container-fluid">
        <div class="row">
            <%Response.WriteFile("nav.aspx");%>
            <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
                <h1>商品類別資料新增</h1>
                <form id="form1" runat="server">
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="商品類別編號"></asp:Label>
                        <asp:TextBox ID="InputID" runat="server" Width="150px" MaxLength="5"></asp:TextBox>
                        <asp:Label ID="Msg_ExistID" runat="server" Text="編號已存在" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="商品類別名稱"></asp:Label>
                        <asp:TextBox ID="InputName" runat="server" Width="150px" MaxLength="20"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="Label13" runat="server" Text="*有資料未填寫" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
                    </div>
                    <div style="margin: auto">
                        <asp:Button ID="btn_insert_product_type" class="btn btn-success" runat="server" Text="新增商品類別" ValidationGroup="AllValidators" OnClick="btn_insert_product_type_Click" />
                    </div>
                </form>
            </main>
        </div>
    </div>
</body>
</html>
