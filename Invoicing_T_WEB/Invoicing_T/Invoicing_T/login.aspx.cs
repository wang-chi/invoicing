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
<<<<<<< HEAD
            //tmp.DB_Cnstr = "Data Source=DESKTOP-OP0RFML\\SQLEXPRESS;Initial Catalog=Invoicing_T;Integrated Security=False;User ID=user13106;Password=123";//進入資料庫
            tmp.DB_Cnstr = "Server=tcp:nutc106db.database.windows.net,1433;Initial Catalog=invoicing;Persist Security Info=False;User ID={nutc03};Password={NUTCia003};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
=======
>>>>>>> a7bb961776122ecb2c3f70bd146c558aaff5bc52
            //Session.Remove("position");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = InputAccount.Text;
            string pwd = InputPassword.Text;//把密碼丟進字串pwd中
            string p = "Select m_pwd, m_id From member";//查詢語法

            #region 執行SQL語法-驗證
            DataSet ds1 = tmp.check_id_pwd(p);//DBHamdle驗證

            if (ds1 != null)
            {
                foreach (DataRow dr in ds1.Tables["allInfo"].Rows)//DBHamdle中的table"allInfo"
                {
                    string id_check, pwd_check;
                    id_check = dr["m_id"].ToString().Trim();//把table"allInfo"中的member_id欄位轉字串
                    pwd_check = dr["m_pwd"].ToString().Trim();//把table"allInfo"中的member_pwd欄位轉字串
                    if ((id_check == InputAccount.Text) && (pwd_check == InputPassword.Text))//如果相等跳轉業面
                    {
                        string p2 = "Select m_position From member Where m_id='" + id + "'";//查詢身分

                        DataSet ds_position = tmp.GetPosition(p2);//檢查身分

                        if (ds_position != null)
                         {
                        foreach (DataRow dr_position in ds_position.Tables["position"].Rows)
                        {
                        string position_check;
                        position_check = dr_position["m_position"].ToString();//把table"position"中的member_position欄位轉字串

                         if (position_check == "True")
                         {
                        //Session["position"] = position_check; //把值丟掉下一頁
                        Response.Redirect("home.aspx");
                                }

                        if (position_check == "False")
                         {
                                    msg_error.Text = "帳號被停權無法啟用";
                                }
                            }
                        }
                        
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