<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="client_new.aspx.cs" Inherits="Invoicing_T.client_new" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="dashboard.css" rel="stylesheet" />
    <link href="table.css" rel="stylesheet" />
</head>
<body>
    <header>
        <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
            <a class="navbar-brand" href="#">Dashboard</a>
            <button class="navbar-toggler d-lg-none" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarsExampleDefault">
                <ul class="navbar-nav mr-auto">
                    
                </ul>

            </div>
        </nav>
    </header>
    <div class="container-fluid">
        <div class="row">
            <nav class="col-sm-3 col-md-2 d-none d-sm-block bg-light sidebar">
                <ul class="nav nav-pills flex-column">
                    <li class="nav-item">
                        <a class="nav-link " href="HomePage.aspx">Overview </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="member_manage.aspx">帳號管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="group_manage.aspx">角色管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="auth_manage.aspx">權限管理</a>
                    </li>
                </ul>

                 <ul class="nav nav-pills flex-column">
                    <li class="nav-item">
                        <a class="nav-link" href="ManagePage.aspx">基本資料管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="company_manage.aspx">公司管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="client_manage.aspx">客戶管理</a>
                    </li>
                </ul>
                <ul class="nav nav-pills flex-column">
                    <li class="nav-item">
                        <a class="nav-link" href="ProductPage.aspx">商品資料管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="product_manage.aspx">商品管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="product_type_manage.aspx">類別管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="invoicing_manage.aspx">進貨管理</a>
                    </li>
                </ul>
            </nav>

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
        </div>
    </div>
</body>
</html>
