using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class supplier_edit : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ActionState"] != null)//要判斷一下是否有該URL參數
                {
                    HiddenF_ActionState.Value = Request.QueryString["ActionState"].ToString();//執行狀態

                    switch (HiddenF_ActionState.Value)
                    {
                        case "UpDate":
                            btnUpdate.Visible = true;
                            break;
                        case "Delete":
                            btnDelete.Visible = true;
                            s_name.ReadOnly = true;
                            s_name.BackColor = System.Drawing.ColorTranslator.FromHtml("#7B7B7B");
                            s_address.ReadOnly = true;
                            s_address.BackColor = System.Drawing.ColorTranslator.FromHtml("#7B7B7B");
                            s_phone.ReadOnly = true;
                            s_phone.BackColor = System.Drawing.ColorTranslator.FromHtml("#7B7B7B");
                            s_email.ReadOnly = true;
                            s_email.BackColor = System.Drawing.ColorTranslator.FromHtml("#7B7B7B");
                            break;
                    }
                }

                if (Request.QueryString["s_id"] != null)//要判斷一下是否有該URL參數
                {
                    HiddenF_rid.Value = Request.QueryString["s_id"].ToString();//主索引
                    this.SetMaintainData(HiddenF_rid.Value);//設定要維護的資料
                }

            }
        }

        private void SetMaintainData(string p)
        {

            #region 查詢群組資料

            DataSet ds1 = tmp.GetSupplierInfo(p);
            if (ds1 != null)
            {
                DataRow tmpDataRow = ds1.Tables["supplier_info"].Rows[0];
                s_id.Text = tmpDataRow["s_id"].ToString();
                s_name.Text = tmpDataRow["s_name"].ToString();
                s_address.Text = tmpDataRow["s_address"].ToString();
                s_phone.Text = tmpDataRow["s_phone"].ToString();
                s_email.Text = tmpDataRow["s_email"].ToString();
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
                    tmp.UpdateSupplier(tmpViewData);
                    break;
                case "btnDelete":
                    tmp.DeleteSupplier(tmpViewData);
                    break;
            }
            Server.Transfer("supplier_manage.aspx", true);//導回群組管理
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
            tmpViewData.Add("s_id", s_id.Text);
            tmpViewData.Add("s_name", s_name.Text);
            tmpViewData.Add("s_address", s_address.Text);
            tmpViewData.Add("s_phone", s_phone.Text);
            tmpViewData.Add("s_email", s_email.Text);
            return tmpViewData;
            #endregion
        }

    }
}