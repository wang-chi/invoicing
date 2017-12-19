using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class login : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();
        protected void Page_Load(object sender, EventArgs e)
        {
            tmp.DB_Cnstr = "Data Source=DESKTOP-OP0RFML\\SQLEXPRESS;Initial Catalog=Invoicing_T;Integrated Security=False;User ID=user13106;Password=123";//進入資料庫
            //Session.Remove("position");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = InputAccount.Text;
            string pwd = InputPassword.Text;//把密碼丟進字串pwd中
            string p = "Select m_pwd,m_id From member";//查詢語法

            #region 執行SQL語法-驗證
            DataSet ds1 = tmp.check_id_pwd(p);//DBHamdle驗證

            if (ds1 != null)
            {
                foreach (DataRow dr in ds1.Tables["allInfo"].Rows)//DBHamdle中的table"allInfo"
                {
                    string id_check, pwd_check;
                    id_check = dr["m_id"].ToString();//把table"allInfo"中的member_id欄位轉字串
                    pwd_check = dr["m_pwd"].ToString();//把table"allInfo"中的member_pwd欄位轉字串
                    if ((id_check == InputAccount.Text) && (pwd_check == InputPassword.Text))//如果相等跳轉業面
                    {
                        Response.Redirect("home.aspx");
                        /*string p2 = "Select member_position,member_guid From member Where member_id='" + id + "'";//查詢身分

                        DataSet ds_position = tmp.GetPosition(p2);//檢查身分

                        if (ds_position != null)
                         {
                        foreach (DataRow dr_position in ds_position.Tables["position"].Rows)
                        {
                        string position_check, guid_check;
                        position_check = dr_position["member_position"].ToString();//把table"position"中的member_position欄位轉字串
                        guid_check = dr_position["member_guid"].ToString();
                         if (position_check == "1")
                         {
                        Session["position"] = position_check;
                        Session["guid"] = guid_check;
                        Response.Redirect("home.aspx");
                                }
                                if (position_check == "0")
                                {
                                    Session["position"] = position_check;
                                    Session["guid"] = guid_check;
                                    Response.Redirect("home.aspx");
                                }
                                if (position_check == "2")
                                {
                                    Response.Redirect("home.aspx");
                                }
                            }
                        }
                        */
                    }
                    else
                    {
                        alert_error.Visible = true;
                        msg_error.Visible = true;
                        msg_error.Text = "登錄失敗";
                    }
                }
            }
            #endregion
        }
    }
}