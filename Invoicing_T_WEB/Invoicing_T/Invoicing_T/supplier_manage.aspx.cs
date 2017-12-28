using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class supplier_mange : System.Web.UI.Page
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

            DataSet ds = tmp.GetSupplier(p);
            if (ds != null)
            {
                IvSupplierInfo.DataSource = null;
                IvSupplierInfo.DataSource = ds.Tables["supplier"];
                IvSupplierInfo.DataBind();
            }

            #endregion
        }

        protected void btn_insert_supplier(object sender, EventArgs e)
        {
            Response.Redirect("supplier_edit_new.aspx");//跳轉到新增頁面
        }

        protected void btn_search(object sender, EventArgs e)
        {
            String selection = " WHERE s_id LIKE '%" + InputSupplier.Text + "%'";
            all(null, null, selection);
        }
    }
}