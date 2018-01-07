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

        private void CheckAuth() {
            #region 確認可到訪頁面權限
            if (Session["UserID"] != null)
            {
                String UserID = Session["UserID"].ToString();
                DataSet ds = tmp.CheckAuth(UserID);
                if (ds != null)
                {
                    DataTable dt = ds.Tables["CheckAuth"];

                }
            }else
            {
                Response.Redirect("login.aspx");//跳轉到登入頁面
            }
            #endregion
        }

        private void ShowSellOfYear() {
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
            SellOfMounth.Text = "78";
            
            DataSet ds = tmp.GetSellOfYear();
            decimal amount = 0, total = 0;
            if (ds != null)
            {
                DataTable dt = ds.Tables["SellOfYear"];
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
            #endregion


        }
        private void ShowAccountOfMoney()
        {
            #region 顯示應受帳款
            AccountOfMoney.Text = "64";
            #endregion
            
        }

        private String exchange(decimal amount) {
            string result="";
            if (amount > 1000)
            {
                result = Convert.ToString(amount / 1000) + "K+";
            }
            else if (amount > 10000) {
                result = Convert.ToString(amount / 10000) + "M+";
            }
            return result;
        }
    }
}