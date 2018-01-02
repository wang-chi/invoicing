using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class client_manage : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.all(null, null,"");//查詢群組資料
            }
        }
        protected void all(object sender, EventArgs e, String p)
        {
            #region 查詢客戶資料

            DataSet ds = tmp.GetClient();
            if (ds != null)
            {
                IvClientInfo.DataSource = null;
                IvClientInfo.DataSource = ds.Tables["client"];
                IvClientInfo.DataBind();
            }
            #endregion
        }
        protected void btn_insert_client(object sender, EventArgs e)
        {
            Response.Redirect("client_new.aspx");//跳轉到新增頁面
        }

        protected void btn_search(object sender, EventArgs e)
        {
            String selection = " WHERE c_id LIKE '%" + InputSearchClientID.Text + "%'";
            all(null, null, selection);
        }
    }
}