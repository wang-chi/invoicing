<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="member_manage.aspx.cs" Inherits="Invoicing_T.member_manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <form runat="server">
            <h1>帳號查詢</h1>
            <div class="form-group row">
                <asp:Label ID="Label3" runat="server" Text="請以用戶ID查詢："/>
                <div class="col-sm-3">
                    <asp:TextBox ID="InputMemberID" CssClass="form-control" runat="server" aria-label="Search"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="查詢" OnClick="btn_search" />
                </div>
                <div class="form-group">
                    <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="新增" OnClick="btn_insert_member" />
                </div>
            </div>
            <h1>總覽</h1>
            <div>
                <asp:ListView ID="lvmemberInfo" runat="server" GroupItemCount="1" GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr class="success">
                                    <th width="20%">
                                        <asp:Label ID="Label2" runat="server" Text="編輯狀態"></asp:Label></th>
                                    <th width="20%">
                                        <asp:Label ID="Label10" runat="server" Text="用戶ID"></asp:Label></th>

                                    <th width="20%">
                                        <asp:Label ID="Label27" runat="server" Text="用戶狀態"></asp:Label></th>
                                    <th width="20%">
                                        <asp:Label ID="Label1" runat="server" Text="用戶名稱"></asp:Label></th>

                                    <th width="20%">
                                        <asp:Label ID="Label4" runat="server" Text="用戶角色"></asp:Label></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lbtnUpdate" runat="server" CssClass="btn btn-danger btn-sm" PostBackUrl='<%# "member_edit.aspx?ActionState=UpDate&m_id="+Eval("m_id")%>' ToolTip="修改">
                                    <asp:Label ID="Label7" runat="server" Text="修改"></asp:Label>
                                </asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="member_id" runat="server" Text='<%# Eval("m_id") %>'></asp:Label></td>

                            <td><%# Eval("m_state") %></td>
                            <td><%# Eval("m_name") %></td>
                            <td><%# Eval("r_name") %></td>

                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </form>
    </main>

</asp:Content>
