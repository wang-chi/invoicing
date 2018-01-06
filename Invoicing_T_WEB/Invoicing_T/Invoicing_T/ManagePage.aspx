<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagePage.aspx.cs" Inherits="Invoicing_T.ManagePage" %>

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
                        <div class="text-muted">供應商數</div>
                    </div>
                    <div class="col-6 col-sm-3 placeholder">
                        <img src="data:image/gif;base64,R0lGODlhAQABAIABAADcgwAAACwAAAAAAQABAAACAkQBADs=" width="200" height="200" class="img-fluid rounded-circle" alt="Generic placeholder thumbnail" />
                        <h4>Label</h4>
                        <span class="text-muted">客戶數</span>
                    </div>
                    <div class="col-6 col-sm-3 placeholder">
                        <img src="data:image/gif;base64,R0lGODlhAQABAIABAAJ12AAAACwAAAAAAQABAAACAkQBADs=" width="200" height="200" class="img-fluid rounded-circle" alt="Generic placeholder thumbnail" />
                        <h4>Label</h4>
                        <span class="text-muted">進貨數量</span>
                    </div>
                    <div class="col-6 col-sm-3 placeholder">
                        <img src="data:image/gif;base64,R0lGODlhAQABAIABAADcgwAAACwAAAAAAQABAAACAkQBADs=" width="200" height="200" class="img-fluid rounded-circle" alt="Generic placeholder thumbnail" />
                        <h4>Label</h4>
                        <span class="text-muted">銷售數量</span>
                    </div>
                </section>
            </main>
        </div>
    </div>
</body>
</html>
