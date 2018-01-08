using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class purchases_returns_new : System.Web.UI.Page
    {
        string pr_id, m_id;//註冊項目
        DBHandle tmp = new DBHandle();

        protected void Page_Load(object sender, EventArgs e)
        {
            m_id = Session["UserID"].ToString();
            if (!IsPostBack)
            {
                NewId();
                this.SetPurchases();//設定廠商下拉選單
                InputMid.Text = m_id;
                InputMid.ReadOnly = true;

            }
        }

        private void SetPurchases()
        {
            #region 設定群組下拉選項

            string p = @"SELECT pur.pur_id 
From purchases pur
WHERE pur.pur_id NOT IN(select pur.pur_id from purchases pur, purchases_returns pr WHERE pur.pur_id = pr.pur_id)";
            ddlPurchasesReturns.Items.Clear();//清空下拉項目
            ListItem cmplistitem = new ListItem();//新增下拉
            cmplistitem.Text = "請選擇進貨單來源:";
            cmplistitem.Value = "";
            ddlPurchasesReturns.Items.Add(cmplistitem);
            cmplistitem = null;


            DataSet ds = tmp.GetDDL(p);

            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables["ddl_info"].Rows)
                {
                    ListItem cmplistitemnew = new ListItem();//新增下拉
                    cmplistitemnew.Text = dr["pur_id"].ToString();
                    cmplistitemnew.Value = dr["pur_id"].ToString();
                    ddlPurchasesReturns.Items.Add(cmplistitemnew);

                }
            }

            #endregion

        }

        protected void ddlPurchasesReturns_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            string purid = ddl.SelectedValue;//取得進貨單編號

            if (ddl != null)
            {

                lvPReturnsInfo.Visible = true;
                DataSet ds = tmp.GetPurchasesReturns(purid);
                if (ds != null)
                {
                    lvPReturnsInfo.DataSource = null;
                    lvPReturnsInfo.DataSource = ds.Tables["purchasesreturns"];
                    lvPReturnsInfo.DataBind();

                    DataRow tmpDataRow = ds.Tables["purchasesreturns"].Rows[0];
                    Supplier.Text = tmpDataRow["s_id"].ToString();
                }

            }
        }

        private void NewId()
        {
            #region 進貨單編號
            String select_all_id = "select top 1 pr_id from purchases_returns order by pr_id desc ";
            DataSet ds = tmp.GetNewId(select_all_id);
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables["selectnewid"].Rows)
                {
                    string all_id;
                    all_id = dr["pr_id"].ToString();
                    int all_id_new = int.Parse(all_id.Substring(2, 3));
                    if (all_id_new < 9)
                    {
                        all_id = "PR00" + (all_id_new + 1);
                    }
                    if (all_id_new < 99 && all_id_new >= 9)
                    {
                        all_id = "PR0" + (all_id_new + 1);
                    }
                    if (all_id_new < 999 && all_id_new >= 99)
                    {
                        all_id = "PR" + (all_id_new + 1);
                    }

                    prid.Text = all_id;

                }
            }
            #endregion
        }

        protected void btn_insert_purchases_returns_Click(object sender, EventArgs e)
        {
            #region 按鈕:新增進貨單
            ////把畫面中使用者輸入的欄位值都到各個字串中
            pr_id = prid.Text;

            string purchases_new;

            //如果必填欄位都輸入,則新增置資料庫中

            if ((!string.IsNullOrWhiteSpace(prid.Text)) && (!string.IsNullOrWhiteSpace(ddlPurchasesReturns.SelectedValue.Trim())))

            {
                purchases_new = @"Insert Into purchases_returns (pr_id, pur_id,m_id,createdate, update_time) 
                    Values('" + pr_id + "','" + ddlPurchasesReturns.SelectedValue + "','" + m_id + "', GETDATE(), GETDATE())";//新增

                tmp.Insert(purchases_new);//用Insert方法

            }

            //讀取每個GridViewRow-行 的值
            int c = 1;

            foreach (ListViewItem myItem in lvPReturnsInfo.Items)
            {
                string purchases_returns_info_new;
                string p_id;
                int puriqty;

                Label lv_pid;
                TextBox lv_qty;

                lv_pid = (Label)myItem.FindControl("pid");
                p_id = lv_pid.Text;

                lv_qty = (TextBox)myItem.FindControl("InputCheckQty");
                puriqty = int.Parse(lv_qty.Text);

                //新增進貨單內容
                purchases_returns_info_new = @"Insert Into purchases_returns_info (pri_id,pr_id, p_id, m_id, prin_qty, createdate, update_time) 
                Values('" + pr_id + c + "','" + pr_id + "','" + p_id + "','" + m_id + "','" + puriqty + "', GETDATE(), GETDATE())";//新增
                tmp.Insert(purchases_returns_info_new);//用Insert方法

                c = c + 1;
            }

            Response.Redirect("purchases_returns_manage.aspx");//跳轉到登入畫面

            #endregion
        }


    }
}