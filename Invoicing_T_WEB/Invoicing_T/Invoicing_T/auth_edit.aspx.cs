﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class auth_edit : System.Web.UI.Page
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
                            auth_name_input.ReadOnly = true;
                            auth_name_input.BackColor = System.Drawing.ColorTranslator.FromHtml("#dedede");
                            auth_page_input.ReadOnly = true;
                            auth_page_input.BackColor = System.Drawing.ColorTranslator.FromHtml("#dedede");
                            break;
                    }
                }

                if (Request.QueryString["a_id"] != null)//要判斷一下是否有該URL參數
                {
                    HiddenF_rid.Value = Request.QueryString["a_id"].ToString();//主索引
                    this.SetMaintainData(HiddenF_rid.Value);//設定要維護的資料
                }

            }
        }

        private void SetMaintainData(string p)
        {

            #region 查詢群組資料

            DataSet ds1 = tmp.GetAuthInfo(p);
            if (ds1 != null)
            {
                DataRow tmpDataRow = ds1.Tables["auth_info"].Rows[0];
                a_id.Text = tmpDataRow["a_id"].ToString();
                auth_name_input.Text = tmpDataRow["a_name"].ToString();
                auth_page_input.Text = tmpDataRow["a_page"].ToString();
            }
            #endregion
        }

        protected void btn_Click(object sender, EventArgs e)
        {

            #region 修改/刪除權限資料

            Dictionary<string, object> tmpViewData = this.SetViewData();//設定畫面中的資料

            string tmpID = ((Button)sender).ID;//(Button)sender->將object強制轉型成button
            switch (tmpID)//使用者按下哪一個按鈕
            {
                case "btnUpdate":
                    tmp.UpdateAuth(tmpViewData);
                    break;
                case "btnDelete":
                    tmp.DeleteAuth(tmpViewData);
                    break;
            }
            Server.Transfer("auth_manage.aspx", true);//導回群組管理
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
            tmpViewData.Add("a_id", a_id.Text);
            tmpViewData.Add("a_name", auth_name_input.Text);
            tmpViewData.Add("a_page", auth_page_input.Text);
            return tmpViewData;
            #endregion
        }
    }
}