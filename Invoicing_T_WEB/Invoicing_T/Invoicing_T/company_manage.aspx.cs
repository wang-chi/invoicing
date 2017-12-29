using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class company_manage : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();

        protected void Page_Load(object sender, EventArgs e)
        {
            //String this_position = Session["m_id"].ToString();
            if (!IsPostBack)
            {
                this.SetMaintainData();//設定資料

            }
        }

        private void SetMaintainData()
        {

            #region 查詢公司資料

            DataSet ds1 = tmp.GetCompanyInfo();//取得公司資料
            if (ds1 != null)
            {
                DataRow tmpDataRow = ds1.Tables["company_info"].Rows[0];

                com_id.Text = tmpDataRow["com_id"].ToString();
                com_name.Text = tmpDataRow["com_name"].ToString();
                com_address.Text = tmpDataRow["com_address"].ToString();
                com_un.Text = tmpDataRow["com_un"].ToString();
                com_agent.Text = tmpDataRow["com_agent"].ToString();
                com_tel.Text = tmpDataRow["com_tel"].ToString();
                com_fax.Text = tmpDataRow["com_fax"].ToString();
            }
            
            #endregion
        }

        protected void btn_company_edit_Click(object sender, EventArgs e)
        {
            Server.Transfer("company_edit.aspx", true);//導到修改頁
        }
    }
}