using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class company_edit : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();
       

        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void btnUpdateCompany_Click(object sender, EventArgs e)
        {

            #region 修改公司資料
            Dictionary<string, object> tmpViewData = this.SetViewData();//設定畫面中的資料
            
                //如果有任一欄位未輸入  則顯示「必填」
                if ((string.IsNullOrWhiteSpace(com_name.Text)) || (string.IsNullOrWhiteSpace(com_address.Text)) || (string.IsNullOrWhiteSpace(com_un.Text)) || (string.IsNullOrWhiteSpace(com_agent.Text)) || (string.IsNullOrWhiteSpace(com_tel.Text)) || (string.IsNullOrWhiteSpace(com_fax.Text)))
                {

                Label2.Visible = true;
                Label2.Text = "*必須填入資料";

                }
                //如果必填欄位都輸入,則新增置資料庫中
                if (((!string.IsNullOrWhiteSpace(com_name.Text)) && (!string.IsNullOrWhiteSpace(com_address.Text)) && (!string.IsNullOrWhiteSpace(com_un.Text)) && (!string.IsNullOrWhiteSpace(com_agent.Text)) && (!string.IsNullOrWhiteSpace(com_tel.Text)) && (!string.IsNullOrWhiteSpace(com_fax.Text))))
                {

                tmp.UpdateCompany(tmpViewData);
                Response.Redirect("company_manage.aspx");//跳轉到登入畫面
                }
            
            #endregion
        }

        private Dictionary<string, object> SetViewData()//收集資料
        {
           
            #region 設定畫面中的要修改的資料
            Dictionary<string, object> tmpViewData = new Dictionary<string, object>();//object->可以儲存不同的資料型別
            //TODO : 補
            //("資料庫欄位")
            tmpViewData.Add("com_name", com_name.Text);
            tmpViewData.Add("com_address", com_address.Text);
            tmpViewData.Add("com_un", com_un.Text);
            tmpViewData.Add("com_agent", com_agent.Text);
            tmpViewData.Add("com_tel", com_tel.Text);
            tmpViewData.Add("com_fax", com_fax.Text);
            return tmpViewData;
            #endregion
        }

    }
}