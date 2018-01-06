using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class HomePage : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CheckAuth();
        }

        private void CheckAuth() {
            #region 確認可到訪頁面權限
            if (Session["UserID"] != null)
            {
                String UserID = Session["UserID"].ToString();
                DataSet ds = tmp.CheckAuth(UserID);
                if (ds != null)
                {
                    DataTable dt = ds.Tables["CheckAuth"];

                }
            }else
            {
                Response.Redirect("login.aspx");//跳轉到登入頁面
            }
            #endregion
        }

    }
}