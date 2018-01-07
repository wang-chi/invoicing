using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class group_edit : System.Web.UI.Page
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
                            //btActionState.Text = "刪除房屋資料";
                            //btActionState.ToolTip = "狀態:刪除房屋資料";
                            btnDelete.Visible = true;
                            GroupName.ReadOnly = true;
                            GroupName.BackColor = System.Drawing.ColorTranslator.FromHtml("#7B7B7B");
                            break;
                    }
                }

                if (Request.QueryString["r_id"] != null)//要判斷一下是否有該URL參數
                {
                    HiddenF_rid.Value = Request.QueryString["r_id"].ToString();//主索引
                    this.SetMaintainData(HiddenF_rid.Value);//設定要維護的資料
                }
                this.all(null, null, HiddenF_rid.Value);//查詢群組資料
            }
        }

        private void SetMaintainData(string p)
        {

            #region 查詢群組資料

            DataSet ds1 = tmp.GetGroupInfo(p);//取得營地資料
            if (ds1 != null)
            {
                DataRow tmpDataRow = ds1.Tables["group_info"].Rows[0];
                r_id.Text = tmpDataRow["r_id"].ToString();
                GroupName.Text = tmpDataRow["r_name"].ToString();
            }
            #endregion
        }

        protected void all(object sender, EventArgs e, String p)
        {
            #region 查詢群組資料
            DataSet ds = tmp.GetRolesAuth(p);
            if (ds != null)
            {
                lvgroupInfo.DataSource = null;
                lvgroupInfo.DataSource = ds.Tables["rolesauth"];
                lvgroupInfo.DataBind();

            }
            #endregion
        }

        protected void btn_Click(object sender, EventArgs e)
        {

            #region 修改/刪除群組資料

            Dictionary<string, object> tmpViewData = this.SetViewData();//設定畫面中的資料

            string tmpID = ((Button)sender).ID;//(Button)sender->將object強制轉型成button
            switch (tmpID)//使用者按下哪一個按鈕
            {
                case "btnUpdate":
                    tmp.UpdateGroup(tmpViewData);
                    update_auth();
                    break;
                case "btnDelete":
                    tmp.DeleteGroup(tmpViewData);
                    break;
            }
            Server.Transfer("group_manage.aspx", true);//導回群組管理
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
            tmpViewData.Add("r_id", r_id.Text);
            tmpViewData.Add("r_name", GroupName.Text);

            return tmpViewData;
            #endregion
        }

        protected void update_auth() {
            foreach (ListViewItem myItem in lvgroupInfo.Items)
            {
                string a_view, a_raid;

                RadioButtonList rbl = (RadioButtonList)myItem.FindControl("viewmode");
                Label auth = (Label)myItem.FindControl("raid");

                a_view = rbl.SelectedItem.Value.ToString();
                a_raid = auth.Text;

                tmp.UpdateAuthGroup(a_view, a_raid);
                
            }
        }

    }
}