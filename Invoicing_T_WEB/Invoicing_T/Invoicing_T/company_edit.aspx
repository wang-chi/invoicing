<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="false" CodeBehind="company_edit.aspx.cs" Inherits="Invoicing_T.company_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
</asp:Content>
