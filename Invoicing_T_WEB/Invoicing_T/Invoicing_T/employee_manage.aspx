<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="employee_manage.aspx.cs" Inherits="Invoicing_T.employee_manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>員工資料</h1>
        <div>
            <form id="form1" runat="server">
                <asp:HiddenField ID="HiddenF_mid" runat="server" />
                <div class="form-group row">
                    <div>
                        <label>用戶編號：</label>
                    </div>
                    <asp:Label ID="m_id" runat="server" Text='<%# Eval("m_id") %>' />
                </div>

                <div class="form-group row">
                    <div>
                        <label>用戶名稱：</label>
                    </div>
                    <div>
                        <asp:Label ID="m_name" class="form-control" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <div>
                        <label>用戶性別：</label></div>
                    <div>
                        <asp:Label ID="m_sex" runat="server" Text='<%# Eval("m_sex") %>' /></div>
                </div>
                <div class="form-group row">
                    <div>
                        <label>角色名稱：：</label></div>
                    <asp:Label ID="r_name" runat="server" Text='<%# Eval("r_name") %>' />
                </div>
                <div class="form-group row">
                    <div>
                        <label>員工電話：</label>
                    </div>
                    <div>
                        <asp:Label ID="m_phone" class="form-control" runat="server" MaxLength="10"></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <div>
                        <label>用戶信箱：</label>
                    </div>
                    <div>
                        <asp:Label ID="m_email" class="form-control" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Button ID="btn_company_edit" class="btn btn-success" runat="server" Text="修改" OnClick="btn_edit_Click" />
                </div>
            </form>
        </div>
    </main>
</asp:Content>
