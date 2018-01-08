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
            this.NewId();//新增編號
        }

        private void NewId()
        {
            #region 商品類別編號
            String select_all_id = "select top 1 pt_id from product_type order by pt_id desc ";
            DataSet ds = tmp.GetNewId(select_all_id);
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables["selectnewid"].Rows)
                {
                    string all_id;
                    all_id = dr["pt_id"].ToString();
                    int all_id_new = int.Parse(all_id.Substring(2, 3));
                    if (all_id_new < 9)
                    {
                        all_id = "PT00" + (all_id_new + 1);
                    }
                    if (all_id_new < 99 && all_id_new >= 9)
                    {
                        all_id = "PT0" + (all_id_new + 1);
                    }
                    if (all_id_new < 999 && all_id_new >= 99)
                    {
                        all_id = "PT" + (all_id_new + 1);
                    }

                    InputID.Text = all_id;

                }
            }
            #endregion
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