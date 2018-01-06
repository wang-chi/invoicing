<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="company_manage.aspx.cs" Inherits="Invoicing_T.company_manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="dashboard.css" rel="stylesheet" />
    <link href="table.css" rel="stylesheet" />
    <title>公司管理</title>
</head>
<body>
    <%Response.WriteFile("header.html");%>
    <div class="container-fluid">
        <div class="row">
            <%Response.WriteFile("nav.aspx");%>
            <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
                <h1>員工資料</h1>
                <form id="form1" runat="server">
                    <div class="form-group">
                        公司ID：<asp:Label ID="com_id" runat="server" Text='<%# Eval("com_id") %>' />
                    </div>
                    <div class="form-group">
                        公司名稱：<asp:Label ID="com_name" runat="server" Text='<%# Eval("com_name") %>' />
                    </div>
                    <div class="form-group">
                        公司地址：<asp:Label ID="com_address" runat="server" Text='<%# Eval("com_address") %>' />
                    </div>
                    <div class="form-group">
                        公司統一編號：<asp:Label ID="com_un" runat="server" Text='<%# Eval("com_un") %>' />
                    </div>
                    <div class="form-group">
                        公司負責人：<asp:Label ID="com_agent" runat="server" Text='<%# Eval("com_agent") %>' />
                    </div>
                    <div class="form-group">
                        公司電話：<asp:Label ID="com_tel" runat="server" Text='<%# Eval("com_tel") %>' />
                    </div>
                    <div class="form-group">
                        公司傳真號碼：<asp:Label ID="com_fax" runat="server" Text='<%# Eval("com_fax") %>' />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btn_company_edit" class="btn btn-success" runat="server" Text="編輯" OnClick="btn_company_edit_Click" />
                    </div>
                </form>
            </main>
        </div>
    </div>
</body>
</html>
