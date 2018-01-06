<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="purchases_edit.aspx.cs" Inherits="Invoicing_T.purchases_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>進貨單資料修改</h1>

        <form id="form1" runat="server">
            <asp:HiddenField ID="HiddenF_ActionState" runat="server" />
            <asp:HiddenField ID="HiddenF_rid" runat="server" />
            <div class="form-group">
                <label>進貨單編號：</label>
                <asp:Label ID="pur_id" runat="server" Text='<%# Eval("pur_id") %>' />
            </div>
            <div class="form-group">
                <label>供應商編號：</label>
                <asp:Label ID="s_id" runat="server" Text='<%# Eval("s_id") %>' />
            </div>
            <div class="form-group">
                <label>業務員編號：</label>
                <asp:Label ID="m_id" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-group">
                <label>是否驗收：</label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Selected="False" Value="True">是　</asp:ListItem>
                    <asp:ListItem Selected="False" Value="False">否　</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <label>交貨日：</label>
                <asp:TextBox ID="deliverydate" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>上次更新時間：</label>
                <asp:Label ID="update_time" runat="server" Text='<%# Eval("update_time") %>' />
            </div>
            <div>
                <br />
                <br />

                <asp:Button ID="btn_add" class="btn btn-success" runat="server" Text="新增商品" OnClick="btn_add_Click" />

                <asp:Button ID="btn_update" class="btn btn-primary" runat="server" Text="更新商品" OnClick="btn_update_Click" />

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                    HeaderStyle-Height="35" RowStyle-Height="35" Width="80%"
                    ShowFooter="true" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>

                        <asp:TemplateField>
                            <HeaderTemplate>刪除</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Button ID="btn_delete" class="btn btn-danger" runat="server" Text="刪除商品" OnClick="btn_delete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>商品編號</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="Input_pur_id" runat="server" Text='<%# Eval("p_id") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>商品單價</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="Input_pur_price" runat="server" Text='<%# Eval("purin_price") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>商品數量</HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="Input_pur_count" runat="server" Text='<%# Eval("purin_qty") %>'></asp:TextBox>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <FooterTemplate>
                                單身商品總計
                                   
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderStyle Width="100" />
                            <ItemStyle Width="100" />
                            <FooterStyle Width="100" />
                            <HeaderTemplate>商品小計</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="total_1" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="pur_total" runat="server" Text=""></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>

            <div class="form-group">
                <asp:Button ID="btnUpdate" class="btn btn-danger" runat="server" Text="修改" OnClick="btn_Click" Visible="false" />
                <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" Text="刪除" OnClick="btn_Click" Visible="false" />
            </div>
        </form>
    </main>
</asp:Content>
