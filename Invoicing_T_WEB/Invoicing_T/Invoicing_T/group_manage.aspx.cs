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
            tmp.DB_Cnstr = "Data Source=DESKTOP-OP0RFML\\SQLEXPRESS;Initial Catalog=Invoicing_T;Integrated Security=False;User ID=user13106;Password=123";//進入資料庫
            if (!IsPostBack)
            {
                this.all(null, null);//查詢群組資料
                
            }
        }

  
        protected void all(object sender, EventArgs e)
        {
            #region 查詢群組資料
            Dictionary<string, object> tmpFilter = new Dictionary<string, object>();//建立新的字典以方便查詢
           
            DataSet ds = tmp.Getgroup(tmpFilter);
            if (ds != null)
            {
                lvCampInfo.DataSource = null;
                lvCampInfo.DataSource = ds.Tables["roles"];
                lvCampInfo.DataBind();
            }
            


            #endregion
        }

       
    }
}