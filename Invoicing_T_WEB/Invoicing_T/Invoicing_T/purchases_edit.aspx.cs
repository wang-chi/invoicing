using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class purchases_edit : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();
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

                if (Request.QueryString["pur_id"] != null)//要判斷一下是否有該URL參數
                {
                    HiddenF_rid.Value = Request.QueryString["pur_id"].ToString();//主索引
                    this.SetMaintainData(HiddenF_rid.Value);//設定要維護的資料
                }

                this.all(null, null, HiddenF_rid.Value);//查詢群組資料
            }

        }

        protected void all(object sender, EventArgs e,String p)
        {

            #region 查詢進貨單詳細資料資料

            DataSet ds = tmp.GetPurchasesinfoInfo(p);
            if (ds != null)
            {
                IvPurchases_info_Info.DataSource = null;
                IvPurchases_info_Info.DataSource = ds.Tables["purchases_info_info"];
                IvPurchases_info_Info.DataBind();
            }

            #endregion
        }

        private void SetMaintainData(string p)
        {

            #region 查詢群組資料

            DataSet ds1 = tmp.GetPurchasesInfo(p);
            if (ds1 != null)
            {
                DataRow tmpDataRow = ds1.Tables["purchases_info"].Rows[0];
                pur_id.Text = tmpDataRow["pur_id"].ToString();
                s_id.Text = tmpDataRow["s_id"].ToString();
                RadioButtonList1.SelectedValue = tmpDataRow["accept"].ToString();
                deliverydate.Text = tmpDataRow["deliverydate"].ToString();
                update_time.Text= tmpDataRow["update_time"].ToString();
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
                    tmp.UpdatePurchases(tmpViewData);

                    break;
                case "btnDelete":
                    tmp.DeleteSupplier(tmpViewData);
                    break;
            }
            Server.Transfer("purchases_manage.aspx", true);//導回群組管理
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
            tmpViewData.Add("pur_id", pur_id.Text);
            tmpViewData.Add("m_id", m_id.Text);
            tmpViewData.Add("accept", RadioButtonList1.SelectedItem.Value);
            tmpViewData.Add("deliverydate", deliverydate.Text);
            return tmpViewData;
            #endregion
        }

        

    }
}