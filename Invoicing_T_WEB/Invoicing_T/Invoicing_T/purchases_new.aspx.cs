﻿using System;
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
                Data_Binding();
                InputMid.Text = m_id;
                InputMid.ReadOnly = true;
            }
            objGVPEntity = TempGVPEntity;
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
                foreach(GridViewRow gvr in this.GridView1.Rows)
                {
                    GetValuePurchases objgvp = new GetValuePurchases();
                    objgvp.PurID = this.GridView1.DataKeys[gvr.RowIndex].Value.ToString();
                    objgvp.pid = ((TextBox)gvr.FindControl("Input_pur_id")).Text.Trim();
                    objgvp.Name= ((TextBox)gvr.FindControl("Input_pur_name")).Text.Trim();
                    objgvp.Price = Convert.ToDecimal(((TextBox)gvr.FindControl("Input_pur_price")).Text.Trim());
                    objgvp.Count= Convert.ToDecimal(((TextBox)gvr.FindControl("Input_pur_count")).Text.Trim());

                    objGVPEntity.Edit(objgvp);
                    TempGVPEntity = objGVPEntity;
                    Data_Binding();

                }
            }
            catch(Exception ex) { }
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
        }

        protected void btn_insert_purchases_Click(object sender, EventArgs e)
        {
            //把畫面中使用者輸入的欄位值都到各個字串中
            pur_id = InputPurid.Text;
            s_id = InputSid.Text;
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
                if ((string.IsNullOrWhiteSpace(InputPurid.Text)) || (string.IsNullOrWhiteSpace(InputSid.Text)) || (string.IsNullOrWhiteSpace(InputDeliverydate.Text)))
                {
                    Label13.Visible = true;
                    Label13.Text = "*必須填入資料";

                }
                
                //如果必填欄位都輸入,則新增置資料庫中
                if ((!string.IsNullOrWhiteSpace(InputPurid.Text)) && (!string.IsNullOrWhiteSpace(InputSid.Text)) && (!string.IsNullOrWhiteSpace(InputDeliverydate.Text)))
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
                    
                    p_id= ((TextBox)gvr.FindControl("Input_pur_id")).Text.Trim();
                    purin_price= Convert.ToDecimal(((TextBox)gvr.FindControl("Input_pur_price")).Text.Trim());
                    purin_qty= Convert.ToDecimal(((TextBox)gvr.FindControl("Input_pur_count")).Text.Trim());

                    purchases_info_new = @"Insert Into purchases_info (purin_id,pur_id, p_id, m_id, purin_price, purin_qty, createdate, update_time) 
                    Values('"+pur_id+c+"','" + pur_id + "','" + p_id + "','" + m_id + "','"+purin_price+"','" + purin_qty + "', GETDATE(), GETDATE())";//新增
                    tmp.Insert(purchases_info_new);//用Insert方法
                    c = c + 1;

                }

                Response.Redirect("purchases_manage.aspx");//跳轉到登入畫面

            }

        }
    }
}