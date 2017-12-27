<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="group_manage.aspx.cs" Inherits="Invoicing_T.group_manage" %>

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
            <li class="breadcrumb-item active" aria-current="page">群組管理</li>
        </ol>
    </nav>
    <form id="form1" runat="server">
         <div>

            <tr>
                <td>
             <asp:Button ID="Button1" runat="server" Text="新增" OnClick="Button1_Click" />
                     </td>
                <td>
            <asp:Label ID="Label3" runat="server" Text="請以群組ID查詢："></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="查詢" OnClick="Button2_Click" />
                    </td>


            </div>

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
                                    <asp:Label ID="Label1" runat="server" Text="修改"></asp:Label></th>
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
                            <asp:LinkButton ID="lbtUpDate" runat="server" CssClass="btn btn-primary btn-sm" PostBackUrl='<%# "group_edit.aspx?ActionState=UpDate&r_id="+Eval("r_id")%>' ToolTip="修改">
                                <asp:Label ID="Label7" runat="server" Text="修改"></asp:Label>
                            </asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary btn-sm" PostBackUrl='<%# "group_edit.aspx?ActionState=Delete&r_id="+Eval("r_id")%>' ToolTip="刪除">
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
</body>
</html>
