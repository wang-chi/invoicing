<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Invoicing_T.login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>中科大進銷存 登入</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />

    <link href="login.css" rel="stylesheet" />
</head>
<body>
    <div class="loginform">
        <span>進銷存管理系統</span>
        <hr/>

        <form id="loginform" runat="server" class="container">
            <div class="form-group row">
                <asp:Label class="col-sm-4 col-form-label" runat="server" For="InputAccount" Text="帳　號" />
                <div class="col-sm-8">
                    <asp:TextBox ID="InputAccount" class="form-control" runat="server"  aria-label="Default" MinLength="5" MaxLength="10" placeholder="請輸入員工帳號"  />
                </div>
            </div>

            <div class="form-group row">
                <asp:Label class="col-sm-4 col-form-label" runat="server" For="InputPassword" Text="密　碼" />
                <div class="col-sm-8">
                    <asp:TextBox ID="InputPassword" TextMode="Password" class="form-control" runat="server"  aria-label="Default" MinLength="6" MaxLength="15" placeholder="請輸入員工密碼"  />

                </div>
            </div>
            <div>
                <div class="form-action">
                    <asp:Button ID="Button1" type="submit" CssClass="btn btn-primary" runat="server" OnClick="Button1_Click" Text="登　入" />
                </div>
                <div id="alert_error" class="alert alert-danger" role="alert" runat="server" visible="false">
                    <asp:Label ID="msg_error" runat="server" Text="登錄失敗請重新嘗試" />
                </div>
            </div>
        </form>
    </div>
</body>
</html>

