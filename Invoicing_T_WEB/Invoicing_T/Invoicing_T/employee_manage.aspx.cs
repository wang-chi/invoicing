using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class employee_manage : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                    HiddenF_mid.Value =Session["UserID"].ToString();//主索引
                    this.SetMaintainData(HiddenF_mid.Value);//設定要維護的資料
                

            }
        }

        private void SetMaintainData(String p)
        {

            #region 查詢個人資料

            DataSet ds1 = tmp.GetMemberEdit(p);//取得公司資料
            if (ds1 != null)
            {
                DataRow tmpDataRow = ds1.Tables["member"].Rows[0];

                m_id.Text = tmpDataRow["m_id"].ToString();
                m_name.Text = tmpDataRow["m_name"].ToString();
                if (tmpDataRow["m_sex"].ToString() == "M")
                {
                    m_sex.Text = "男";
                }
                if (tmpDataRow["m_sex"].ToString() == "F")
                {
                    m_sex.Text = "女";
                }
                r_name.Text = tmpDataRow["r_name"].ToString();
                m_phone.Text = tmpDataRow["m_phone"].ToString();
                m_email.Text = tmpDataRow["m_email"].ToString();
            }

            #endregion
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Server.Transfer("employee_edit.aspx", true);//導到修改頁
        }
        
    }
}