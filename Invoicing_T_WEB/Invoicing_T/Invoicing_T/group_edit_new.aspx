<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="group_edit_new.aspx.cs" Inherits="Invoicing_T.group_edit_new" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <nav aria-label="breadcrumb" role="navigation">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="home.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="group_manage.aspx">群組管理</a></li>
            <li class="breadcrumb-item active" aria-current="page">新增群組</li>
        </ol>
    </nav>
    <form id="form1" runat="server">
        <div>

            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="群組帳號"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="150px"></asp:TextBox>
                        </br>
                            <asp:Label ID="Label12" runat="server" Text="已有此群組帳號" Visible="false" Font-Size="9pt" ForeColor="Red"></asp:Label>

                    </td>

                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="群組名稱"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Width="150px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="*資料要填寫齊全" Visible="false" Font-Size="9pt" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="新增群組" OnClick="Button1_Click" Font-Names="微軟正黑體" Font-Size="12pt" Height="30px" Width="94px" />
        </div>

    </form>
</body>
</html>
