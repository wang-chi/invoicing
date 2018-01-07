using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class order_manage : System.Web.UI.Page
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

            DataSet ds = tmp.GetOrders(p);
            if (ds != null)
            {
                IvOrdersInfo.DataSource = null;
                IvOrdersInfo.DataSource = ds.Tables["orders"];
                IvOrdersInfo.DataBind();
            }

            #endregion
        }

        protected void btn_search(object sender, EventArgs e)
        {
            String selection = " WHERE or_id LIKE '%" + InputOrders.Text + "%'";
            all(null, null, selection);
        }

        protected void btn_insert_orders_Click(object sender, EventArgs e)
        {
            Response.Redirect("orders_new.aspx");//跳轉到登入畫面
        }
    }
}