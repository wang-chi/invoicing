using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class group_edit_new : System.Web.UI.Page
    {
        string r_id, r_name; //註冊項目
        DBHandle tmp = new DBHandle();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_insert_group(object sender, EventArgs e)
        {
            //把畫面中使用者輸入的欄位值都到各個字串中
            r_id = InputId.Text;
            r_name = InputName.Text;
            
            string id_edit_new;
            string select_id = "SELECT r_id FROM roles ";//查詢member_id是否有重複

            DataSet ds = tmp.Getgroupid(select_id);

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
                if ((string.IsNullOrWhiteSpace(InputId.Text)) || (string.IsNullOrWhiteSpace(InputName.Text)) )
                {
                    Label2.Visible = true;
                    Label2.Text = "*必須填入資料";

                }
                //如果必填欄位都輸入,則新增置資料庫中
                if (((!string.IsNullOrWhiteSpace(InputId.Text)) && (!string.IsNullOrWhiteSpace(InputName.Text))))
                {
                   
                    id_edit_new = @"INSERT INTO roles (r_id,r_name) 
                    VALUES('" + r_id + "',N'" + r_name + "')";//新增

                    tmp.Insert(id_edit_new);//用Insert方法

                    Response.Redirect("group_manage.aspx");//跳轉到登入畫面
                }
            }
        }
    }
}