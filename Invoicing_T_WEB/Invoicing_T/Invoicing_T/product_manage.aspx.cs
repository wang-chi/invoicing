using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class product_manage : System.Web.UI.Page
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

            #region 查詢帳號資料

            DataSet ds = tmp.GetProduct(p);
            if (ds != null)
            {
                lvproductInfo.DataSource = null;
                lvproductInfo.DataSource = ds.Tables["product"];
                lvproductInfo.DataBind();
            }

            #endregion
        }
       
        protected void btn_search_Click(object sender, EventArgs e)
        {
            String selection = " WHERE p_id LIKE '%" + InputProductID.Text + "%'";
            all(null, null, selection);
        }

        protected void btn_insert_product_Click(object sender, EventArgs e)
        {
            Response.Redirect("product_new.aspx");//跳轉到新增頁面
        }
    }
}