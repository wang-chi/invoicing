<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="member_edit.aspx.cs" Inherits="Invoicing_T.member_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="dashboard.css" rel="stylesheet" />
    <link href="table.css" rel="stylesheet" />
    <title></title>
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
                        <a class="nav-link" href="HomePage.aspx">Home <span class="sr-only">Home</span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="member_manage.aspx">帳號管理 <span class="sr-only">(current)</span></a>
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
                        <a class="nav-link " href="HomePage.aspx">Overview </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="member_manage.aspx">帳號管理<span class="sr-only">(current)</span></a>
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
                        <a class="nav-link" href="supplier_manage.aspx">廠商管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="client_manage.aspx">客戶管理<span class="sr-only">(current)</span></a>
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
                <h1>員工資料修改</h1>
                <div>
                    <form id="form1" runat="server">
                        <div>
                            <asp:HiddenField ID="HiddenF_ActionState" runat="server" />
                            <asp:HiddenField ID="HiddenF_mid" runat="server" />
                            <div class="form-group">
                                用戶ID：<asp:Label ID="m_id" runat="server" Text='<%# Eval("m_id") %>' />
                            </div>
                            <div class="form-group">
                                用戶密碼：<asp:Label ID="m_pwd" runat="server" Text='<%# Eval("m_pwd") %>' />
                            </div>
                            <div class="form-group">
                                用戶狀態：<asp:Label ID="m_state" runat="server" Text='<%# Eval("m_state") %>' />
                            </div>
                            <div class="form-group">
                                用戶名稱：<asp:Label ID="m_name" runat="server" Text='<%# Eval("m_name") %>' />
                            </div>
                            <div class="form-group">
                                用戶性別：<asp:Label ID="m_sex" runat="server" Text='<%# Eval("m_sex") %>' />
                            </div>
                            <div class="form-group">
                                角色編號：<asp:Label ID="r_id" runat="server" Text='<%# Eval("r_id") %>' />
                            </div>
                            <div class="form-group">
                                員工電話：<asp:Label ID="m_phone" runat="server" Text='<%# Eval("m_phone") %>' />
                            </div>
                            <div class="form-group">
                                用戶信箱：<asp:Label ID="m_email" runat="server" Text='<%# Eval("m_email") %>' />
                            </div>
                            <div class="form-group">
                                <asp:Button ID="bt_position" class="btn" runat="server" Text="更改狀態為" OnClick="btn_position_check" />
                            </div>

                        </div>
                    </form>
                </div>
            </main>
        </div>
    </div>
</body>
</html>
