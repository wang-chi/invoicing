<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Invoicing_T.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="dashboard.css" rel="stylesheet" />

</head>
<body>
    <%Response.WriteFile("header.html");%>
    <div class="container-fluid">
        <div class="row">
            <%Response.WriteFile("nav.aspx");%>
            <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
                <h1>Dashboard</h1>
                <section class="row text-center placeholders">
                    <div class="col-6 col-sm-3 placeholder">
                        <img src="data:image/gif;base64,R0lGODlhAQABAIABAAJ12AAAACwAAAAAAQABAAACAkQBADs=" width="200" height="200" class="img-fluid rounded-circle" alt="Generic placeholder thumbnail" />
                        <h4>Label</h4>
                        <div class="text-muted">年度銷售額</div>
                    </div>
                    <div class="col-6 col-sm-3 placeholder">
                        <img src="data:image/gif;base64,R0lGODlhAQABAIABAADcgwAAACwAAAAAAQABAAACAkQBADs=" width="200" height="200" class="img-fluid rounded-circle" alt="Generic placeholder thumbnail" />
                        <h4>Label</h4>
                        <span class="text-muted">本月銷售額</span>
                    </div>
                    <div class="col-6 col-sm-3 placeholder">
                        <img src="data:image/gif;base64,R0lGODlhAQABAIABAAJ12AAAACwAAAAAAQABAAACAkQBADs=" width="200" height="200" class="img-fluid rounded-circle" alt="Generic placeholder thumbnail" />
                        <h4>Label</h4>
                        <span class="text-muted">目前存貨金額</span>
                    </div>
                    <div class="col-6 col-sm-3 placeholder">
                        <img src="data:image/gif;base64,R0lGODlhAQABAIABAADcgwAAACwAAAAAAQABAAACAkQBADs=" width="200" height="200" class="img-fluid rounded-circle" alt="Generic placeholder thumbnail" />
                        <h4>Label</h4>
                        <span class="text-muted">應收帳款金額</span>
                    </div>
                </section>
                <h1>Dashboard</h1>
            </main>
        </div>
    </div>
</body>
</html>
