using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class employee_edit : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 HiddenF_mid.Value = Session["UserID"].ToString();//主索引
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
                RadioButtonList1.SelectedValue = tmpDataRow["m_sex"].ToString();
                r_name.Text = tmpDataRow["r_name"].ToString();
                m_phone.Text = tmpDataRow["m_phone"].ToString();
                m_email.Text = tmpDataRow["m_email"].ToString();
            }

            #endregion
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            #region 修改個人資料
            Dictionary<string, object> tmpViewData = this.SetViewData();//設定畫面中的資料

            //如果有任一欄位未輸入  則顯示「必填」
            if ((string.IsNullOrWhiteSpace(m_name.Text)) || (string.IsNullOrWhiteSpace(RadioButtonList1.SelectedItem.Value)) || (string.IsNullOrWhiteSpace(m_phone.Text)) || (string.IsNullOrWhiteSpace(m_email.Text)))
            {

                Label2.Visible = true;
                Label2.Text = "*必須填入資料";

            }
            //如果必填欄位都輸入,則新增置資料庫中
            if (((!string.IsNullOrWhiteSpace(m_name.Text)) && (!string.IsNullOrWhiteSpace(RadioButtonList1.SelectedItem.Value)) && (!string.IsNullOrWhiteSpace(m_phone.Text)) && (!string.IsNullOrWhiteSpace(m_email.Text))))
            {

                tmp.UpdateMember(tmpViewData);
                Response.Redirect("employee_manage.aspx");//跳轉到登入畫面
            }

            #endregion
        }

        private Dictionary<string, object> SetViewData()//收集資料
        {

            #region 設定畫面中的要修改的資料
            Dictionary<string, object> tmpViewData = new Dictionary<string, object>();//object->可以儲存不同的資料型別
            //TODO : 補
            //("資料庫欄位")
            tmpViewData.Add("m_id", m_id.Text);
            tmpViewData.Add("m_name", m_name.Text);
            tmpViewData.Add("m_sex", RadioButtonList1.SelectedItem.Value);
            tmpViewData.Add("m_phone", m_phone.Text);
            tmpViewData.Add("m_email", m_email.Text);
            return tmpViewData;
            #endregion
        }

    }
}