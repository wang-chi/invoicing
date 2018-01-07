using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class client_new : System.Web.UI.Page
    {
        string c_id, c_name, c_address, c_phone, c_email;//註冊項目
        DBHandle tmp = new DBHandle();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NewId();
            }
        }

        private void NewId()
        {
            String select_all_id = "select top 1 c_id from client order by c_id desc ";
            DataSet ds = tmp.GetNewId(select_all_id);
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables["selectnewid"].Rows)
                {
                    string all_id;
                    all_id = dr["c_id"].ToString();
                    int all_id_new = int.Parse(all_id.Substring(2, 3));
                    if (all_id_new < 9)
                    {
                        all_id = "C000" + (all_id_new + 1);
                    }
                    if (all_id_new < 99 && all_id_new >= 9)
                    {
                        all_id = "C00" + (all_id_new + 1);
                    }
                    if (all_id_new < 999 && all_id_new >= 99)
                    {
                        all_id = "C0" + (all_id_new + 1);
                    }

                    Id.Text = all_id;

                }
            }
        }

        protected void btn_insert_client(object sender, EventArgs e)
        {

            //把畫面中使用者輸入的欄位值都到各個字串中
            c_id = Id.Text;
            c_name = InputName.Text;
            c_address = InputAddress.Text;
            c_phone = InputPhone.Text;
            c_email = InputEmail.Text;

            string client_new;
            string select_id = "SELECT c_id FROM client ";//查詢supplier_id是否有重複

            DataSet ds = tmp.GetClientId(select_id);

            if (ds != null)
            {
                //檢測帳號是否有重複
                foreach (DataRow dr in ds.Tables["ClientInfo"].Rows)
                {
                    string all_id;
                    all_id = dr["c_id"].ToString();
                    if (all_id == c_id)
                    {
                        Msg_ExistID.Visible = true;//帳號已存在隱藏
                    }

                }

                //如果有任一欄位未輸入  則顯示「必填」
                if ((string.IsNullOrWhiteSpace(Id.Text)) || (string.IsNullOrWhiteSpace(InputName.Text)) || (string.IsNullOrWhiteSpace(InputAddress.Text)) || (string.IsNullOrWhiteSpace(InputPhone.Text)) || (string.IsNullOrWhiteSpace(InputEmail.Text)))
                {
                    Label10.Visible = true;
                    Label10.Text = "*必須填入資料";

                }



                //如果必填欄位都輸入,則新增置資料庫中
                if ((!string.IsNullOrWhiteSpace(Id.Text)) && (!string.IsNullOrWhiteSpace(InputName.Text)) && (!string.IsNullOrWhiteSpace(InputAddress.Text)) && (!string.IsNullOrWhiteSpace(InputPhone.Text)) && (!string.IsNullOrWhiteSpace(InputEmail.Text)))
                {
                    client_new = @"Insert Into client (c_id, c_name, c_address, c_phone, c_email, createdate, update_time) 
                    Values('" + c_id + "',N'" + c_name + "',N'" + c_address + "',N'" + c_phone + "','" + c_email + "', GETDATE(), GETDATE())";//新增

                    tmp.Insert(client_new);//用Insert方法

                    Response.Redirect("client_manage.aspx");//跳轉到登入畫面
                }
            }


        }
    }
}