<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="group_edit.aspx.cs" Inherits="Invoicing_T.group_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
</head>
<body>
     <nav aria-label="breadcrumb" role="navigation">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="home.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="group_manage.aspx">群組管理</a></li>
            <li class="breadcrumb-item active" aria-current="page">群組資料修改</li>
        </ol>
    </nav>
    <form id="form1" runat="server">
        <div>
             <asp:HiddenField ID="HiddenF_ActionState" runat="server" />
            <asp:HiddenField ID="HiddenF_rid" runat="server" />
            

            <br />
            群組ID：
                        <asp:Label ID="r_id" runat="server" Text='<%# Eval("r_id") %>' />
            <br />
            群組名稱：
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            群組資訊：
                        <asp:TextBox ID="bt_r_info" runat="server"></asp:TextBox>
            
            <br />

            <asp:Button ID="btUpDate" class="btn" runat="server" Text="修　　改"  OnClick="bt_Click" Visible="false" />
            
            <asp:Button ID="btDelete" class="btn" runat="server" Text="刪　　除"  OnClick="bt_Click"  Visible="false"/>

        </div>
    </form>
</body>
</html>
