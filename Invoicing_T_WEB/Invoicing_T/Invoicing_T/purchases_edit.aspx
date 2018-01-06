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
                        <br />
                        <br />

                        <asp:Button ID="btn_add" class="btn btn-success" runat="server" Text="新增商品" OnClick="btn_add_Click" />
                        
                        <asp:Button ID="btn_update" class="btn btn-primary" runat="server" Text="更新商品" OnClick="btn_update_Click" />

                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                           HeaderStyle-Height="35" RowStyle-Height="35" Width="80%"
                            ShowFooter="true" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>

                                <asp:TemplateField>
                                    <HeaderTemplate>刪除</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="btn_delete" class="btn btn-danger" runat="server" Text="刪除商品" OnClick="btn_delete_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>商品編號</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="Input_pur_id" runat="server" Text='<%# Eval("p_id") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>商品單價</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="Input_pur_price" runat="server" Text='<%# Eval("purin_price") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>商品數量</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="Input_pur_count" runat="server" Text='<%# Eval("purin_qty") %>'></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                        單身商品總計
                                   
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderStyle Width="100" />
                                    <ItemStyle Width="100" />
                                    <FooterStyle Width="100" />
                                    <HeaderTemplate>商品小計</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="total_1" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="pur_total" runat="server" Text=""></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

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

