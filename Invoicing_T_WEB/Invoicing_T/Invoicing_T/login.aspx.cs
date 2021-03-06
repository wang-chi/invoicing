﻿using System;
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
    public partial class login : System.Web.UI.Page
    {
        DBHandle tmp = new DBHandle();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            //string Encrypt_nutc01 = AESEncrypt(EncodeString("nutc01".ToString().Trim()), "NUTC106");//加密方式
            //string Decrypt_nutc01 = DecodeString(AESDecrypt(Encrypt_nutc01, "NUTC106"));//解密方式
            //string Encrypt_nutc02 = AESEncrypt(EncodeString("nutc02".ToString().Trim()), "NUTC106");//加密方式
            //string Decrypt_nutc02 = DecodeString(AESDecrypt(Encrypt_nutc02, "NUTC106"));//解密方式
            //string Encrypt_nutc03 = AESEncrypt(EncodeString("nutc03".ToString().Trim()), "NUTC106");//加密方式
            //string Decrypt_nutc03 = DecodeString(AESDecrypt(Encrypt_nutc03, "NUTC106"));//解密方式
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = InputAccount.Text;
            string pwd = InputPassword.Text;//把密碼丟進字串pwd中
            string EncodePwd = AESEncrypt(EncodeString(pwd.ToString().Trim()), "NUTC106");
            //string p = "SELECT m_pwd, m_id FROM member";//查詢語法
            #region 執行SQL語法-驗證
            DataSet ds1 = tmp.LoginCheck(id);//DBHamdle驗證
            if (ds1 != null)
            {
                foreach (DataRow dr in ds1.Tables["allInfo"].Rows)//DBHamdle中的table"allInfo"
                {
                    string id_check, pwd_check;
                    id_check = dr["m_id"].ToString().Trim();//把table"allInfo"中的member_id欄位轉字串
                    pwd_check = dr["m_pwd"].ToString().Trim();//把table"allInfo"中的member_pwd欄位轉字串
                    if ((id_check == id) && (pwd_check == EncodePwd))//如果相等跳轉業面
                    {
                        string p2 = "SELECT m_state FROM member WHERE m_id='" + id + "'";//查詢身分
                        DataSet ds_position = tmp.GetState(p2);//檢查身分
                        if (ds_position != null)
                        {
                            foreach (DataRow dr_position in ds_position.Tables["state"].Rows)
                            {
                                string position_check;
                                position_check = dr_position["m_state"].ToString();//把table"position"中的member_position欄位轉字串

                                if (position_check == "True")
                                {
                                    Session.Add("UserID", id);//存取使用者ID
                                    Response.Redirect("HomePage.aspx");

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
        protected string DecodeString(string data)
        {
            #region 解密字串
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(data);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);

                return result;
            }
            catch (Exception e)
            {
                //throw new Exception("Error in base64Decode" + e.Message);
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

        public static string AESDecrypt(string SourceStr, string CryptoKey)
        {
            #region AES解密
            string decrypt = "";
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
                byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
                aes.Key = key;
                aes.IV = iv;

                byte[] dataByteArray = Convert.FromBase64String(SourceStr);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(dataByteArray, 0, dataByteArray.Length);
                        cs.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                //System.Windows.Forms.MessageBox.Show(e.Message);
                return "0";
            }
            return decrypt;
            #endregion
        }


    }
}