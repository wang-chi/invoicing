<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="id_edit_new.aspx.cs" Inherits="Invoicing_T.id_edit_new" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>新增員工</title>

    <style type="text/css">
        .auto-style1 {
            width: 95px;
        }
        .auto-style2 {
            width: 95px;
            height: 20px;
        }
        .auto-style3 {
            height: 20px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>

             <table id="registertable">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label6" runat="server" Text="員工帳號"></asp:Label>
                        </td>
                       <td style="text-align:left;">
                            <asp:TextBox ID="TextBox6" runat="server" Width="150px"></asp:TextBox>
                              
                            </td>
                        
                        </tr>

                      <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label11" runat="server" Text="員工密碼"></asp:Label>
                        </td>
                       <td style="text-align:left;">
                            <asp:TextBox ID="TextBox7" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                 <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label12" runat="server" Text="員工狀態"></asp:Label>
                        </td>
                         <td style="text-align:left;">
                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="0">啟用　</asp:ListItem>
                                <asp:ListItem Selected="True" Value="1">停權　</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>

                    <tr>
                        <td class="auto-style1" >
                            <asp:Label ID="Label1" runat="server" Text="姓　　名"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="TextBox1" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>

            
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label7" runat="server" Text="性　　別"></asp:Label>
                        </td>
                         <td style="text-align:left;">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="0">男　</asp:ListItem>
                                <asp:ListItem Selected="True" Value="1">女　</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>

            
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label2" runat="server" Text="角　　色"></asp:Label>
                        </td>
                        <td style="text-align:left;">
                                <asp:TextBox ID="TextBox2" runat="server" Width="150px"></asp:TextBox>
                            
                                <br />
                            
                            <asp:Label ID="Label8" runat="server" Text="改下拉" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td  class="auto-style1">
                            <asp:Label ID="Label3" runat="server" Text="員工編號"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
           
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label4" runat="server" Text="電話號碼"></asp:Label>
                        </td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                        </td>
                    </tr>

           
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label5" runat="server" Text="電子信箱"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="TextBox5" runat="server" Width="150px"></asp:TextBox>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox5" Display="Dynamic" ErrorMessage="電子郵件地址的格式錯誤。" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="AllValidators" Font-Size="9pt" ForeColor="Red">無效的格式！</asp:RegularExpressionValidator>
                     
                        </td>

                          
                    </tr>
                    <tr>
                        <asp:Label ID="Label10" runat="server" Text="Label" Visible="False"></asp:Label>
                    </tr>

                </table>

                    <div style="margin:auto">
                        <asp:Button ID="Button2" runat="server" Text="新     增" OnClick="Button2_Click" ValidationGroup="AllValidators" Font-Bold="False" Font-Names="微軟正黑體" Font-Size="12pt" Height="30px" Width="55px" />
                        </div>

        </div>
    </form>
</body>
</html>
