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
            //tmp.DB_Cnstr = "Data Source=DESKTOP-OP0RFML\\SQLEXPRESS;Initial Catalog=Invoicing_T;Integrated Security=False;User ID=user13106;Password=123";//進入資料庫
            tmp.DB_Cnstr = "Server=tcp:nutc106db.database.windows.net,1433;Initial Catalog=invoicing;Persist Security Info=False;User ID={nutc03};Password={NUTCia03};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            if (!IsPostBack)
            {
                this.all(null, null);//查詢群組資料
            }
        }

        protected void all(object sender, EventArgs e)
        {
            #region 查詢權限資料

            DataSet ds = tmp.Getauth();
            if (ds != null)
            {
                lvauthInfo.DataSource = null;
                lvauthInfo.DataSource = ds.Tables["authgroup"];
                lvauthInfo.DataBind();
            }
            #endregion
        }

        
    }
}