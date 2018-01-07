using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class group_new : System.Web.UI.Page
    {
        string r_id, r_name; //註冊項目
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
            String select_all_id = "select top 1 r_id from roles order by r_id desc ";
            DataSet ds = tmp.GetNewId(select_all_id);
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables["selectnewid"].Rows)
                {
                    string all_id;
                    all_id = dr["r_id"].ToString();
                    int all_id_new = int.Parse(all_id.Substring(2, 3));
                    if (all_id_new<9)
                    {
                        all_id = "R000" + (all_id_new + 1);
                    }
                    if (all_id_new < 99 && all_id_new >= 9)
                    {
                        all_id = "R00" + (all_id_new + 1);
                    }
                    if (all_id_new < 999 && all_id_new >= 99)
                    {
                        all_id = "R0" + (all_id_new + 1);
                    }

                    Id.Text = all_id;
                   
                }
            }
        }

        protected void btn_insert_group(object sender, EventArgs e)
        {
            //把畫面中使用者輸入的欄位值都到各個字串中
            r_id = Id.Text;
            r_name = InputName.Text;
            
            string id_new;
            string select_id = "SELECT r_id FROM roles ";//查詢member_id是否有重複

            DataSet ds = tmp.GetGroupId(select_id);

            if (ds != null)
            {
                //檢測帳號是否有重複
                foreach (DataRow dr in ds.Tables["groupInfo"].Rows)
                {
                    string all_id;
                    all_id = dr["r_id"].ToString();
                    if (all_id == r_id)
                    {
                        Label12.Visible = true;
                    }
                }

                //如果有任一欄位未輸入  則顯示「必填」
                if ((string.IsNullOrWhiteSpace(Id.Text)) || (string.IsNullOrWhiteSpace(InputName.Text)) )
                {
                    Label2.Visible = true;
                    Label2.Text = "*必須填入資料";

                }
                //如果必填欄位都輸入,則新增置資料庫中
                if (((!string.IsNullOrWhiteSpace(Id.Text)) && (!string.IsNullOrWhiteSpace(InputName.Text))))
                {
                   
                    id_new = @"INSERT INTO roles (r_id,r_name) 
                    VALUES('" + r_id + "',N'" + r_name + "')";//新增

                    tmp.Insert(id_new);//用Insert方法
                    
                    Response.Redirect("group_manage.aspx");//跳轉到登入畫面
                }
            }
        }
    }
}