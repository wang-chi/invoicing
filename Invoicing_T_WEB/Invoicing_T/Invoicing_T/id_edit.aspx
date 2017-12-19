<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="id_edit.aspx.cs" Inherits="Invoicing_T.id_edit" %>

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
            <li class="breadcrumb-item"><a href="id_manage.aspx">帳號管理</a></li>
            <li class="breadcrumb-item active" aria-current="page">帳號資料修改</li>
        </ol>
    </nav>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="HiddenF_ActionState" runat="server" />
            <asp:HiddenField ID="HiddenF_mid" runat="server" />

            <br />
            用戶ID：
                        <asp:Label ID="m_id" runat="server" Text='<%# Eval("m_id") %>' />
            <br />
            用戶密碼：
                        <asp:Label ID="m_pwd" runat="server" Text='<%# Eval("m_pwd") %>' />
            <br />
            用戶狀態：
                        <asp:Label ID="m_position" runat="server" Text='<%# Eval("m_position") %>' />
            <br />
            用戶名稱：
                        <asp:Label ID="m_name" runat="server" Text='<%# Eval("m_name") %>' />
            <br />
            用戶性別：
                        <asp:Label ID="m_sex" runat="server" Text='<%# Eval("m_sex") %>' />
            <br />
            角色編號：
                        <asp:Label ID="r_id" runat="server" Text='<%# Eval("r_id") %>' />
            <br />
            員工編號：
                        <asp:Label ID="m_number" runat="server" Text='<%# Eval("m_number") %>' />
            <br />
            員工電話：
                        <asp:Label ID="m_phone" runat="server" Text='<%# Eval("m_phone") %>' />
            <br />
            用戶信箱：
                        <asp:Label ID="m_email" runat="server" Text='<%# Eval("m_email") %>' />

            <br />

            <asp:Button ID="bt_position" class="btn" runat="server" Text="更改狀態為" OnClick="bt_position_Click" />

        </div>
    </form>
</body>
</html>
