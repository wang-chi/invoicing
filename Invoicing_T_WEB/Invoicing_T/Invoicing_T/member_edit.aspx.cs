using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class member_edit : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();
        String member_tmp_p;
        protected void Page_Load(object sender, EventArgs e)
        {
            //String this_position = Session["m_id"].ToString();
            if (!IsPostBack)
            {
                if (Request.QueryString["m_id"] != null)//要判斷一下是否有該URL參數
                {
                    HiddenF_mid.Value = Request.QueryString["m_id"].ToString();//主索引
                    this.SetMaintainData(HiddenF_mid.Value);//設定要維護的資料
                }

            }
        }

        private void SetMaintainData(string p)
        {

            #region 查詢帳號資料


            DataSet ds1 = tmp.GetMemberInfo(p);
            if (ds1 != null)
            {
                DataRow tmpDataRow = ds1.Tables["member_info"].Rows[0];

                m_id.Text = tmpDataRow["m_id"].ToString();
                //m_pwd.Text = tmpDataRow["m_pwd"].ToString();
                m_state.Text = tmpDataRow["m_state"].ToString();
                m_name.Text = tmpDataRow["m_name"].ToString();
                m_sex.Text = tmpDataRow["m_sex"].ToString();
                r_id.Text = tmpDataRow["r_id"].ToString();
                m_phone.Text = tmpDataRow["m_phone"].ToString();
                m_email.Text = tmpDataRow["m_email"].ToString();
            }

            if (m_state.Text == "True")
            {
                m_state.Text = "啟用中";
                bt_position.Text = "停權";
                bt_position.CssClass = "btn btn-danger";
            }

            if (m_state.Text == "False")
            {
                m_state.Text = "停權中";
                bt_position.Text = "啟用";
                bt_position.CssClass = "btn btn-success";
            }

            #endregion
        }

        protected void btn_position_check(object sender, EventArgs e)
        {
            if (m_state.Text == "啟用中")
            {
                member_tmp_p = "False";
            }

            if (m_state.Text == "停權中")
            {
                member_tmp_p = "True";
            }
            tmp.UpdateMemberData(member_tmp_p, m_id.Text);

            Server.Transfer("member_manage.aspx", true);//導回查詢頁
        }

        protected void btn_resetpwd(object sender, EventArgs e)
        {
            #region 按鈕:重設密碼
            string pwd = AESEncrypt(EncodeString(m_id.Text.ToString().Trim()), "NUTC106");//加密方式
            tmp.UpdataPassword(m_id.Text, pwd);
            Server.Transfer("member_manage.aspx", true);//導回查詢頁
            #endregion
        }
        protected string EncodeString(string toEncode)
        {
            #region 加密字串

            try
            {
                byte[] toEncodeAsBytes = Encoding.UTF8.GetBytes(toEncode);
                return Convert.ToBase64String(toEncodeAsBytes);

            }
            catch (Exception e)
            {
                //thorow new Exception();
                //throw new Exception("Error in base64Encode" + e.Message);
                return "0";
            }
            #endregion
        }

        public static string AESEncrypt(string SourceStr, string CryptoKey)
        {
            #region AES加密
            string encrypt = "";
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
                byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
                aes.Key = key;
                aes.IV = iv;

                byte[] dataByteArray = Encoding.UTF8.GetBytes(SourceStr);
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    encrypt = Convert.ToBase64String(ms.ToArray());
                }
            }
            catch (Exception e)
            {
                //System.Windows.Forms.MessageBox.Show(e.Message);
            }
            return encrypt;
            #endregion
        }


    }
}