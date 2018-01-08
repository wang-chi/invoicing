using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class purchases_returns_edit : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                
                if (Request.QueryString["pr_id"] != null)//要判斷一下是否有該URL參數
                {
                    HiddenF_rid.Value = Request.QueryString["pr_id"].ToString();//主索引
                    this.SetMaintainData(HiddenF_rid.Value);//設定要維護的資料
                }
                this.all(null, null, HiddenF_rid.Value);//查詢群組資料

            }
        }

        protected void all(object sender, EventArgs e, String p)
        {

            #region 查詢銷貨單資料

            DataSet ds = tmp.GetPurchasesreturnsInfo(p);
            if (ds != null)
            {
                lvPReturnsInfoinfo.DataSource = null;
                lvPReturnsInfoinfo.DataSource = ds.Tables["purchases_returns_info"];
                lvPReturnsInfoinfo.DataBind();
            }

            #endregion
        }

        private void SetMaintainData(string p)
        {

            #region 查詢群組資料

            DataSet ds1 = tmp.GetPurchasesreturnsInfo(p);
            if (ds1 != null)
            {
                DataRow tmpDataRow = ds1.Tables["purchases_returns_info"].Rows[0];
                prid.Text = tmpDataRow["pr_id"].ToString();
                pur_id.Text = tmpDataRow["pur_id"].ToString();
                mid.Text = tmpDataRow["m_id"].ToString();


            }
            #endregion
        }


    }
}