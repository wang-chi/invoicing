using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class member_new : System.Web.UI.Page
    {
        string m_id, m_pwd, m_state, m_name, m_sex, r_id, m_email, m_phone;//註冊項目
        DBHandle tmp = new DBHandle();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label8.Visible = false;//改下拉選單註解
            //UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        }

        protected void btn_insert_member(object sender, EventArgs e)
        {

            //把畫面中使用者輸入的欄位值都到各個字串中
            m_id = InputID.Text;
            m_pwd = InputPWD.Text;
            m_state = RadioButtonList2.SelectedItem.Value;
            m_name = InputName.Text;
            m_sex = RadioButtonList1.SelectedItem.Value;
            r_id = InputRoles.Text;
            m_phone = InputPhone.Text;
            m_email = InputEmail.Text;

            string id_new;
            string select_id = "SELECT m_id FROM member ";//查詢member_id是否有重複
            DataSet ds = tmp.GetId(select_id);

            if (ds != null)
            {
                //檢測帳號是否有重複
                foreach (DataRow dr in ds.Tables["idInfo"].Rows)
                {
                    string all_id;
                    all_id = dr["m_id"].ToString();
                    if (all_id == m_id)
                    {
                        Msg_ExistID.Visible = true;//帳號已存在隱藏
                    }

                }
                //如果有任一欄位未輸入  則顯示「必填」
                if ((string.IsNullOrWhiteSpace(InputID.Text)) || (string.IsNullOrWhiteSpace(InputPWD.Text)) || (string.IsNullOrWhiteSpace(InputName.Text)) || (string.IsNullOrWhiteSpace(InputRoles.Text)) || (string.IsNullOrWhiteSpace(InputPhone.Text)) || (string.IsNullOrWhiteSpace(InputEmail.Text)))
                {
                    Label10.Visible = true;
                    Label10.Text = "*必須填入資料";

                }
                //如果必填欄位都輸入,則新增置資料庫中
                if ((!string.IsNullOrWhiteSpace(InputID.Text) && (!string.IsNullOrWhiteSpace(InputPWD.Text)) && (!string.IsNullOrWhiteSpace(InputName.Text)) && (!string.IsNullOrWhiteSpace(InputRoles.Text)) && (!string.IsNullOrWhiteSpace(InputPhone.Text)) && (!string.IsNullOrWhiteSpace(InputEmail.Text))))
                {
 
                    id_new = @"Insert Into member (m_id,m_pwd,m_state,m_name,m_sex,r_id,m_email,m_phone,createdate,update_time) 
                    Values('" + m_id + "','" + m_pwd + "','" + m_state + "',N'" + m_name + "','" + m_sex + "','" + r_id  + "','" + m_email + "','" + m_phone + "', GETDATE(), GETDATE())";//新增
                    tmp.Insert(id_new);//用Insert方法
                    Response.Redirect("member_manage.aspx");//跳轉到登入畫面
                }
            }


        }
    }
}