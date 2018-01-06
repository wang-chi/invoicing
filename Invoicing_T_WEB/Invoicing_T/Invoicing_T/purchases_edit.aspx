<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="purchases_edit.aspx.cs" Inherits="Invoicing_T.purchases_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="dashboard.css" rel="stylesheet" />
    <link href="table.css" rel="stylesheet" />
    <title>編輯進貨單</title>
</head>

<body>
    <header>
        <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
            <a class="navbar-brand" href="#">Dashboard</a>
            <button class="navbar-toggler d-lg-none" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault"
                aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarsExampleDefault">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href="HomePage.aspx">Home
                               
                            <span class="sr-only">Home</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="member_manage.aspx">編輯進貨單資料
                               
                            <span class="sr-only">(current)</span>
                        </a>
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
                        <a class="nav-link" href="member_manage.aspx">帳號管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="group_manage.aspx">角色管理</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="auth_manage.aspx">權限管理<span class="sr-only">(current)</span></a>
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
                        <a class="nav-link active" href="ProductPage.aspx">商品資料管理<span class="sr-only">(current)</span></a>
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
                <h1>進貨單資料修改</h1>

                <form id="form1" runat="server">
                    <asp:HiddenField ID="HiddenF_ActionState" runat="server" />
                    <asp:HiddenField ID="HiddenF_rid" runat="server" />
                    <div class="form-group">
                        <label>進貨單編號：</label>
                        <asp:Label ID="pur_id" runat="server" Text='<%# Eval("pur_id") %>' />
                    </div>
                    <div class="form-group">
                        <label>供應商編號：</label>
                        <asp:Label ID="s_id" runat="server" Text='<%# Eval("s_id") %>' />
                    </div>
                    <div class="form-group">
                        <label>業務員編號：</label>
                        <asp:Label ID="m_id" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>是否驗收：</label>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                                <asp:ListItem Selected="False" Value="True" >是　</asp:ListItem>
                                <asp:ListItem Selected="False" Value="False" >否　</asp:ListItem>
                            </asp:RadioButtonList>
                    </div>
                    <div class="form-group">
                        <label>交貨日：</label>
                        <asp:TextBox ID="deliverydate" runat="server"></asp:TextBox>
                    </div>

                     <div class="form-group">
                        <label>上次更新時間：</label>
                        <asp:Label ID="update_time" runat="server" Text='<%# Eval("update_time") %>' />
                    </div>
                    <div>

                        <asp:ListView ID="IvPurchases_info_Info" runat="server" GroupItemCount="1"
                            GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder">
                            <LayoutTemplate>
                                <table class="table table-bordered table-hover">
                                    <thead>
                                        <tr class="success">
                                            <th width="25%">
                                                <asp:Label ID="Label10" runat="server" Text="商品名稱"></asp:Label></th>
                                            <th width="25%">
                                                <asp:Label ID="Label5" runat="server" Text="業務員編號"></asp:Label></th>
                                             <th width="25%">
                                                <asp:Label ID="Label6" runat="server" Text="商品價格"></asp:Label></th>
                                            <th width="25%">
                                                <asp:Label ID="Label4" runat="server" Text="商品數量"></asp:Label></th>
                                            
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
                                        <asp:TextBox ID="p_id" runat="server" Text='<%# Eval("p_id") %>'></asp:TextBox>
                                        </td>
                                     <td>
                                        <%# Eval("m_id") %>
                                        </td>
                                     <td>
                                        <asp:TextBox ID="purin_price" runat="server" Text='<%# Eval("purin_price") %>'></asp:TextBox>
                                        </td>
                                     <td>
                                        <asp:TextBox ID="purin_qty" runat="server" Text='<%# Eval("purin_qty") %>'></asp:TextBox>
                                        </td>

                                </tr>
                            </ItemTemplate>
                        </asp:ListView>

                        </div>

                    <div class="form-group">
                        <asp:Button ID="btnUpdate" class="btn btn-danger" runat="server" Text="修改" OnClick="btn_Click" Visible="false" />
                        <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" Text="刪除" OnClick="btn_Click" Visible="false" />
                    </div>
                </form>
            </main>
        </div>
    </div>

</body>

</html>

