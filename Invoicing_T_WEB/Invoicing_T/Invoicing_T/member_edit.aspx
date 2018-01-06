<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="member_edit.aspx.cs" Inherits="Invoicing_T.member_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>員工資料修改</h1>
        <div>
            <form id="form1" runat="server">
                <div>
                    <asp:HiddenField ID="HiddenF_ActionState" runat="server" />
                    <asp:HiddenField ID="HiddenF_mid" runat="server" />
                    <div class="form-group">
                        用戶ID：<asp:Label ID="m_id" runat="server" Text='<%# Eval("m_id") %>' />
                    </div>
                    <div class="form-group">
                        用戶狀態：<asp:Label ID="m_state" runat="server" Text='<%# Eval("m_state") %>' />
                    </div>
                    <div class="form-group">
                        用戶名稱：<asp:Label ID="m_name" runat="server" Text='<%# Eval("m_name") %>' />
                    </div>
                    <div class="form-group">
                        用戶性別：<asp:Label ID="m_sex" runat="server" Text='<%# Eval("m_sex") %>' />
                    </div>
                    <div class="form-group">
                        角色編號：<asp:Label ID="r_id" runat="server" Text='<%# Eval("r_id") %>' />
                    </div>
                    <div class="form-group">
                        員工電話：<asp:Label ID="m_phone" runat="server" Text='<%# Eval("m_phone") %>' />
                    </div>
                    <div class="form-group">
                        用戶信箱：<asp:Label ID="m_email" runat="server" Text='<%# Eval("m_email") %>' />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="bt_position" class="btn" runat="server" Text="更改狀態為" OnClick="btn_position_check" />
                    </div>
                </div>
            </form>
        </div>
    </main>
</asp:Content>
