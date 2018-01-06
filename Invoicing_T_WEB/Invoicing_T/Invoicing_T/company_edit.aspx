<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="company_edit.aspx.cs" Inherits="Invoicing_T.company_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="dashboard.css" rel="stylesheet" />
    <link href="table.css" rel="stylesheet" />
    <title>修改公司內容</title>
</head>

<body>
    <%Response.WriteFile("header.html");%>
    <div class="container-fluid">
        <div class="row">
            <%   
                Response.WriteFile("nav.aspx");
            %>

            <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
                <h1>公司資料修改</h1>
                <div>
                    <form id="form1" runat="server">
                        <div class="form-group">
                            公司ID：<asp:Label ID="com_id" runat="server" Text='<%# Eval("com_id") %>' />
                        </div>

                        <div class="form-group">
                            公司名稱：<asp:TextBox ID="com_name" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            公司地址：<asp:TextBox ID="com_address" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            公司統一編號：<asp:TextBox ID="com_un" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            公司負責人：<asp:TextBox ID="com_agent" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            公司電話：<asp:TextBox ID="com_tel" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            公司傳真號碼：<asp:TextBox ID="com_fax" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="*資料要填寫齊全" Visible="false" Font-Size="9pt" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnUpdatecompany" class="btn btn-success" runat="server" Text="修　　改" OnClick="btnUpdateCompany_Click" />
                        </div>
                    </form>

                </div>

            </main>
        </div>
    </div>

</body>

</html>
