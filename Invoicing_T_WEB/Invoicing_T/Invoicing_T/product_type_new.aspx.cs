using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class product_type_new : System.Web.UI.Page
    {
        string pt_id, pt_name;//註冊項目
        DBHandle tmp = new DBHandle();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_insert_product_type_Click(object sender, EventArgs e)
        {
            //把畫面中使用者輸入的欄位值都到各個字串中
            pt_id = InputID.Text;
            pt_name = InputName.Text;

            string product_type_new;
            string select_id = "SELECT pt_id FROM product_type ";//查詢supplier_id是否有重複

            DataSet ds = tmp.GetProductTypeId(select_id);

            if (ds != null)
            {
                //檢測帳號是否有重複
                foreach (DataRow dr in ds.Tables["ProductTypeInfo"].Rows)
                {
                    string all_id;
                    all_id = dr["pt_id"].ToString();
                    if (all_id == pt_id)
                    {
                        Msg_ExistID.Visible = true;//帳號已存在隱藏
                    }

                }

                //如果有任一欄位未輸入  則顯示「必填」
                if ((string.IsNullOrWhiteSpace(InputID.Text)) || (string.IsNullOrWhiteSpace(InputName.Text)))
                {
                    Label13.Visible = true;
                    Label13.Text = "*必須填入資料";

                }



                //如果必填欄位都輸入,則新增置資料庫中
                if ((!string.IsNullOrWhiteSpace(InputID.Text)) && (!string.IsNullOrWhiteSpace(InputName.Text)))
                {

                    product_type_new = @"Insert Into product_type (pt_id, pt_name) 
                    Values('" + pt_id + "',N'" + pt_name + "')";//新增

                    tmp.Insert(product_type_new);//用Insert方法

                    Response.Redirect("product_type_manage.aspx");//跳轉到登入畫面
                }
            }

        }
    }
}