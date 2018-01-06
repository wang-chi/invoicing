<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="group_edit.aspx.cs" Inherits="Invoicing_T.group_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="dashboard.css" rel="stylesheet" />
    <link href="table.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <%Response.WriteFile("header.html");%>
    <div class="container-fluid">
        <div class="row">
            <%Response.WriteFile("nav.aspx");%>
            <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
                <h1>角色資料修改</h1>
                <form id="form1" runat="server">
                    <asp:HiddenField ID="HiddenF_ActionState" runat="server" />
                    <asp:HiddenField ID="HiddenF_rid" runat="server" />
                    <div class="form-group">
                        <label>群組ID：</label>
                        <asp:Label ID="r_id" runat="server" Text='<%# Eval("r_id") %>' />
                    </div>
                    <div class="form-group">
                        <label>群組名稱：</label>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnUpdate" class="btn btn-success" runat="server" Text="修改" Visible="false" OnClick="btn_Click" />
                        <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" Text="刪除" Visible="false" OnClick="btn_Click" />
                    </div>
                </form>
            </main>
        </div>
    </div>
</body>
</html>
