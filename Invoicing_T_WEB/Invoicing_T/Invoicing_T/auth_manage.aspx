﻿<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="auth_manage.aspx.cs" Inherits="Invoicing_T.auth_manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <form runat="server">
            <h1>權限查詢</h1>
            <asp:Label ID="Label3" runat="server" Text="請以權限ID查詢："></asp:Label>
            <asp:TextBox ID="InputSearchAuthID" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="查詢" OnClick="btn_search" />
            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="新增" OnClick="btn_insert_auth" />

            <h1>總覽</h1>
            <div>
                <asp:ListView ID="lvauthInfo" runat="server" GroupItemCount="1"
                    GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr class="success">
                                    <th width="25%">
                                        <asp:Label ID="Label8" runat="server" Text="編輯"></asp:Label></th>
                                    <th width="25%">
                                        <asp:Label ID="Label1" runat="server" Text="刪除"></asp:Label></th>
                                    <th width="25%">
                                        <asp:Label ID="Label10" runat="server" Text="權限ID"></asp:Label></th>
                                    <th width="25%">
                                        <asp:Label ID="Label14" runat="server" Text="權限名稱"></asp:Label></th>

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
                                <asp:LinkButton ID="lbtnUpdate" runat="server" CssClass="btn btn-danger btn-sm" PostBackUrl='<%# "auth_edit.aspx?ActionState=UpDate&a_id="+Eval("a_id")%>' ToolTip="修改">
                                    <asp:Label ID="Label7" runat="server" Text="修改"></asp:Label>
                                </asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-danger btn-sm" PostBackUrl='<%# "auth_edit.aspx?ActionState=Delete&a_id="+Eval("a_id")%>' ToolTip="刪除">
                                    <asp:Label ID="Label2" runat="server" Text="刪除"></asp:Label>
                                </asp:LinkButton>
                            </td>
                            <td><%# Eval("a_id") %></td>
                            <td><%# Eval("a_name") %></td>

                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </form>
    </main>
</asp:Content>
