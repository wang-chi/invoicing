<!--
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nav.aspx.cs" Inherits="Invoicing_T.nav" %>
-->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <nav class="col-sm-3 col-md-2 d-none d-sm-block bg-light sidebar">
        <ul class="nav nav-pills flex-column">
            <li class="nav-item">
                <a id="HomePage" class="nav-link" href="HomePage.aspx" runat="server" visible="false">Overview</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="member_manage.aspx" runat="server" visible="false">帳號管理</a>
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
                <a class="nav-link" href="supplier_manage.aspx">廠商管理</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="client_manage.aspx">客戶管理</a>
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
                <a class="nav-link" href="purchases_manage.aspx">進貨單管理</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="supplier_price_manage.aspx">進貨價格</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="client_price_manage.aspx">銷貨價格</a>
            </li>
        </ul>
    </nav>

</body>
</html>
