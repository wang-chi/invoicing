<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="employee_manage.aspx.cs" Inherits="Invoicing_T.employee_manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="dashboard.css" rel="stylesheet" />
    <link href="table.css" rel="stylesheet" />
    <title>員工管理</title>
</head>
<body>
    <%Response.WriteFile("header.html");%>
    <div class="container-fluid">
        <div class="row">
            <%Response.WriteFile("nav.aspx");%>
            <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
                <h1>員工資料</h1>
                <div>
                    <form id="form1" runat="server">
                        <div>
                            <div class="form-group">
                                員工帳號：<asp:Label ID="com_id" runat="server" Text='<%# Eval("m_id") %>' />
                            </div>
                            <div class="form-group">
                                員工姓名：<asp:Label ID="com_name" runat="server" Text='<%# Eval("com_name") %>' />
                            </div>
                            <div class="form-group">
                                員工密碼：<asp:Label ID="com_address" runat="server" Text='<%# Eval("com_address") %>' />
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
                                <asp:Button ID="btn_employee_edit" class="btn btn-success" runat="server" Text="編輯"  OnClick="btn_employee_edit_Click" />
                            </div>

                        </div>
                    </form>
                </div>
            </main>
        </div>
    </div>
</body>
</html>