﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="purchases_manage.aspx.cs" Inherits="Invoicing_T.purchases_manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>進貨單管理</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="dashboard.css" rel="stylesheet" />
    <link href="table.css" rel="stylesheet" />
</head>
<body>
    <%Response.WriteFile("header.html");%>
    <div class="container-fluid">
        <div class="row">
            <%Response.WriteFile("nav.aspx");%>
            <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
                <form runat="server">
                    <h1>進貨單查詢</h1>
                    <asp:Label ID="Label3" runat="server" Text="請以進貨單編號查詢："></asp:Label>
                    <asp:TextBox ID="InputPurchasea" runat="server"></asp:TextBox>
                    <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="查詢" OnClick="btn_search" />
                    <asp:Button ID="btn_insert_purchases" class="btn btn-primary" runat="server" Text="新增" OnClick="btn_insert_purchases_Click"/>

                    <h1>總覽</h1>
                    <div>
                        <asp:ListView ID="IvPurchasesInfo" runat="server" GroupItemCount="1"
                            GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder">
                            <LayoutTemplate>
                                <table class="table table-bordered table-hover">
                                    <thead>
                                        <tr class="success">
                                            <th width="10%">
                                                <asp:Label ID="Label8" runat="server" Text="編輯"></asp:Label></th>
                                            <th width="10%">
                                                <asp:Label ID="Label1" runat="server" Text="刪除"></asp:Label></th>
                                            <th width="16%">
                                                <asp:Label ID="Label10" runat="server" Text="進貨單編號"></asp:Label></th>
                                            <th width="16%">
                                                <asp:Label ID="Label14" runat="server" Text="廠商編號"></asp:Label></th>
                                            <th width="16%">
                                                <asp:Label ID="Label5" runat="server" Text="業務員編號"></asp:Label></th>
                                             <th width="16%">
                                                <asp:Label ID="Label6" runat="server" Text="是否已驗收"></asp:Label></th>
                                            <th width="16%">
                                                <asp:Label ID="Label4" runat="server" Text="交貨日"></asp:Label></th>
                                            
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
                                        <asp:LinkButton ID="lbtnUpdate" runat="server" class="btn btn-danger btn-sm" PostBackUrl='<%# "purchases_edit.aspx?ActionState=UpDate&pur_id="+Eval("pur_id")%>' ToolTip="修改">
                                            <asp:Label ID="Label7" runat="server" Text="修改"></asp:Label>
                                        </asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-danger btn-sm" PostBackUrl='<%# "purchases_edit.aspx?ActionState=Delete&pur_id="+Eval("pur_id")%>' ToolTip="刪除">
                                            <asp:Label ID="Label2" runat="server" Text="刪除"></asp:Label>
                                        </asp:LinkButton>
                                    </td>
                                    <td><%# Eval("pur_id") %></td>
                                    <td><%# Eval("s_id") %></td>
                                    <td><%# Eval("m_id") %></td>
                                    <td><%# Eval("accept") %></td>
                                    <td><%# Eval("deliverydate") %></td>

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