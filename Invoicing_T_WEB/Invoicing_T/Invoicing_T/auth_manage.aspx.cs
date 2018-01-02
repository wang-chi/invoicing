using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class auth_manage : System.Web.UI.Page
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
            #region 查詢權限資料

            DataSet ds = tmp.GetAuth(p);
            if (ds != null)
            {
                lvauthInfo.DataSource = null;
                lvauthInfo.DataSource = ds.Tables["authgroup"];
                lvauthInfo.DataBind();
            }
            #endregion
        }
        protected void btn_insert_auth(object sender, EventArgs e)
        {
            Response.Redirect("auth_new.aspx");//跳轉到新增頁面
        }

        protected void btn_search(object sender, EventArgs e)
        {
            String selection = " WHERE a_id LIKE '%" + InputSearchAuthID.Text + "%'";
            all(null, null, selection);
        }

    }
}