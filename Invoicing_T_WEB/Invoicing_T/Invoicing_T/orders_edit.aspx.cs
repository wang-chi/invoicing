using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class order_edit : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();

        GetValuePurchases objGVP = new GetValuePurchases();
        GVPEntity objGVPEntity = new GVPEntity();
        decimal sumTotal = 0.0m;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ActionState"] != null)//要判斷一下是否有該URL參數
                {
                    HiddenF_ActionState.Value = Request.QueryString["ActionState"].ToString();//執行狀態
                    m_id.Text = Session["UserID"].ToString();

                    switch (HiddenF_ActionState.Value)
                    {
                        case "UpDate":
                            btnUpdate.Visible = true;
                            break;
                        case "Delete":
                            btnDelete.Visible = true;
                            break;
                    }
                }

                if (Request.QueryString["or_id"] != null)//要判斷一下是否有該URL參數
                {
                    HiddenF_rid.Value = Request.QueryString["or_id"].ToString();//主索引
                    this.SetMaintainData(HiddenF_rid.Value);//設定要維護的資料
                }

                this.all(null, null, HiddenF_rid.Value);//查詢群組資料
                Data_Binding();
            }
            objGVPEntity = TempGVPEntity;
        }

        protected void all(object sender, EventArgs e, String p)
        {

            #region 查詢進貨單詳細資料資料

            DataSet ds = tmp.GetOrdersinfoInfo(p);
            if (ds != null)
            {
                lvordersInfo.DataSource = null;
                lvordersInfo.DataSource = ds.Tables["orders_info_info"];
                lvordersInfo.DataBind();
            }

            #endregion
        }

        private void SetMaintainData(string p)
        {

            #region 查詢群組資料

            DataSet ds1 = tmp.GetOrdersInfo(p);
            if (ds1 != null)
            {
                DataRow tmpDataRow = ds1.Tables["orders_info"].Rows[0];
                or_id.Text = tmpDataRow["or_id"].ToString();
                c_id.Text = tmpDataRow["c_id"].ToString();
                RadioButtonList1.SelectedValue = tmpDataRow["accept"].ToString();
                deliverydate.Text = tmpDataRow["deliverydate"].ToString();
                update_time.Text = tmpDataRow["update_time"].ToString();
            }

            #endregion
        }

        protected void btn_Click(object sender, EventArgs e)
        {

            #region 修改/刪除廠商資料

            Dictionary<string, object> tmpViewData = this.SetViewData();//設定畫面中的資料
            
            string tmpID = ((Button)sender).ID;//(Button)sender->將object強制轉型成button
            switch (tmpID)//使用者按下哪一個按鈕
            {
                case "btnUpdate":
                    tmp.UpdateOrders(tmpViewData);
                    update_product();


                    break;
                case "btnDelete":
                    delete_product();
                    tmp.DeleteOrders(tmpViewData);
                    break;
            }
            Server.Transfer("orders_manage.aspx", true);//導回群組管理
            #endregion
        }

        /// <summary>
        /// 設定畫面中的資料
        /// </summary>
        /// <returns>畫面中的資料</returns>
        private Dictionary<string, object> SetViewData()//收集資料
        {
            #region 設定畫面中的要修改的資料
            Dictionary<string, object> tmpViewData = new Dictionary<string, object>();//object->可以儲存不同的資料型別
            //TODO : 補
            //("資料庫欄位")
            tmpViewData.Add("or_id", or_id.Text);
            tmpViewData.Add("m_id", m_id.Text);
            tmpViewData.Add("accept", RadioButtonList1.SelectedItem.Value);
            tmpViewData.Add("deliverydate", deliverydate.Text);

            return tmpViewData;
            #endregion
        }

        private void update_product()
        {
            foreach (ListViewItem myItem in lvordersInfo.Items)
            {
                TextBox lv_price, lv_qty;
                Label lv_orin;
                string p_price, p_qty, p_orin;
                lv_price = (TextBox)myItem.FindControl("InputPrice");
                p_price = lv_price.Text;

                lv_qty = (TextBox)myItem.FindControl("InputQty");
                p_qty = lv_qty.Text;

                lv_orin = (Label)myItem.FindControl("orinid");
                p_orin = lv_orin.Text;

                tmp.UpdateOrdersInfo(p_price, p_qty, p_orin);

            }
        }

        private void delete_product()
        {
            foreach (ListViewItem myItem in lvordersInfo.Items)
            {
                Label lv_orin;
                string p_orin;
                
                lv_orin = (Label)myItem.FindControl("orinid");
                p_orin = lv_orin.Text;

                tmp.DeleteOrdersInfo(p_orin);

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
                    GetValuePurchases objgvp = new GetValuePurchases();
                    objgvp.PurID = this.GridView1.DataKeys[gvr.RowIndex].Value.ToString();
                    objGVPEntity.Delete(objgvp);
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
                    objgvp.pid = ((TextBox)gvr.FindControl("Input_pur_id")).Text.Trim();
                    objgvp.Name = ((TextBox)gvr.FindControl("Input_pur_name")).Text.Trim();
                    objgvp.Price = Convert.ToDecimal(((TextBox)gvr.FindControl("Input_pur_price")).Text.Trim());
                    objgvp.Count = Convert.ToDecimal(((TextBox)gvr.FindControl("Input_pur_count")).Text.Trim());

                    objGVPEntity.Edit(objgvp);
                    TempGVPEntity = objGVPEntity;
                    Data_Binding();

                }
            }
            catch (Exception ex) { }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                sumTotal = 0.0m;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                sumTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total_1"));
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


    }
}