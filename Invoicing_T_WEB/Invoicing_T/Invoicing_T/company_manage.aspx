<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="company_manage.aspx.cs" Inherits="Invoicing_T.company_manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>公 司資料</h1>
        <form id="form1" runat="server">
            <div class="form-group">
                公司ID：<asp:Label ID="com_id" runat="server" Text='<%# Eval("com_id") %>' />
            </div>
            <div class="form-group">
                公司名稱：<asp:Label ID="com_name" runat="server" Text='<%# Eval("com_name") %>' />
            </div>
            <div class="form-group">
                公司地址：<asp:Label ID="com_address" runat="server" Text='<%# Eval("com_address") %>' />
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
                <asp:Button ID="btn_company_edit" class="btn btn-success" runat="server" Text="修改" OnClick="btn_company_edit_Click" />
            </div>
        </form>
    </main>
</asp:Content>