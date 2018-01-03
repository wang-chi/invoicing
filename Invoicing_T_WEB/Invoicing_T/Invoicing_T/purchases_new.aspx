<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="purchases_new.aspx.cs" Inherits="Invoicing_T.purchases_new" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>新增進貨單</title>
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
                <h1>新增進貨單</h1>
                  <div>
                    <form id="form1" runat="server">
                        <asp:Button ID="btn_add" runat="server" Text="添加商品" OnClick="btn_add_Click" />
                        <asp:Button ID="btn_delete" runat="server" Text="刪除商品" OnClick="btn_delete_Click"/>
                        <asp:Button ID="btn_update" runat="server" Text="更新" OnClick="btn_update_Click"/>
                        
                    <br/>
                    <br/>
                    
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                        DataKeyNames="PurID" HeaderStyle-Height="35" RowStyle-Height="35" Width="80%"
                         ShowFooter="true" OnRowDataBound="GridView1_RowDataBound" >
                        <Columns>

                             <asp:TemplateField>
                                <HeaderTemplate>選擇</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>商品編號</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="Input_pur_id" runat="server" Text='<%# Eval("pid") %>' ></asp:TextBox>
                                    </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>商品名稱</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="Input_pur_name" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                                    </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>商品單價</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="Input_pur_price" runat="server" Text='<%# Eval("Price") %>'></asp:TextBox>
                                    </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>商品數量</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="Input_pur_count" runat="server" Text='<%# Eval("Count") %>'></asp:TextBox>
                                    </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />
                                <FooterTemplate>
                                    商品小計
                                    </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderStyle Width="100" />
                                <ItemStyle Width="100" />
                                <FooterStyle Width="100" />
                                <HeaderTemplate>進貨單金額總計</HeaderTemplate>
                                <ItemTemplate>
                                    <%# Eval("Total") %>
                                    </ItemTemplate>
                               <FooterTemplate>
                                   <asp:Label ID="pur_total" runat="server" Text=""></asp:Label>
                                   </FooterTemplate>
                            </asp:TemplateField>


                                </Columns>
                    </asp:GridView>

                    </form>
                </div>
            </main>
        </div>
    </div>
</body>
</html>

