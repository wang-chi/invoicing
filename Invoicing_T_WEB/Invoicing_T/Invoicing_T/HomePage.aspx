<<<<<<< HEAD
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="false" CodeBehind="HomePage.aspx.cs" Inherits="Invoicing_T.HomePage" %>
=======
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/side.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Invoicing_T.HomePage" %>
>>>>>>> CJT

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="col-sm-9 ml-sm-auto col-md-10 pt-3">
        <h1>Dashboard</h1>
        <section class="row text-center placeholders">
            <div class="col-6 col-sm-3 placeholder">
<<<<<<< HEAD
                <img src="data:image/gif;base64,R0lGODlhAQABAIABAAJ12AAAACwAAAAAAQABAAACAkQBADs=" width="200" height="200" class="img-fluid rounded-circle" alt="Generic placeholder thumbnail" />
                <h4>Label</h4>
                <div class="text-muted">年度銷售額</div>
            </div>
            <div class="col-6 col-sm-3 placeholder">
                <img src="data:image/gif;base64,R0lGODlhAQABAIABAADcgwAAACwAAAAAAQABAAACAkQBADs=" width="200" height="200" class="img-fluid rounded-circle" alt="Generic placeholder thumbnail" />
                <h4>Label</h4>
                <span class="text-muted">本月銷售額</span>
            </div>
            <div class="col-6 col-sm-3 placeholder">
                <img src="data:image/gif;base64,R0lGODlhAQABAIABAAJ12AAAACwAAAAAAQABAAACAkQBADs=" width="200" height="200" class="img-fluid rounded-circle" alt="Generic placeholder thumbnail" />
                <h4>Label</h4>
                <span class="text-muted">目前存貨金額</span>
            </div>
            <div class="col-6 col-sm-3 placeholder">
                <img src="data:image/gif;base64,R0lGODlhAQABAIABAADcgwAAACwAAAAAAQABAAACAkQBADs=" width="200" height="200" class="img-fluid rounded-circle" alt="Generic placeholder thumbnail" />
                <h4>Label</h4>
                <span class="text-muted">應收帳款金額</span>
            </div>
        </section>
        <h1>Dashboard</h1>
=======
                <div style="width: 10vw; height: 20vh;">
                    <asp:Label ID="SellOfYear" class="SellNumber" runat="server" Text="0"></asp:Label>
                </div>
                <asp:Label ID="SellOfYearDetail" class="SellNumberDetail" runat="server" Text="0"></asp:Label>
                <div class="text-muted"><label>年度銷售額</label></div>
            </div>
            <div class="col-6 col-sm-3 placeholder">
                <div style="width: 10vw; height: 20vh;">
                    <asp:Label ID="SellOfMounth" class="SellNumber" runat="server" Text="0"></asp:Label>
                </div>
                <asp:Label ID="SellOfMounthDetail" class="SellNumberDetail" runat="server" Text="0"></asp:Label>
                <div class="text-muted"><label>本月銷售額</label></div>
            </div>
            <div class="col-6 col-sm-3 placeholder">
                <div style="width: 10vw; height: 20vh;">
                    <asp:Label ID="StockOfAll" class="SellNumber" runat="server" Text="0"></asp:Label>
                </div>
                <asp:Label ID="StockOfAllDetail" class="SellNumberDetail" runat="server" Text="0"></asp:Label>
                <div class="text-muted"><label>目前存貨金額</label></div>
            </div>
            <div class="col-6 col-sm-3 placeholder">
                <div style="width: 10vw; height: 20vh;">
                    <asp:Label ID="AccountOfMoney" class="SellNumber" runat="server" Text="0"></asp:Label>
                </div>
                <asp:Label ID="AccountOfMoneyDetail" class="SellNumberDetail" runat="server" Text="0"></asp:Label>
                <div class="text-muted"><label>應收帳款金額</label></div>
            </div>
        </section>
  
>>>>>>> CJT
    </main>
</asp:Content>
