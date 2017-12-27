<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="auth_manage.aspx.cs" Inherits="Invoicing_T.auth_manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <nav aria-label="breadcrumb" role="navigation">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="home.aspx">Home</a></li>
            <li class="breadcrumb-item active" aria-current="page">權限管理</li>
        </ol>
    </nav>

    <form id="form1" runat="server">
        <div>

            <asp:ListView ID="lvauthInfo" runat="server" GroupItemCount="1"
                GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover">
                        <thead>
                            <tr class="success">
                                <th width="25%">
                                    <asp:Label ID="Label8" runat="server" Text="編輯"></asp:Label></th>
                                <th width="25%">
                                    <asp:Label ID="Label1" runat="server" Text="修改"></asp:Label></th>
                                <th width="25%">
                                    <asp:Label ID="Label10" runat="server" Text="權限ID"></asp:Label></th>
                                <th width="25%">
                                    <asp:Label ID="Label14" runat="server" Text="權限名稱"></asp:Label></th>
                               
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
                            <asp:LinkButton ID="lbtUpDate" runat="server" CssClass="btn btn-primary btn-sm" PostBackUrl='<%# "auth_edit.aspx?ActionState=UpDate&r_id="+Eval("a_id")%>' ToolTip="修改">
                                <asp:Label ID="Label7" runat="server" Text="修改"></asp:Label>
                            </asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary btn-sm" PostBackUrl='<%# "auth_edit.aspx?ActionState=Delete&r_id="+Eval("a_id")%>' ToolTip="刪除">
                                <asp:Label ID="Label2" runat="server" Text="刪除"></asp:Label>
                            </asp:LinkButton>
                        </td>
                        <td><%# Eval("a_id") %></td>
                        <td><%# Eval("a_name") %></td>
                        
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            
        </div>
    </form>
</body>
</html>
