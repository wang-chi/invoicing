<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="orders_new.aspx.cs" Inherits="Invoicing_T.order_new" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>新增銷貨單</h1>
        <form id="form1" runat="server">

            <div class="form-group row">
                <div>
                    <asp:Label ID="Label1" runat="server" Text="銷貨單編號："></asp:Label>
                </div>
                <div>
                    <asp:Label ID="orid" runat="server" Text="W0001"></asp:Label>
                </div>
                <asp:Label ID="Msg_ExistID" runat="server" Text="編號已存在" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
            </div>

            <div class="form-group row">
                <div>
                    <asp:Label ID="Label2" runat="server" Text="客戶編號："></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="InputCid" class="form-control" runat="server" Visible="false"></asp:TextBox>
                    <asp:DropDownList ID="ddlClientGroup" class="form-control" runat="server" ToolTip="群組選項"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <div>

                    <asp:Label ID="Label3" runat="server" Text="業務員編號："></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="InputMid" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <div>
                    <asp:Label ID="Label4" runat="server" Text="交貨日日期："></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="InputDeliverydate" class="form-control" runat="server" TextMode="DateTime"></asp:TextBox>
                </div>



            </div>

            <!--單身 -->
            <div>
                <div class="form-group row">
                    <div>
                        <asp:Button ID="btn_add" class="btn btn-success" runat="server" Text="添加商品" OnClick="btn_add_Click" />
                    </div>
                    <div>
                        <asp:Button ID="btn_delete" class="btn btn-danger" runat="server" Text="刪除商品" OnClick="btn_delete_Click" />
                    </div>
                    <div>
                        <asp:Button ID="btn_update" class="btn btn-primary" runat="server" Text="更新商品" OnClick="btn_update_Click" />
                    </div>
                </div>
                <asp:GridView ID="GridView1" class="form" runat="server" AutoGenerateColumns="false"
                    DataKeyNames="PurID" HeaderStyle-Height="35" RowStyle-Height="35" Width="90%"
                    ShowFooter="true" OnRowDataBound="GridView1_RowDataBound">
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
                                <asp:Label ID="or_id" runat="server" Text='<%# Eval("pid") %>' Visible="true"></asp:Label>
                                <!--
                                <asp:DropDownList ID="ddlGroup" class="form-control" AutoPostBack="true" runat="server" ToolTip="群組選項">
                                </asp:DropDownList>
                                -->
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>商品名稱</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="p_id" runat="server" Text='<%# Eval("pid") %>' Visible="false"></asp:Label>
                                <asp:DropDownList ID="ddlNameGroup" class="form-control" runat="server" AutoPostBack="true" ToolTip="群組選項" OnSelectedIndexChanged="NameGroup_SelectIndexChanged">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>商品單價</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="Input_or_price" runat="server" class="form-control" Text='<%# Eval("Price") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>商品數量</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="Input_or_count" runat="server" class="form-control" Text='<%# Eval("Count") %>'></asp:TextBox>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <FooterTemplate>單身商品總計</FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle Width="100" />
                            <ItemStyle Width="100" />
                            <FooterStyle Width="100" />
                            <HeaderTemplate>商品小計</HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("Total") %>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="pur_total" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div>
                    <asp:Label ID="Msg_Error" runat="server" Text="*有資料未填寫" Visible="False" Font-Size="9pt" ForeColor="Red"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Button ID="btn_insert_orders" CssClass="btn btn-primary" runat="server" Text="新增銷貨單" OnClick="btn_insert_orders_Click" />
                </div>
            </div>
        </form>


    </main>
</asp:Content>
