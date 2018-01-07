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
    public partial class purchases_new : System.Web.UI.Page
    {

        string pur_id, s_id, m_id, delieverydate;//註冊項目
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
                this.SetSuuplierGroup();//設定廠商下拉選單
                Data_Binding();
                InputMid.Text = m_id;
                InputMid.ReadOnly = true;
                NewId();


            }
            objGVPEntity = TempGVPEntity;
        }

        private void NewId()
        {
            String select_all_id = "select top 1 pur_id from purchases order by pur_id desc ";
            DataSet ds = tmp.GetNewId(select_all_id);
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables["selectnewid"].Rows)
                {
                    string all_id;
                    all_id = dr["pur_id"].ToString();
                    int all_id_new = int.Parse(all_id.Substring(2, 3));
                    if (all_id_new < 9)
                    {
                        all_id = "H000" + (all_id_new + 1);
                    }
                    if (all_id_new < 99 && all_id_new >= 9)
                    {
                        all_id = "H00" + (all_id_new + 1);
                    }
                    if (all_id_new < 999 && all_id_new >= 99)
                    {
                        all_id = "H0" + (all_id_new + 1);
                    }

                    purid.Text = all_id;

                }
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            //添加新的行位
            objGVP.PurID = Guid.NewGuid().ToString();
            objGVP.pid = string.Empty;
            objGVP.Name = string.Empty;
            objGVP.Price = 0;
            objGVP.Count = 0;
            objGVPEntity.Add(objGVP);
            TempGVPEntity = objGVPEntity;
            Data_Binding();
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
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow gvr in this.GridView1.Rows)
                {
                    GetValuePurchases objgvp = new GetValuePurchases();
                    objgvp.PurID = this.GridView1.DataKeys[gvr.RowIndex].Value.ToString();
                    objgvp.pid = ((Label)gvr.FindControl("pur_id")).Text.Trim();
                    objgvp.Name = ((DropDownList)gvr.FindControl("ddlNameGroup")).SelectedValue.Trim();
                    objgvp.Price = Convert.ToDecimal(((TextBox)gvr.FindControl("Input_pur_price")).Text.Trim());
                    objgvp.Count = Convert.ToDecimal(((TextBox)gvr.FindControl("Input_pur_count")).Text.Trim());
                    objGVPEntity.Edit(objgvp);
                    TempGVPEntity = objGVPEntity;
                    Data_Binding();
                    //設定下拉選單值
                    DropDownList ddl = (DropDownList)gvr.FindControl("ddlNameGroup");
                    ddl.ClearSelection();
                    ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByValue(objgvp.pid));
                    
                    ddl.Items.FindByValue(objgvp.pid).Selected = true;
                    Label lbl = gvr.FindControl("pur_id") as Label;
                    if (lbl != null)
                    {
                        lbl.Text = objgvp.pid;
                    }


                }
            }
            catch (Exception ex)
            {

            }
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
                Label lb_p_id = (Label)e.Row.FindControl("pur_id");
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
                Label lbl_id = e.Row.FindControl("pur_id") as Label;
            }
        }

        protected void btn_insert_purchases_Click(object sender, EventArgs e)
        {

            ////把畫面中使用者輸入的欄位值都到各個字串中
            pur_id = purid.Text;
            //s_id = InputSid.Text;
            s_id = ddlSupplierGroup.SelectedValue.Trim();

            delieverydate = InputDeliverydate.Text;

            string purchases_new;
            string select_id = "SELECT pur_id FROM purchases ";//查詢supplier_id是否有重複

            DataSet ds = tmp.GetPurchesaaId(select_id);

            if (ds != null)
            {
                //檢測帳號是否有重複
                foreach (DataRow dr in ds.Tables["PurchesasInfo"].Rows)
                {
                    string all_id;
                    all_id = dr["pur_id"].ToString();
                    if (all_id == pur_id)
                    {
                        Msg_ExistID.Visible = true;//帳號已存在隱藏
                    }

                }

                //如果有任一欄位未輸入  則顯示「必填」

                if ((string.IsNullOrWhiteSpace(purid.Text)) || (string.IsNullOrWhiteSpace(ddlSupplierGroup.SelectedValue.Trim())) || (string.IsNullOrWhiteSpace(InputDeliverydate.Text)))

                {
                    Msg_Error.Visible = true;
                    Msg_Error.Text = "*必須填入資料";

                }

                //如果必填欄位都輸入,則新增置資料庫中

                if ((!string.IsNullOrWhiteSpace(purid.Text)) && (!string.IsNullOrWhiteSpace(ddlSupplierGroup.SelectedValue.Trim())) && (!string.IsNullOrWhiteSpace(InputDeliverydate.Text)))

                {

                    purchases_new = @"Insert Into purchases (pur_id, s_id, m_id, accept, deliverydate, createdate, update_time) 
                    Values('" + pur_id + "','" + s_id + "','" + m_id + "','False','" + delieverydate + "', GETDATE(), GETDATE())";//新增

                    tmp.Insert(purchases_new);//用Insert方法

                }

                //讀取每個GridViewRow-行 的值
                int c = 1;
                foreach (GridViewRow gvr in this.GridView1.Rows)
                {
                    string purchases_info_new;
                    string p_id;
                    decimal purin_price, purin_qty;

                    p_id = ((DropDownList)gvr.FindControl("ddlNameGroup")).Text.Trim();
                    purin_price = Convert.ToDecimal(((TextBox)gvr.FindControl("Input_pur_price")).Text.Trim());
                    purin_qty = Convert.ToDecimal(((TextBox)gvr.FindControl("Input_pur_count")).Text.Trim());

                    purchases_info_new = @"Insert Into purchases_info (purin_id,pur_id, p_id, m_id, purin_price, purin_qty, createdate, update_time) 
                    Values('" + pur_id + c + "','" + pur_id + "','" + p_id + "','" + m_id + "','" + purin_price + "','" + purin_qty + "', GETDATE(), GETDATE())";//新增
                    tmp.Insert(purchases_info_new);//用Insert方法
                    c = c + 1;

                }

                Response.Redirect("purchases_manage.aspx");//跳轉到登入畫面

            }

        }

        protected void NameGroup_SelectIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            GridViewRow gvr = ddl.NamingContainer as GridViewRow;
            if (ddl != null && gvr != null)
            {
                Label lbl = gvr.FindControl("pur_id") as Label;
                if (lbl != null)
                {
                    lbl.Text = ddl.SelectedValue;
                    TextBox tb_price = gvr.FindControl("Input_pur_price") as TextBox;
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

        private void SetSuuplierGroup()
        {
            #region 設定群組下拉選項

            string p = "SELECT * FROM supplier";
            ddlSupplierGroup.Items.Clear();//清空下拉項目
            ListItem cmplistitem = new ListItem();//新增下拉
            cmplistitem.Text = "請選擇廠商:";
            cmplistitem.Value = "";
            ddlSupplierGroup.Items.Add(cmplistitem);
            cmplistitem = null;

            DataSet ds = tmp.GetDDL(p);

            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables["ddl_info"].Rows)
                {
                    ListItem cmplistitemnew = new ListItem();//新增下拉
                    cmplistitemnew.Text = dr["s_name"].ToString();
                    cmplistitemnew.Value = dr["s_id"].ToString();
                    ddlSupplierGroup.Items.Add(cmplistitemnew);

                }
            }
            #endregion

        }
    }
}