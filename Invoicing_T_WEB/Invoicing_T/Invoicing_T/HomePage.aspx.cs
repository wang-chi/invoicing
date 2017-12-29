using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class home : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CheckAuth();
        }

        private void CheckAuth() {
            #region 確認可到訪頁面權限
            String UserID = Session["UserID"].ToString();
            DataSet ds = tmp.GetAuth(UserID);
            if (ds != null)
            {
                
            }
            #endregion
        }
    }
}