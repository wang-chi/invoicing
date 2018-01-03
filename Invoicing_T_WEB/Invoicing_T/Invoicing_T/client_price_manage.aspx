﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="client_price_manage.aspx.cs" Inherits="Invoicing_T.client_price_manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>銷貨價格</title>
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
                <form class="form-inline mt-2 mt-md-0">
                    <input class="form-control mr-sm-2" type="text" placeholder="Search" aria-label="Search">
                    <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
                </form>
            </div>
        </nav>
    </header>
    <div class="container-fluid">
        <div class="row">
            <nav class="col-sm-3 col-md-2 d-none d-sm-block bg-light sidebar">
                <ul class="nav nav-pills flex-column">
                    <li class="nav-item">
                        <a class="nav-link" href="HomePage.aspx">Overview </a>
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
                        <a class="nav-link active" href="supplier_manage.aspx">廠商管理<span class="sr-only">(current)</span></a>
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
                <form runat="server">
                    <h1>銷貨價格查詢</h1>
                    <asp:Label ID="Label3" runat="server" Text="請以銷貨單編號查詢："></asp:Label>
                    <asp:TextBox ID="InputClientPrice" runat="server"></asp:TextBox>
                    <asp:Button ID="btn_search_2" class="btn btn-success" runat="server" Text="查詢" OnClick="btn_search" />
                    
                    <h1>總覽</h1>
                    <div>
                        <asp:ListView ID="IvClientPriceInfo" runat="server" GroupItemCount="1"
                            GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder">
                            <LayoutTemplate>
                                <table class="table table-bordered table-hover">
                                    <thead>
                                        <tr class="success">
                                            <th width="20%">
                                                <asp:Label ID="Label10" runat="server" Text="銷貨價格編號"></asp:Label></th>
                                            <th width="20%">
                                                <asp:Label ID="Label14" runat="server" Text="商品編號"></asp:Label></th>
                                            <th width="20%">
                                                <asp:Label ID="Label4" runat="server" Text="客戶編號"></asp:Label></th>
                                            <th width="20%">
                                                <asp:Label ID="Label5" runat="server" Text="銷貨價格"></asp:Label></th>
                                            <th width="20%">
                                                <asp:Label ID="Label6" runat="server" Text="銷貨日期"></asp:Label></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("cp_id") %></td>
                                    <td><%# Eval("p_id") %></td>
                                    <td><%# Eval("c_id") %></td>
                                    <td><%# Eval("price") %></td>
                                    <td><%# Eval("createdate") %></td>

                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </form>
            </main>
        </div>
    </div>
</body>
</html>