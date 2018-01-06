<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="employee_edit.aspx.cs" Inherits="Invoicing_T.employee_edit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <%Response.WriteFile("header.html");%>
    <div class="container-fluid">
        <div class="row">
            <%Response.WriteFile("nav.aspx");%>
            <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
                <h1>公司資料新增</h1>
                <form id="form1" runat="server">
                </form>
            </main>
        </div>
    </div>
</body>
</html>
