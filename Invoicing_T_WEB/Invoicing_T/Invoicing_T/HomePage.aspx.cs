using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class HomePage : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CheckAuth();//取得權限
            this.ShowSellOfYear();//設定年銷售額
            this.ShowSellOfMounth();//設定本月銷售額
            this.ShowStockOfAll();//目前存貨金額
            this.ShowAccountOfMoney();//應收帳款金額
        }

        private void CheckAuth()
        {
            #region 確認可到訪頁面權限
            if (Session["UserID"] != null)
            {
                String UserID = Session["UserID"].ToString();
                DataSet ds = tmp.CheckAuth(UserID);
                if (ds != null)
                {
                    DataTable dt = ds.Tables["CheckAuth"];

                }
            }
            else
            {
                Response.Redirect("login.aspx");//跳轉到登入頁面
            }
            #endregion
        }

        private void ShowSellOfYear()
        {
            #region 顯示年銷售額
            SellOfYear.Text = "0";
            DataSet ds = tmp.GetSellOfYear();
            decimal amount = 0, total = 0;
            if (ds != null) {
                DataTable dt = ds.Tables["SellOfYear"];
                foreach (DataRow dr in dt.Rows) {
                    total = 0;
                    total = Convert.ToDecimal(dr["orin_price"].ToString().Trim())* Convert.ToDecimal(dr["orin_qty"].ToString().Trim());
                    amount = amount + total;
                }
                SellOfYear.Text = exchange(amount);
                SellOfYearDetail.Text = Convert.ToString(amount);
            }
            #endregion

        }
        private void ShowSellOfMounth()
        {
            #region 顯示月銷售額
            
            DataSet ds = tmp.GetSellOfMounth();
            decimal amount = 0, total = 0;
            if (ds != null)
            {
                DataTable dt = ds.Tables["SellOfMounth"];
                foreach (DataRow dr in dt.Rows)
                {
                    total = 0;
                    total = Convert.ToDecimal(dr["orin_price"].ToString().Trim()) * Convert.ToDecimal(dr["orin_qty"].ToString().Trim());
                    amount = amount + total;
                }
                SellOfMounth.Text = exchange(amount);
                SellOfMounthDetail.Text = Convert.ToString(amount);
            }
            #endregion

        }
        private void ShowStockOfAll()
        {
            #region 顯示庫存總額
            StockOfAll.Text = "88";
            DataSet ds = tmp.GetStockOfAllByPurchases();
            DataSet ds2 = tmp.GetStockOfAllByOrders();
            decimal amount = 0, total = 0;
            decimal amount2 = 0, total2 = 0;
            if (ds != null)
            {
                DataTable dt = ds.Tables["StockOfAll"];
                foreach (DataRow dr in dt.Rows)
                {
                    total = 0;
                    total = Convert.ToDecimal(dr["purin_price"].ToString().Trim()) * Convert.ToDecimal(dr["purin_qty"].ToString().Trim());
                    amount = amount + total;
                }
                if (ds2 != null) {
                    DataTable dt2 = ds2.Tables["StockOfAll"];
                    foreach (DataRow dr in dt2.Rows)
                    {
                        total2 = 0;
                        total2 = Convert.ToDecimal(dr["orin_price"].ToString().Trim()) * Convert.ToDecimal(dr["orin_qty"].ToString().Trim());
                        amount2 = amount2 + total2;
                    }                    
                }
                StockOfAll.Text = exchange(amount-amount2);
                StockOfAllDetail.Text = Convert.ToString(amount-amount2);
            }
            #endregion
        }

        private void ShowAccountOfMoney()
        {
            #region 顯示應受帳款
            AccountOfMoney.Text = "64";
            DataSet ds = tmp.GetAccountOfMoney();
            decimal amount = 0, total = 0;
            if (ds != null)
            {
                DataTable dt = ds.Tables["AccountOfMoney"];
                foreach (DataRow dr in dt.Rows)
                {
                    total = 0;
                    total = Convert.ToDecimal(dr["orin_price"].ToString().Trim()) * Convert.ToDecimal(dr["orin_qty"].ToString().Trim());
                    amount = amount + total;
                }
                AccountOfMoney.Text = exchange(amount);
                AccountOfMoneyDetail.Text = Convert.ToString(amount);
            }
            #endregion

        }

        private String exchange(decimal amount)
        {
            string result = "";
            if (amount > 1000)
            {
                result = Convert.ToString(Math.Truncate(amount / 1000)) + "K+";
            }
            else if (amount > 10000)
            {
                result = Convert.ToString(Math.Truncate(amount / 10000)) + "M+";
            }
            else {
                result = Convert.ToString(amount);
            }
            return result;
        }
    }
}