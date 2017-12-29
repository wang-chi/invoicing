<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="auth_edit_new.aspx.cs" Inherits="Invoicing_T.auth_edit_new" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>新增權限</title>
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
                    <li class="nav-item active">
                        <a class="nav-link" href="home.aspx">Home <span class="sr-only">Home</span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="auth_manage.aspx">權限管理 <span class="sr-only">(current)</span></a>
                    </li>
                </ul>

            </div>
        </nav>
    </header>
    <div class="container-fluid">
        <div class="row">
            <nav class="col-sm-3 col-md-2 d-none d-sm-block bg-light sidebar">
                <ul class="nav nav-pills flex-column">
                    <li class="nav-item">
                        <a class="nav-link " href="home.aspx">Overview </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="id_manage.aspx">帳號管理<span class="sr-only">(current)</span></a>
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
                        <a class="nav-link" href="manage.aspx">基本資料管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="supplier_mange.aspx">廠商管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="client_manage.aspx">客戶管理</a>
                    </li>
                </ul>

                <ul class="nav nav-pills flex-column">
                    <li class="nav-item">
                        <a class="nav-link" href="product_manage.aspx">商品管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="product_type_manage.aspx">商品類別管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="invoicing_manage.aspx">進貨管理</a>
                    </li>
                </ul>
            </nav>

            <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
                <h1>權限資料新增</h1>
                <div>
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <asp:Label ID="Label6" runat="server" Text="權限帳號"></asp:Label>
                            <asp:TextBox ID="InputID" runat="server" Width="150px"></asp:TextBox>
                            <asp:Label ID="Msg_ExistID" runat="server" Text="帳號已存在" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label11" runat="server" Text="權限名稱"></asp:Label>
                            <asp:TextBox ID="InputName" runat="server" Width="150px"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="Label13" runat="server" Text="*有資料未填寫" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
                        </div>
                        <div style="margin: auto">
                            <asp:Button ID="Button3" class="btn" runat="server" Text="新增權限" OnClick="btn_insert_auth" ValidationGroup="AllValidators" />
                        </div>

                    </form>

                </div>

            </main>
        </div>
    </div>
</body>
</html>
