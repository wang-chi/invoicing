<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Invoicing_T.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>中科大進銷存 登入</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />

</head>
<body>
    <form id="loginform" runat="server" class="container">
        <div class="form-group row">
            <asp:Label class="col-sm-1 col-form-label" runat="server" For="InputAccount" Text="帳　號" />
            <div class="col-sm-10">
                <asp:TextBox ID="InputAccount" runat="server" MinLength="5" MaxLength="10" />-
            </div>
        </div>

        <div class="form-group row">
            <asp:Label class="col-sm-1 col-form-label" runat="server" For="InputPassword" Text="密　碼" />
            <div class="col-sm-10">
                <asp:TextBox ID="InputPassword" runat="server" TextMode="Password" MinLength="3" MaxLength="20" />
               
            </div>
        </div>
        <div>

            <div class="form-action">
                <asp:Button ID="Button1" type="submit" CssClass="btn btn-primary" runat="server" OnClick="Button1_Click" Text="登　入" Font-Names="微軟正黑體" />
            </div>
            <div id="alert_error" class="alert alert-danger" role="alert" runat="server" visible="false">
                <asp:Label ID="msg_error" runat="server" Text="登錄失敗請重新嘗試" Visible="False" />
            </div>
        </div>
    </form>
</body>
</html>

