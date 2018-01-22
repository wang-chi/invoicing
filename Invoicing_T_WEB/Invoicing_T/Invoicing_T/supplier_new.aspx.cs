using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class supplier_new : System.Web.UI.Page
    {
        string s_id, s_name, s_address, s_phone, s_email;//註冊項目
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
            String select_all_id = "select top 1 s_id from supplier order by s_id desc ";
            DataSet ds = tmp.GetNewId(select_all_id);
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables["selectnewid"].Rows)
                {
                    string all_id;
                    all_id = dr["s_id"].ToString();
                    int all_id_new = int.Parse(all_id.Substring(2, 3));
                    if (all_id_new < 9)
                    {
                        all_id = "S000" + (all_id_new + 1);
                    }
                    if (all_id_new < 99 && all_id_new >= 9)
                    {
                        all_id = "S00" + (all_id_new + 1);
                    }
                    if (all_id_new < 999 && all_id_new >= 99)
                    {
                        all_id = "S0" + (all_id_new + 1);
                    }

                    Id.Text = all_id;

                }
            }
        }

        protected void btn_insert_supplier(object sender, EventArgs e)
        {

            //把畫面中使用者輸入的欄位值都到各個字串中
            s_id = Id.Text;
            s_name = InputName.Text;
            s_address = InputAddress.Text;
            s_phone = InputPhone.Text;
            s_email = InputEmail.Text;

            string supplier_new;
            string select_id = "SELECT s_id FROM supplier ";//查詢supplier_id是否有重複

            DataSet ds = tmp.GetSupplierId(select_id);

            if (ds != null)
            {
                //檢測帳號是否有重複
                foreach (DataRow dr in ds.Tables["supplierInfo"].Rows)
                {
                    string all_id;
                    all_id = dr["s_id"].ToString();
                    if (all_id == s_id)
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
      
                    supplier_new = @"Insert Into supplier (s_id, s_name, s_address, s_phone, s_email, createdate, update_time) 
                    Values('" + s_id + "',N'" + s_name + "',N'" + s_address + "',N'" + s_phone + "','" + s_email  + "', GETDATE(), GETDATE())";//新增

                    tmp.Insert(supplier_new);//用Insert方法

                    Response.Redirect("supplier_manage.aspx");//跳轉到登入畫面
                }
            }


        }
    }
}