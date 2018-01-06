<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="group_new.aspx.cs" Inherits="Invoicing_T.group_new" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="dashboard.css" rel="stylesheet" />
    <link href="table.css" rel="stylesheet" />
</head>
<body>
    <%Response.WriteFile("header.html");%>
    <div class="container-fluid">
        <div class="row">
            <%Response.WriteFile("nav.aspx");%>
            <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
                <h1>群組資料修改</h1>                
                <form id="form1" runat="server">
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="群組帳號"/>
                        <asp:Label ID="Id" runat="server" Text="Label"></asp:Label>
                        <asp:Label ID="Label12" runat="server" Text="已有此群組帳號" Visible="false" Font-Size="9pt" ForeColor="Red"/>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label11" runat="server" Text="群組名稱"></asp:Label>
                        <asp:TextBox ID="InputName" runat="server" Width="150px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="*資料要填寫齊全" Visible="false" Font-Size="9pt" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="新增群組" OnClick="btn_insert_group" Font-Size="12pt" Height="30px" Width="94px" />
                    </div>            
                </form>    
            </main>
        </div>
    </div>
   
</body>
</html>
