<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="employee_edit.aspx.cs" Inherits="Invoicing_T.employee_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>編輯員工資料</h1>
        <div>
            <form id="form1" runat="server">
                <asp:HiddenField ID="HiddenF_mid" runat="server" />
                <div class="form-group row">
                    <div>
                        <label>用戶編號：</label></div>
                    <asp:Label ID="m_id" runat="server" Text='<%# Eval("m_id") %>' />
                </div>

                <div class="form-group row">
                    <div>
                        <label>用戶名稱：</label></div>
                    <div>
                        <asp:TextBox ID="m_name" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div><label>用戶性別：</label></div>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="M">男　</asp:ListItem>
                        <asp:ListItem Selected="True" Value="F">女　</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="form-group row">
                    <div>
                        <label>角色名稱：：</label></div>
                    <asp:Label ID="r_name" runat="server" Text='<%# Eval("r_name") %>' />
                </div>
                <div class="form-group row">
                    <div>
                        <label>員工電話：</label></div>
                    <div>
                        <asp:TextBox ID="m_phone" class="form-control" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div>
                        <label>用戶信箱：</label></div>
                    <div>
                        <asp:TextBox ID="m_email" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="*資料要填寫齊全" Visible="false" Font-Size="9pt" ForeColor="Red"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnUpdatecompany" class="btn btn-success" runat="server" Text="修　　改" OnClick="btn_edit_Click" />
                </div>
            </form>
        </div>
    </main>
</asp:Content>
