using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class id_edit : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();
        String member_tmp_p;
        protected void Page_Load(object sender, EventArgs e)
        {
            //String this_position = Session["m_id"].ToString();
            if (!IsPostBack)
            {
                if (Request.QueryString["m_id"] != null)//要判斷一下是否有該URL參數
                {
                    HiddenF_mid.Value = Request.QueryString["m_id"].ToString();//主索引
                    this.SetMaintainData(HiddenF_mid.Value);//設定要維護的資料
                }

            }
        }

        private void SetMaintainData(string p)
        {

            #region 查詢帳號資料
            
            DataSet ds1 = tmp.GetMemberInfo(p);//取得營地資料
            if (ds1 != null)
            {
                DataRow tmpDataRow = ds1.Tables["member_info"].Rows[0];

                m_id.Text = tmpDataRow["m_id"].ToString();
                m_pwd.Text = tmpDataRow["m_pwd"].ToString();
                m_position.Text = tmpDataRow["m_position"].ToString();
                m_name.Text = tmpDataRow["m_name"].ToString();
                m_sex.Text = tmpDataRow["m_sex"].ToString();
                r_id.Text = tmpDataRow["r_id"].ToString();
                m_number.Text = tmpDataRow["m_number"].ToString();
                m_phone.Text = tmpDataRow["m_phone"].ToString();
                m_email.Text = tmpDataRow["m_email"].ToString();
            }
            
            if(m_position.Text== "True")
            {
                m_position.Text = "啟用中";
                bt_position.Text = "停權";
                bt_position.CssClass = "btn btn-danger";
            }

            if (m_position.Text == "False")
            {
                m_position.Text = "停權中";
                bt_position.Text = "啟用";
                bt_position.CssClass = "btn btn-success";
            }

            #endregion
        }

        protected void btn_position_check(object sender, EventArgs e) {
            if (m_position.Text == "啟用中")
            {
                member_tmp_p = "False";
            }

            if (m_position.Text == "停權中")
            {
                member_tmp_p = "True";
            }
            tmp.UpdateMemberData(member_tmp_p, m_id.Text);

            Server.Transfer("id_manage.aspx", true);//導回查詢頁
        }

   
    }
}