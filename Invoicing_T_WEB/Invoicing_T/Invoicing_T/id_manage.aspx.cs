using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class id_manage : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();
        protected void Page_Load(object sender, EventArgs e)
        {
            //tmp.DB_Cnstr = "Data Source=DESKTOP-OP0RFML\\SQLEXPRESS;Initial Catalog=Invoicing_T;Integrated Security=False;User ID=user13106;Password=123";//進入資料庫
            tmp.DB_Cnstr = "Server=tcp:nutc106db.database.windows.net,1433;Initial Catalog=invoicing;Persist Security Info=False;User ID={nutc03};Password={NUTCia03};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            if (!IsPostBack)
            {
                this.all(null, null,"");//查詢群組資料
               
            }
        }

        protected void all(object sender, EventArgs e,String p)
        {
            
            #region 查詢帳號資料

            DataSet ds = tmp.Getmember(p);
            if (ds != null)
            {
                lvmemberInfo.DataSource = null;
                lvmemberInfo.DataSource = ds.Tables["member"];
                lvmemberInfo.DataBind();
            }
            
            #endregion
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("id_edit_new.aspx");//跳轉到新增頁面
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String selection = " WHERE m_id LIKE '%" + TextBox1.Text+"%'";
            all(null, null, selection);
        }
    }
}