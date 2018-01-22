using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invoicing_T;
using System.Data;

namespace Invoicing_T
{
    public partial class order_new : System.Web.UI.Page
    {
        string or_id, c_id, m_id, delieverydate;//註冊項目
        DBHandle tmp = new DBHandle();

        GetValuePurchases objGVP = new GetValuePurchases();
        GVPEntity objGVPEntity = new GVPEntity();
        decimal sumTotal = 0.0m;

        protected void Page_Load(object sender, EventArgs e)
        {
            m_id = Session["UserID"].ToString();
            if (!IsPostBack)
            {
                NewId();
                this.SetClientGroup();//設定廠商下拉選單
                Data_Binding();
                InputMid.Text = m_id;
                InputMid.ReadOnly = true;

            }
            objGVPEntity = TempGVPEntity;
        }
        private void NewId()
        {
            #region 進貨單編號
            String select_all_id = "select top 1 or_id from orders order by or_id desc ";
            DataSet ds = tmp.GetNewId(select_all_id);
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables["selectnewid"].Rows)
                {
                    string all_id;
                    all_id = dr["or_id"].ToString();
                    int all_id_new = int.Parse(all_id.Substring(2, 3));
                    if (all_id_new < 9)
                    {
                        all_id = "W000" + (all_id_new + 1);
                    }
                    if (all_id_new < 99 && all_id_new >= 9)
                    {
                        all_id = "W00" + (all_id_new + 1);
                    }
                    if (all_id_new < 999 && all_id_new >= 99)
                    {
                        all_id = "W0" + (all_id_new + 1);
                    }

                    orid.Text = all_id;

                }
            }
            #endregion
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            #region 添加新的行位
            objGVP.PurID = Guid.NewGuid().ToString();
            objGVP.pid = string.Empty;
            objGVP.Name = string.Empty;
            objGVP.Price = 0;
            objGVP.Count = 0;
            objGVPEntity.Add(objGVP);
            TempGVPEntity = objGVPEntity;
            Data_Binding();
            #endregion
        }

        private GVPEntity TempGVPEntity
        {
            get
            {
                if (Session["GVPEntity"] == null)
                {
                    return new GVPEntity();
                }
                else
                {
                    return (GVPEntity)Session["GVPEntity"];
                }
            }
            set
            {
                Session["GVPEntity"] = value;
            }
        }

        private void Data_Binding()
        {
            this.GridView1.DataSource = objGVPEntity.GetValuePurchasesDatas;
            this.GridView1.DataBind();
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            #region 按鈕:刪除事件

            try
            {
                foreach (GridViewRow gvr in this.GridView1.Rows)
                {
                    CheckBox cb = (CheckBox)gvr.FindControl("CheckBox1");
                    if (cb.Checked)
                    {
                        GetValuePurchases objgvp = new GetValuePurchases();
                        objgvp.PurID = this.GridView1.DataKeys[gvr.RowIndex].Value.ToString();

                        objGVPEntity.Delete(objgvp);
                    }
                }
                TempGVPEntity = objGVPEntity;
                Data_Binding();
            }
            catch (Exception ex) { }
            #endregion
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            #region 按鈕:更新事件


            try
            {
                foreach (GridViewRow gvr in this.GridView1.Rows)
                {
                    GetValuePurchases objgvp = new GetValuePurchases();
                    objgvp.PurID = this.GridView1.DataKeys[gvr.RowIndex].Value.ToString();
                    objgvp.pid = ((Label)gvr.FindControl("or_id")).Text.Trim();
                    objgvp.Name = ((DropDownList)gvr.FindControl("ddlNameGroup")).SelectedValue.Trim();
                    objgvp.Price = Convert.ToDecimal(((TextBox)gvr.FindControl("Input_or_price")).Text.Trim());
                    objgvp.Count = Convert.ToDecimal(((TextBox)gvr.FindControl("Input_or_count")).Text.Trim());
                    objGVPEntity.Edit(objgvp);
                    TempGVPEntity = objGVPEntity;
                    Data_Binding();
                    //設定下拉選單值
                    DropDownList ddl = (DropDownList)gvr.FindControl("ddlNameGroup");
                    ddl.ClearSelection();
                    ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByValue(objgvp.pid));

                    ddl.Items.FindByValue(objgvp.pid).Selected = true;
                    Label lbl = gvr.FindControl("or_id") as Label;
                    if (lbl != null)
                    {
                        lbl.Text = objgvp.pid;
                    }


                }
            }
            catch (Exception ex)
            {

            }
            #endregion
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                sumTotal = 0.0m;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                sumTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (e.Row.FindControl("pur_total") != null)
                {
                    Label lb1 = (Label)e.Row.FindControl("pur_total");
                    lb1.Text = sumTotal.ToString();
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                DropDownList ddlProduct = (e.Row.FindControl("ddlNameGroup") as DropDownList);
                string p = "SELECT p_id, p_name, p_price FROM product";
                DataSet ds = tmp.GetDDL(p);
                ddlProduct.DataSource = ds;
                ddlProduct.DataTextField = "p_name";
                ddlProduct.DataValueField = "p_id";
                ddlProduct.DataBind();

                //Add Default Item in the DropDownList
                ddlProduct.Items.Insert(0, new ListItem("Please select"));

                //Select the Country of Customer in DropDownList
                string product = (e.Row.FindControl("ddlNameGroup") as DropDownList).SelectedValue;
                //1.判斷商品編號有沒有東西
                Label lb_p_id = (Label)e.Row.FindControl("or_id");
                string p_id = lb_p_id.Text.ToString();
                //2.設定下拉選單預設值
                if (p_id != "")
                {
                    //空值
                    product = p_id;
                }

                //if (product == "Please select") product = "P0001";

                ddlProduct.ClearSelection();
                ddlProduct.Items.FindByValue(product).Selected = true;
                Label lbl_id = e.Row.FindControl("or_id") as Label;
            }
        }

        protected void btn_insert_orders_Click(object sender, EventArgs e)
        {
            #region 按鈕:新增進貨單
            ////把畫面中使用者輸入的欄位值都到各個字串中
            or_id = orid.Text;
            //s_id = InputSid.Text;
            c_id = ddlClientGroup.SelectedValue.Trim();

            delieverydate = InputDeliverydate.Text;

            string orders_new;
            string select_id = "SELECT or_id FROM orders ";//查詢supplier_id是否有重複

            DataSet ds = tmp.GetOrdersId(select_id);

            if (ds != null)
            {
                //檢測帳號是否有重複
                foreach (DataRow dr in ds.Tables["OrdersInfo"].Rows)
                {
                    string all_id;
                    all_id = dr["or_id"].ToString();
                    if (all_id == or_id)
                    {
                        Msg_ExistID.Visible = true;//帳號已存在隱藏
                    }

                }

                //如果有任一欄位未輸入  則顯示「必填」

                if ((string.IsNullOrWhiteSpace(orid.Text)) || (string.IsNullOrWhiteSpace(ddlClientGroup.SelectedValue.Trim())) || (string.IsNullOrWhiteSpace(InputDeliverydate.Text)))

                {
                    Msg_Error.Visible = true;
                    Msg_Error.Text = "*必須填入資料";

                }

                //如果必填欄位都輸入,則新增置資料庫中

                if ((!string.IsNullOrWhiteSpace(orid.Text)) && (!string.IsNullOrWhiteSpace(ddlClientGroup.SelectedValue.Trim())) && (!string.IsNullOrWhiteSpace(InputDeliverydate.Text)))

                {

                    orders_new = @"Insert Into orders (or_id, c_id, m_id, accept, deliverydate, createdate, update_time) 
                    Values('" + or_id + "','" + c_id + "','" + m_id + "','False','" + delieverydate + "', GETDATE(), GETDATE())";//新增

                    tmp.Insert(orders_new);//用Insert方法

                }

                //讀取每個GridViewRow-行 的值
                int c = 1;
                foreach (GridViewRow gvr in this.GridView1.Rows)
                {
                    string purchases_info_new, supplier_price_new;
                    string p_id;
                    decimal purin_price, purin_qty;

                    p_id = ((DropDownList)gvr.FindControl("ddlNameGroup")).Text.Trim();
                    purin_price = Convert.ToDecimal(((TextBox)gvr.FindControl("Input_or_price")).Text.Trim());
                    purin_qty = Convert.ToDecimal(((TextBox)gvr.FindControl("Input_or_count")).Text.Trim());
                    //新增進貨單內容
                    purchases_info_new = @"Insert Into orders_info (orin_id,or_id, p_id, m_id, orin_price, orin_qty, createdate, update_time) 
                    Values('" + or_id + c + "','" + or_id + "','" + p_id + "','" + m_id + "','" + purin_price + "','" + purin_qty + "', GETDATE(), GETDATE())";//新增
                    tmp.Insert(purchases_info_new);//用Insert方法
                    //回寫進貨價格表
                    supplier_price_new = @"Insert Into client_price (cp_id, p_id, c_id, price, createdate) 
                    Values('" + or_id + c + "','" + p_id + "','" + c_id + "','" + purin_price + "', GETDATE())";//新增
                    tmp.Insert(supplier_price_new);
                    c = c + 1;

                }

                Response.Redirect("orders_manage.aspx");//跳轉到登入畫面

            }
            #endregion
        }



        protected void NameGroup_SelectIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            GridViewRow gvr = ddl.NamingContainer as GridViewRow;
            if (ddl != null && gvr != null)
            {
                Label lbl = gvr.FindControl("or_id") as Label;
                if (lbl != null)
                {
                    lbl.Text = ddl.SelectedValue;
                    TextBox tb_price = gvr.FindControl("Input_or_price") as TextBox;
                    if (tb_price != null && (lbl.Text.Length == 5))
                    {
                        DataSet priceds = tmp.GetPrice(lbl.Text);
                        DataRow dr = priceds.Tables["price"].Rows[0];
                        tb_price.Text = dr["p_price"].ToString();
                        //tb_price.Text = "p_price";
                    }
                }
            }

        }

        private void SetClientGroup()
        {
            #region 設定群組下拉選項

            string p = "SELECT * FROM client";
            ddlClientGroup.Items.Clear();//清空下拉項目
            ListItem cmplistitem = new ListItem();//新增下拉
            cmplistitem.Text = "請選擇客戶:";
            cmplistitem.Value = "";
            ddlClientGroup.Items.Add(cmplistitem);
            cmplistitem = null;

            DataSet ds = tmp.GetDDL(p);

            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables["ddl_info"].Rows)
                {
                    ListItem cmplistitemnew = new ListItem();//新增下拉
                    cmplistitemnew.Text = dr["c_name"].ToString();
                    cmplistitemnew.Value = dr["c_id"].ToString();
                    ddlClientGroup.Items.Add(cmplistitemnew);

                }
            }
            #endregion

        }
    }
}