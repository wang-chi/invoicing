using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invoicing_T;


namespace Invoicing_T
{
    public partial class purchases_new : System.Web.UI.Page
    {

        GetValuePurchases objGVP = new GetValuePurchases();
        GVPEntity objGVPEntity = new GVPEntity();
        decimal sumTotal = 0.0m;

        protected void Page_Load(object sender, EventArgs e)
        {
            String m_id = Session["m_id"].ToString();
            if (!IsPostBack)
            {
                Data_Binding();
            }
            objGVPEntity = TempGVPEntity;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
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
    }
}