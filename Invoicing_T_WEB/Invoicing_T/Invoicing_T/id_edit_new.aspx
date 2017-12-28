<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="id_edit_new.aspx.cs" Inherits="Invoicing_T.id_edit_new" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增員工</title>
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
                        <a class="nav-link" href="id_manage.aspx">帳號管理 <span class="sr-only">(current)</span></a>
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
                <h1>員工資料新增</h1>
                <div>
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <asp:Label ID="Label6" runat="server" Text="員工帳號"></asp:Label>
                            <asp:TextBox ID="InputID" runat="server" Width="150px"></asp:TextBox>
                            <asp:Label ID="Msg_ExistID" runat="server" Text="帳號已存在" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label11" runat="server" Text="員工密碼"></asp:Label>
                            <asp:TextBox ID="InputPWD" runat="server" Width="150px"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label12" runat="server" Text="員工狀態"></asp:Label>
                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="True">啟用　</asp:ListItem>
                                <asp:ListItem Selected="True" Value="False">停權　</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="姓　　名"></asp:Label>
                            <asp:TextBox ID="InputName" runat="server" Width="150px"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label7" runat="server" Text="性　　別"></asp:Label>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="m">男　</asp:ListItem>
                                <asp:ListItem Selected="True" Value="f">女　</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="角　　色"></asp:Label>
                            <asp:TextBox ID="InputRoles" runat="server" Width="150px"></asp:TextBox>
                            <asp:Label ID="Label8" runat="server" Text="改下拉" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label4" runat="server" Text="員工編號"></asp:Label>
                            <asp:TextBox ID="InputNumber" runat="server" Width="150px"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label5" runat="server" Text="電話號碼"></asp:Label>
                            <asp:TextBox ID="InputPhone" runat="server" Width="150px"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label10" runat="server" Text="電子信箱"></asp:Label>
                            <asp:TextBox ID="InputEmail" runat="server" Width="150px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="InputEmail" Display="Dynamic" ErrorMessage="電子郵件地址的格式錯誤。" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="AllValidators" Font-Size="9pt" ForeColor="Red">無效的格式！</asp:RegularExpressionValidator>
                        </div>
                        <div>
                            <asp:Label ID="Label13" runat="server" Text="*有資料未填寫" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
                        </div>
                        <div style="margin: auto">
                            <asp:Button ID="Button3" class="btn" runat="server" Text="新增員工" OnClick="btn_insert_member" ValidationGroup="AllValidators" />
                        </div>

                    </form>

                </div>

            </main>
        </div>
    </div>
</body>
</html>
