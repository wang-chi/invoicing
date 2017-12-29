<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="group_manage.aspx.cs" Inherits="Invoicing_T.group_manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
                        <a class="nav-link active" href="group_manage.aspx">角色管理<span class="sr-only">(current)</span></a>
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
                        <a class="nav-link" href="supplier_manage.aspx">廠商管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">客戶管理</a>
                    </li>
                </ul>

                <ul class="nav nav-pills flex-column">
                    <li class="nav-item">
                        <a class="nav-link" href="#">商品管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">商品類別管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">進貨管理</a>
                    </li>
                </ul>
            </nav>

            <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
                <form runat="server">
                    <h1>帳號查詢</h1>
                    <asp:Label ID="Label3" runat="server" Text="請以群組ID查詢："></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="查詢" OnClick="btn_search" />
                    <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="新增" OnClick="btn_insert_group" />

                    <h1>總覽</h1>
                    <div>
                        <asp:ListView ID="lvCampInfo" runat="server" GroupItemCount="1"
                            GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder">
                            <LayoutTemplate>
                                <table class="table table-bordered table-hover">
                                    <thead>
                                        <tr class="success">
                                            <th width="10%">
                                                <asp:Label ID="Label8" runat="server" Text="編輯"></asp:Label></th>
                                            <th width="10%">
                                                <asp:Label ID="Label1" runat="server" Text="刪除"></asp:Label></th>
                                            <th width="27%">
                                                <asp:Label ID="Label10" runat="server" Text="群組ID"></asp:Label></th>
                                            <th width="27%">
                                                <asp:Label ID="Label14" runat="server" Text="群組名稱"></asp:Label></th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>

                                    <td>
                                        <asp:LinkButton ID="lbtnUpdate" runat="server" class="btn btn-danger btn-sm" PostBackUrl='<%# "group_edit.aspx?ActionState=UpDate&r_id="+Eval("r_id")%>' ToolTip="修改">
                                            <asp:Label ID="Label7" runat="server" Text="修改"></asp:Label>
                                        </asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-danger btn-sm" PostBackUrl='<%# "group_edit.aspx?ActionState=Delete&r_id="+Eval("r_id")%>' ToolTip="刪除">
                                            <asp:Label ID="Label2" runat="server" Text="刪除"></asp:Label>
                                        </asp:LinkButton>
                                    </td>
                                    <td><%# Eval("r_id") %></td>
                                    <td><%# Eval("r_name") %></td>
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
