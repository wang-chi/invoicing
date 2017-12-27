using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class id_edit_new : System.Web.UI.Page
    {
        string m_id, m_pwd, m_position, m_name, m_sex, r_id, m_number, m_email, m_phone;//註冊項目


        DBHandle tmp = new DBHandle();

        protected void Page_Load(object sender, EventArgs e)
        {
            //tmp.DB_Cnstr = "Data Source=DESKTOP-OP0RFML\\SQLEXPRESS;Initial Catalog=Invoicing_T;Integrated Security=False;User ID=user13106;Password=123";//進入資料庫
            tmp.DB_Cnstr = "Server=tcp:nutc106db.database.windows.net,1433;Initial Catalog=invoicing;Persist Security Info=False;User ID={nutc03};Password={NUTCia03};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            Label8.Visible = false;

            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            //把畫面中使用者輸入的欄位值都到各個字串中
            m_id = TextBox6.Text;
            m_pwd = TextBox7.Text;
            m_position = RadioButtonList2.SelectedItem.Value;
            m_name = TextBox1.Text;
            m_sex = RadioButtonList1.SelectedItem.Value;
            r_id = TextBox2.Text;
            m_number = TextBox3.Text;
            m_phone = TextBox4.Text;
            m_email = TextBox5.Text;

            string id_edit_new;
            string select_id = "Select m_id From member ";//查詢member_id是否有重複

            DataSet ds = tmp.Getid(select_id);

            if (ds != null)
            {
                //檢測帳號是否有重複
                foreach (DataRow dr in ds.Tables["idInfo"].Rows)
                {
                    string all_id;
                    all_id = dr["m_id"].ToString();
                    if (all_id == m_id)
                    {
                        Label9.Visible = true;
                    }

                }

                //如果有任一欄位未輸入  則顯示「必填」
                if ((string.IsNullOrWhiteSpace(TextBox6.Text)) || (string.IsNullOrWhiteSpace(TextBox7.Text)) || (string.IsNullOrWhiteSpace(TextBox1.Text)) || (string.IsNullOrWhiteSpace(TextBox2.Text)) || (string.IsNullOrWhiteSpace(TextBox3.Text)) || (string.IsNullOrWhiteSpace(TextBox4.Text)) || (string.IsNullOrWhiteSpace(TextBox5.Text)))
                {
                    Label10.Visible = true;
                    Label10.Text = "*必須填入資料";

                }



                //如果必填欄位都輸入,則新增置資料庫中
                if ((!string.IsNullOrWhiteSpace(TextBox6.Text) && (!string.IsNullOrWhiteSpace(TextBox7.Text)) && (!string.IsNullOrWhiteSpace(TextBox1.Text)) && (!string.IsNullOrWhiteSpace(TextBox2.Text)) && (!string.IsNullOrWhiteSpace(TextBox3.Text)) && (!string.IsNullOrWhiteSpace(TextBox4.Text)) && (!string.IsNullOrWhiteSpace(TextBox5.Text))))
                {
                    // DateTime dt = DateTime.NOw; // 取得現在時間
                    //String str = dt.ToString(); // 轉成字串，例：2012/6/5 下午 04:43:57


                    id_edit_new = @"Insert Into member (m_id,m_pwd,m_position,m_name,m_sex,r_id,m_number,m_email,m_phone,createdate,update_time) 
                    Values('" + m_id + "','" + m_pwd + "','" + m_position + "',N'" + m_name + "','" + m_sex + "','" + r_id + "','" + m_number + "','" + m_email + "','" + m_phone + "', GETDATE(), GETDATE())";//新增

                    tmp.Insert(id_edit_new);//用Insert方法

                    Response.Redirect("id_manage.aspx");//跳轉到登入畫面
                }
            }


        }
    }
}