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
            NewId();//取得商品編號
            SetProductTypeGroup();//商品類別下拉選單
        }
        private void NewId()
        {
            #region 商品編號
            String select_all_id = "select top 1 p_id from product order by p_id desc ";
            DataSet ds = tmp.GetNewId(select_all_id);
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables["selectnewid"].Rows)
                {
                    string all_id;
                    all_id = dr["p_id"].ToString();
                    int all_id_new = int.Parse(all_id.Substring(2, 3));
                    if (all_id_new < 9)
                    {
                        all_id = "P000" + (all_id_new + 1);
                    }
                    if (all_id_new < 99 && all_id_new >= 9)
                    {
                        all_id = "P00" + (all_id_new + 1);
                    }
                    if (all_id_new < 999 && all_id_new >= 99)
                    {
                        all_id = "P0" + (all_id_new + 1);
                    }

                    InputID.Text = all_id;

                }
            }
            #endregion
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


        private void SetProductTypeGroup()
        {
            #region 設定群組下拉選項

            string p = "SELECT * FROM product_type";
            ddlProductTypeGroup.Items.Clear();//清空下拉項目
            ListItem cmplistitem = new ListItem();//新增下拉
            cmplistitem.Text = "請選擇商品類別:";
            cmplistitem.Value = "";
            ddlProductTypeGroup.Items.Add(cmplistitem);
            cmplistitem = null;

            DataSet ds = tmp.GetDDL(p);

            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables["ddl_info"].Rows)
                {
                    ListItem cmplistitemnew = new ListItem();//新增下拉
                    cmplistitemnew.Text = dr["pt_name"].ToString();
                    cmplistitemnew.Value = dr["pt_id"].ToString();
                    ddlProductTypeGroup.Items.Add(cmplistitemnew);

                }
            }
            #endregion

        }
    }
}