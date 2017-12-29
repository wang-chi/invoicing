<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Invoicing_T.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <nav aria-label="breadcrumb" role="navigation" runat="server">
        <ol class="breadcrumb">
            <li class="breadcrumb-item active" aria-current="page">Home</li>
            <li class="logout" aria-current="page" style="position:fixed; right:1rem;">登出</li>
        </ol>
    </nav>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btn_id_manage" class="btn" runat="server" Text="帳號管理" OnClick="btn_id_manage_Click" />
            <asp:Button ID="btn_group_manage" class="btn" runat="server" Text="群組管理" OnClick="btn_group_manage_Click" />
            <asp:Button ID="btn_role_manage" class="btn" runat="server" Text="權限管理" OnClick="btn_role_manag_Click" />
        </div>
    </form>
</body>
</html>
