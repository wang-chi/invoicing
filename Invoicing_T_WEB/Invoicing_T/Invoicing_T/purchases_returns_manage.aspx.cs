using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class purchases_returns_manage : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.all(null, null, "");//查詢群組資料

            }
        }

        protected void all(object sender, EventArgs e, String p)
        {

            #region 查詢銷貨單資料

            DataSet ds = tmp.GetPurchasesReturnsManage(p);
            if (ds != null)
            {
                IvPurchasesReturnsInfo.DataSource = null;
                IvPurchasesReturnsInfo.DataSource = ds.Tables["purchases_returns"];
                IvPurchasesReturnsInfo.DataBind();
            }

            #endregion
        }

        protected void btn_insert_purchases_returns_Click(object sender, EventArgs e)
        {
            Response.Redirect("purchases_returns_new.aspx");//跳轉到新增頁面
        }

        protected void btn_search(object sender, EventArgs e)
        {
            String selection = " WHERE pr_id LIKE '%" + InputPurchasesReturns.Text + "%'";
            all(null, null, selection);
        }
    }
}