using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class client_edit : System.Web.UI.Page
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
                            c_name.ReadOnly = true;
                            c_name.BackColor = System.Drawing.ColorTranslator.FromHtml("#7B7B7B");
                            c_address.ReadOnly = true;
                            c_address.BackColor = System.Drawing.ColorTranslator.FromHtml("#7B7B7B");
                            c_phone.ReadOnly = true;
                            c_phone.BackColor = System.Drawing.ColorTranslator.FromHtml("#7B7B7B");
                            c_email.ReadOnly = true;
                            c_email.BackColor = System.Drawing.ColorTranslator.FromHtml("#7B7B7B");
                            break;
                    }
                }

                if (Request.QueryString["c_id"] != null)//要判斷一下是否有該URL參數
                {
                    HiddenF_rid.Value = Request.QueryString["c_id"].ToString();//主索引
                    this.SetMaintainData(HiddenF_rid.Value);//設定要維護的資料
                }

            }
        }

        private void SetMaintainData(string p)
        {
            #region 查詢客戶資料

            DataSet ds1 = tmp.GetClientInfo(p);
            if (ds1 != null)
            {
                DataRow tmpDataRow = ds1.Tables["client_info"].Rows[0];
                c_id.Text = tmpDataRow["c_id"].ToString();
                c_name.Text = tmpDataRow["c_name"].ToString();
                c_address.Text = tmpDataRow["c_address"].ToString();
                c_phone.Text = tmpDataRow["c_phone"].ToString();
                c_email.Text = tmpDataRow["c_email"].ToString();
            }
            #endregion
        }

        protected void btn_Click(object sender, EventArgs e)
        {

            #region 修改/刪除客戶資料

            Dictionary<string, object> tmpViewData = this.SetViewData();//設定畫面中的資料

            string tmpID = ((Button)sender).ID;//(Button)sender->將object強制轉型成button
            switch (tmpID)//使用者按下哪一個按鈕
            {
                case "btnUpdate":
                    tmp.UpdateClient(tmpViewData);
                    break;
                case "btnDelete":
                    tmp.DeleteClient(tmpViewData);
                    break;
            }
            Server.Transfer("client_manage.aspx", true);//導回群組管理
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
            tmpViewData.Add("c_id", c_id.Text);
            tmpViewData.Add("c_name", c_name.Text);
            tmpViewData.Add("c_address", c_address.Text);
            tmpViewData.Add("c_phone", c_phone.Text);
            tmpViewData.Add("c_email", c_email.Text);
            return tmpViewData;
            #endregion
        }

    }
}