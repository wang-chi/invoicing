using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class supplier_price_manage : System.Web.UI.Page
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

            #region 查詢進貨資料

            DataSet ds = tmp.GetSupplierPriceInfo(p);
            if (ds != null)
            {
                IvSupplierPriceInfo.DataSource = null;
                IvSupplierPriceInfo.DataSource = ds.Tables["supplier_price_info"];
                IvSupplierPriceInfo.DataBind();
            }

            #endregion
        }
        
        protected void btn_search(object sender, EventArgs e)
        {
            String selection = " WHERE sp_id LIKE '%" + InputSupplier.Text + "%'";
            all(null, null, selection);
        }
    }
}