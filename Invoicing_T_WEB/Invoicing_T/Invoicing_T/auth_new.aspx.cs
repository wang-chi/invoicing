using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class auth_new : System.Web.UI.Page
    {
        string a_id, a_name; //註冊項目
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
            String select_all_id = "select top 1 a_id from auth order by a_id desc ";
            DataSet ds = tmp.GetNewId(select_all_id);
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables["selectnewid"].Rows)
                {
                    string all_id;
                    all_id = dr["a_id"].ToString();
                    int all_id_new = int.Parse(all_id.Substring(2, 3));
                    if (all_id_new < 9)
                    {
                        all_id = "A000" + (all_id_new + 1);
                    }
                    if (all_id_new < 99 && all_id_new >= 9)
                    {
                        all_id = "A00" + (all_id_new + 1);
                    }
                    if (all_id_new < 999 && all_id_new >= 99)
                    {
                        all_id = "A0" + (all_id_new + 1);
                    }

                    ID.Text = all_id;

                }
            }
        }

        protected void btn_insert_auth(object sender, EventArgs e)
        {
            //把畫面中使用者輸入的欄位值都到各個字串中
            a_id = ID.Text;
            a_name = InputName.Text;

            string auth_new;
            string select_id = "SELECT a_id FROM auth ";//查詢member_id是否有重複

            DataSet ds = tmp.GetAuthId(select_id);

            if (ds != null)
            {
                //檢測帳號是否有重複
                foreach (DataRow dr in ds.Tables["authInfo"].Rows)
                {
                    string all_id;
                    all_id = dr["a_id"].ToString();
                    if (all_id == a_id)
                    {
                        Msg_ExistID.Visible = true;
                    }
                }

                //如果有任一欄位未輸入  則顯示「必填」
                if ((string.IsNullOrWhiteSpace(ID.Text)) || (string.IsNullOrWhiteSpace(InputName.Text)))
                {
                    Label13.Visible = true;
                    Label13.Text = "*必須填入資料";

                }
                //如果必填欄位都輸入,則新增置資料庫中
                if (((!string.IsNullOrWhiteSpace(ID.Text)) && (!string.IsNullOrWhiteSpace(InputName.Text))))
                {
                    auth_new = @"INSERT INTO auth (a_id,a_name) 
                    VALUES('" + a_id + "',N'" + a_name + "')";//新增

                    tmp.Insert(auth_new);//用Insert方法

                    Response.Redirect("auth_manage.aspx");//跳轉到登入畫面
                }
            }
        }
    }
}