using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class member_manage : System.Web.UI.Page
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

            DataSet ds = tmp.GetMember(p);//取得營地資料
            if (ds != null)
            {
                lvmemberInfo.DataSource = null;
                lvmemberInfo.DataSource = ds.Tables["member"];
                lvmemberInfo.DataBind();
            }

            #endregion
        }

        protected void btn_insert_member(object sender, EventArgs e)
        {
            Response.Redirect("member_new.aspx");//跳轉到新增頁面
        }

        protected void btn_search(object sender, EventArgs e)
        {
            String selection = " AND m_id LIKE '%" + InputMemberID.Text + "%'";
            all(null, null, selection);
        }
    }
}