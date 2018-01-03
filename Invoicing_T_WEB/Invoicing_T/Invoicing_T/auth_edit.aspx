<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="auth_edit.aspx.cs" Inherits="Invoicing_T.auth_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="dashboard.css" rel="stylesheet" />
    <link href="table.css" rel="stylesheet" />
    <title>編輯權限</title>
</head>

<body>
    <%Response.WriteFile("header.html");%>
    <div class="container-fluid">
        <div class="row">
            <%Response.WriteFile("nav.aspx");%>
            <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
                <h1>權限資料修改</h1>
                <form id="form1" runat="server">
                    <asp:HiddenField ID="HiddenF_ActionState" runat="server" />
                    <asp:HiddenField ID="HiddenF_rid" runat="server" />
                    <div class="form-group">
                        <label>權限ID：</label>
                        <asp:Label ID="a_id" runat="server" Text='<%# Eval("a_id") %>' />
                    </div>
                    <div class="form-group">
                        <label>權限名稱：</label>
                        <asp:TextBox ID="auth_name_input" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnUpdate" class="btn btn-danger" runat="server" Text="修改" OnClick="btn_Click" Visible="false" />
                        <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" Text="刪除" OnClick="btn_Click" Visible="false" />
                    </div>
                </form>
            </main>
        </div>
    </div>
</body>
</html>
