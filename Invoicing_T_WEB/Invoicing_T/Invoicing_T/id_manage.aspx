<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="id_manage.aspx.cs" Inherits="Invoicing_T.id_manage" %>

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
            <li class="breadcrumb-item active" aria-current="page">帳號管理</li>
        </ol>
    </nav>
    <form id="form1" runat="server">

        <div>

            <asp:LinkButton ID="lbtInsert" runat="server"  PostBackUrl='<%# "id_edit.aspx?ActionState=Insert&m_id="+Eval("m_id")%>' ToolTip="新增">
                  <asp:Label ID="Label7" runat="server" Text="新增"></asp:Label>
                            </asp:LinkButton>

           

            </div>

        <div>

            <asp:ListView ID="lvmemberInfo" runat="server" GroupItemCount="1"
                GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover">
                        <thead>
                            <tr class="success">
                                <th width="8%">
                                    <asp:Label ID="Label2" runat="server" Text="編輯狀態"></asp:Label></th>
                                <th width="8%">
                                    <asp:Label ID="Label10" runat="server" Text="用戶ID"></asp:Label></th>
                                <th width="8%">
                                    <asp:Label ID="Label14" runat="server" Text="用戶密碼"></asp:Label></th>
                                <th width="8%">
                                    <asp:Label ID="Label27" runat="server" Text="用戶狀態"></asp:Label></th>
                                <th width="8%">
                                    <asp:Label ID="Label1" runat="server" Text="用戶名稱"></asp:Label></th>
                                <th width="8%">
                                    <asp:Label ID="Label3" runat="server" Text="用戶性別"></asp:Label></th>
                                <th width="8%">
                                    <asp:Label ID="Label4" runat="server" Text="用戶角色"></asp:Label></th>
                                <th width="8%">
                                    <asp:Label ID="Label5" runat="server" Text="員工編號"></asp:Label></th>
                                <th width="8%">
                                    <asp:Label ID="Label6" runat="server" Text="用戶電話"></asp:Label></th>
                                <th width="8%">
                                    <asp:Label ID="Label9" runat="server" Text="用戶信箱"></asp:Label></th>
                                <!-- <th width="10%">
                                    <asp:Label ID="Label11" runat="server" Text="創立時間"></asp:Label></th>
                                <th width="10%">
                                    <asp:Label ID="Label12" runat="server" Text="更新時間"></asp:Label></th>-->

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
                            <asp:LinkButton ID="lbtUpDate" runat="server" CssClass="btn btn-primary btn-sm" PostBackUrl='<%# "id_edit.aspx?ActionState=UpDate&m_id="+Eval("m_id")%>' ToolTip="修改">
                                <asp:Label ID="Label7" runat="server" Text="修改"></asp:Label>
                            </asp:LinkButton>
                        </td>

                        <td>
                            <asp:Label ID="member_id" runat="server" Text='<%# Eval("m_id") %>'></asp:Label></td>
                        <td><%# Eval("m_pwd") %></td>
                        <td><%# Eval("m_position") %></td>
                        <td><%# Eval("m_name") %></td>
                        <td><%# Eval("m_sex") %></td>
                        <td><%# Eval("r_id") %></td>
                        <td><%# Eval("m_number") %></td>
                        <td><%# Eval("m_phone") %></td>
                        <td><%# Eval("m_email") %></td>
                        <!--<td><%# Eval("createdate") %></td>
                        <td><%# Eval("update_time") %></td>-->

                    </tr>
                </ItemTemplate>
            </asp:ListView>
            
        </div>
    </form>
</body>
</html>
