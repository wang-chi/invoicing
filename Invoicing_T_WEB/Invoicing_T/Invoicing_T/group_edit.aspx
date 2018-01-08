<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="group_edit.aspx.cs" Inherits="Invoicing_T.group_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>角色資料修改</h1>
        <form id="form1" runat="server">
            <asp:HiddenField ID="HiddenF_ActionState" runat="server" />
            <asp:HiddenField ID="HiddenF_rid" runat="server" />
            <div class="form-group row">
                <label>群組ID：</label>
                <asp:Label ID="r_id" runat="server" Text='<%# Eval("r_id") %>' />
            </div>
            <div class="form-group row">
                <div>

                    <label>群組名稱：</label>
                </div>
                <div>
                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>


            <div>
                <asp:ListView ID="lvgroupInfo" runat="server" GroupItemCount="1"
                    GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr class="success">
                                    <th width="50%">
                                        <asp:Label ID="Label8" runat="server" Text="權限名稱"></asp:Label></th>
                                    <th width="50%">
                                        <asp:Label ID="Label1" runat="server" Text="是否有權限"></asp:Label></th>

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
                                <asp:Label ID="auth_name" runat="server" Text=' <%# Eval("a_name") %> '></asp:Label>
                                
                                <asp:Label ID="raid" runat="server" Text=' <%# Eval("ra_id") %> ' Visible="false" ></asp:Label>
                                
                            </td>
                            <td>
                                <asp:RadioButtonList ID="viewmode" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Width="100%" SelectedValue='<%# Eval("viewmode") %>'>
                                    <asp:ListItem Selected="False" Value="True">有　</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="False">無　</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>

                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>

            <div class="form-group">
                <asp:Button ID="btnUpdate" class="btn btn-success" runat="server" Text="修改" Visible="false" OnClick="btn_Click" />
                <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" Text="刪除" Visible="false" />
            </div>


        </form>
    </main>
</asp:Content>
