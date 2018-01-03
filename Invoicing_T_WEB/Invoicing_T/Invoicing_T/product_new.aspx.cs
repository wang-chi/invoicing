using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class product_new : System.Web.UI.Page
    {
        string p_id, p_name, pt_id;//註冊項目
        DBHandle tmp = new DBHandle();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_insert_product_Click(object sender, EventArgs e)
        {

            //把畫面中使用者輸入的欄位值都到各個字串中
            p_id = InputID.Text;
            pt_id = InputTypeID.Text;
            p_name = InputName.Text;

            string product_new;
            string select_id = "SELECT p_id FROM product ";//查詢supplier_id是否有重複

            DataSet ds = tmp.GetProductId(select_id);

            if (ds != null)
            {
                //檢測帳號是否有重複
                foreach (DataRow dr in ds.Tables["ProductInfo"].Rows)
                {
                    string all_id;
                    all_id = dr["p_id"].ToString();
                    if (all_id == p_id)
                    {
                        Msg_ExistID.Visible = true;//帳號已存在隱藏
                    }

                }

                //如果有任一欄位未輸入  則顯示「必填」
                if ((string.IsNullOrWhiteSpace(InputID.Text)) || (string.IsNullOrWhiteSpace(InputName.Text)) || (string.IsNullOrWhiteSpace(InputTypeID.Text)))
                {
                    Label13.Visible = true;
                }



                //如果必填欄位都輸入,則新增置資料庫中
                if ((!string.IsNullOrWhiteSpace(InputID.Text)) && (!string.IsNullOrWhiteSpace(InputName.Text)) && (!string.IsNullOrWhiteSpace(InputTypeID.Text)))
                {

                    product_new = @"Insert Into product (p_id, p_name, pt_id) 
                    Values('" + p_id + "',N'" + p_name + "','" + pt_id + "')";//新增

                    tmp.Insert(product_new);//用Insert方法

                    Response.Redirect("product_manage.aspx");//跳轉到登入畫面
                }
            }

        }
    }
}