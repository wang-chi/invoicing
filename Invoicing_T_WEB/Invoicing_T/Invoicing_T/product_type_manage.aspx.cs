using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class product_type_manage : System.Web.UI.Page
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

            #region 查詢商品類別資料

            DataSet ds = tmp.GetProductType(p);
            if (ds != null)
            {
                IvClientInfo.DataSource = null;
                IvClientInfo.DataSource = ds.Tables["product_type"];
                IvClientInfo.DataBind();
            }

            #endregion
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            String selection = " WHERE pt_id LIKE '%" + InputProductType.Text + "%'";
            all(null, null, selection);
        }

        protected void btn_insert_product_type_Click(object sender, EventArgs e)
        {
            Response.Redirect("product_type_new.aspx");//跳轉到新增頁面
        }
    }
}