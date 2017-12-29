﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="employee_manage.aspx.cs" Inherits="Invoicing_T.employee_manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="dashboard.css" rel="stylesheet" />
    <link href="table.css" rel="stylesheet" />
    <title>員工管理</title>
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
                        <a class="nav-link" href="#">基本資料管理</a>
                    </li>
                        <li class="nav-item">
                        <a class="nav-link" href="company_manage.aspx">公司管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="supplier_manage.aspx">廠商管理</a>
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
                <h1>員工資料</h1>
                <div>
                    <form id="form1" runat="server">
                        <div>
                            <div class="form-group">
                                員工帳號：<asp:Label ID="com_id" runat="server" Text='<%# Eval("m_id") %>' />
                            </div>
                            <div class="form-group">
                                員工姓名：<asp:Label ID="com_name" runat="server" Text='<%# Eval("com_name") %>' />
                            </div>
                            <div class="form-group">
                                員工密碼：<asp:Label ID="com_address" runat="server" Text='<%# Eval("com_address") %>' />
                            </div>
                            <div class="form-group">
                                公司統一編號：<asp:Label ID="com_un" runat="server" Text='<%# Eval("com_un") %>' />
                            </div>
                            <div class="form-group">
                                公司負責人：<asp:Label ID="com_agent" runat="server" Text='<%# Eval("com_agent") %>' />
                            </div>
                            <div class="form-group">
                                公司電話：<asp:Label ID="com_tel" runat="server" Text='<%# Eval("com_tel") %>' />
                            </div>
                            <div class="form-group">
                                公司傳真號碼：<asp:Label ID="com_fax" runat="server" Text='<%# Eval("com_fax") %>' />
                            </div>

                            <div class="form-group">
                                <asp:Button ID="bt_company_edit" class="btn btn-success" runat="server" Text="編輯"  OnClick="bt_company_edit_Click" />
                            </div>

                        </div>
                    </form>
                </div>
            </main>
        </div>
    </div>
</body>
</html>