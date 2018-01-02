using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class group_manage : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.all(null, null,"");//查詢群組資料
                
            }
        }
          
        protected void all(object sender, EventArgs e,String p)
        {
            #region 查詢群組資料
            DataSet ds = tmp.GetGroup(p);
            if (ds != null)
            {
                lvCampInfo.DataSource = null;
                lvCampInfo.DataSource = ds.Tables["roles"];
                lvCampInfo.DataBind();
            }          
            #endregion
        }

        protected void btn_insert_group(object sender, EventArgs e)
        {
            Response.Redirect("group_new.aspx");//跳轉到新增頁面
        }

        protected void btn_search(object sender, EventArgs e)
        {
            String selection = " WHERE r_id LIKE '%" + TextBox1.Text + "%'";
            all(null, null, selection);
        }
        
    }
}