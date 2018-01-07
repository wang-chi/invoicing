using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Invoicing_T
{
    public class DBHandle
    {
        public SqlConnectionStringBuilder ConnectionAzure()
        {
            #region 執行SQL語法-連線資料庫
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "nutc106db.database.windows.net";
            cb.UserID = "nutc03";
            cb.Password = "NUTCia03";
            cb.InitialCatalog = "invoicing";
            return cb;

            #endregion
        }

        public void Insert(string p)
        {
            #region 執行SQL語法-新增員工/群組/廠商
            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                SqlTransaction tran = null;//產生物件
                SqlCommand cmd = new SqlCommand();//新增cmd的物件
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    try
                    {
                        cn.Open();
                        tran = cn.BeginTransaction();//建立SqlConnection交易
                        cmd.CommandText = p;
                        cmd.Connection = cn;//指定連線物件
                        cmd.Transaction = tran;//建立SqlConnection交易
                        cmd.ExecuteNonQuery();//執行SQL語法
                        cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                        cn.Close();
                    }
                    catch (Exception)
                    {
                        cmd.Transaction.Rollback();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }

        internal DataSet GetDDL(String p)
        {
            #region 執行SQL語法-群組下拉查詢

            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = p;//
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                    dr.Fill(ds, "ddl_info");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }

            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            return ds;//回傳DataSet的表

            #endregion
        }

        public DataSet GetId(string p)
        {
            #region 檢測帳號是否重複
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "nutc106db.database.windows.net";
                cb.UserID = "nutc03";
                cb.Password = "NUTCia03";
                cb.InitialCatalog = "invoicing";
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    cmd.CommandText = p;
                    cmd.Connection = cn;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds, "idInfo");
                    cn.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return ds;
            #endregion

        }

        public DataSet GetNewId(String p)
        {
            #region 找尋最後的帳號
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    cmd.CommandText = p;
                    cmd.Connection = cn;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds, "selectnewid");
                    cn.Close();
                }
            }
            catch
            {
                return null;
            }
            return ds;
            #endregion
        }

        public DataSet GetSupplierId(string p)
        {
            #region 檢測廠商帳號是否重複
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "nutc106db.database.windows.net";
                cb.UserID = "nutc03";
                cb.Password = "NUTCia03";
                cb.InitialCatalog = "invoicing";
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    cmd.CommandText = p;
                    cmd.Connection = cn;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds, "SupplierInfo");
                    cn.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return ds;
            #endregion
        }

        public DataSet GetClientId(string p)
        {
            #region 檢測客戶帳號是否重複
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "nutc106db.database.windows.net";
                cb.UserID = "nutc03";
                cb.Password = "NUTCia03";
                cb.InitialCatalog = "invoicing";
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    cmd.CommandText = p;
                    cmd.Connection = cn;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds, "ClientInfo");
                    cn.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return ds;
            #endregion
        }

        public DataSet GetProductTypeId(string p)
        {
            #region 檢測商品類別帳號是否重複
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "nutc106db.database.windows.net";
                cb.UserID = "nutc03";
                cb.Password = "NUTCia03";
                cb.InitialCatalog = "invoicing";
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    cmd.CommandText = p;
                    cmd.Connection = cn;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds, "ProductTypeInfo");
                    cn.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return ds;
            #endregion
        }

        public DataSet GetProductId(string p)
        {
            #region 檢測商品編號是否重複
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "nutc106db.database.windows.net";
                cb.UserID = "nutc03";
                cb.Password = "NUTCia03";
                cb.InitialCatalog = "invoicing";
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    cmd.CommandText = p;
                    cmd.Connection = cn;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds, "ProductInfo");
                    cn.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return ds;
            #endregion
        }

        public DataSet GetGroupId(string p)
        {
            #region 檢測群組帳號是否重複
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    cmd.CommandText = p;
                    cmd.Connection = cn;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds, "groupInfo");
                    cn.Close();
                }
            }
            catch
            {
                return null;
            }
            return ds;
            #endregion
        }

        public DataSet GetAuthId(string p)
        {
            #region 檢測權限帳號是否重複
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    cmd.CommandText = p;
                    cmd.Connection = cn;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds, "authInfo");
                    cn.Close();
                }
            }
            catch
            {
                return null;
            }
            return ds;
            #endregion
        }

        public DataSet GetPurchesaaId(string p)
        {
            #region 檢測進貨單編號是否重複
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "nutc106db.database.windows.net";
                cb.UserID = "nutc03";
                cb.Password = "NUTCia03";
                cb.InitialCatalog = "invoicing";
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    cmd.CommandText = p;
                    cmd.Connection = cn;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds, "PurchesasInfo");
                    cn.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return ds;
            #endregion
        }


        public DataSet LoginCheck(string m_id)
        {
            #region 驗證帳號及密碼        
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {

                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    //string sql = "SELECT m_pwd, m_id FROM member WHERE m_id = '"+m_id+"'";//查詢語法
                    cmd.CommandText = "SELECT m_pwd, m_id FROM member WHERE m_id = '" + m_id + "'";
                    cmd.Connection = cn;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds, "allInfo");
                    cn.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return ds;
            #endregion
        }
        internal DataSet CheckAuth(string m_id)
        {
            #region 檢查功能權限
            SqlConnectionStringBuilder cb = ConnectionAzure();
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();
            try
            {
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    //設定SQL的語法(I->新增S->修改U->查詢D->刪除)(ISUD=CRUD)
                    cmd.CommandText = "SELECT m.m_id,ra.r_id, a.a_page ,ra.viewmode FROM member m, roles_auth ra, auth a WHERE  ra.a_id = a.a_id AND ra.r_id = m.r_id AND m.m_id = '" + m_id + "'";
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表
                    dr.Fill(ds, "CheckAuth");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }
            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            return ds;//回傳DataSet的表
            #endregion
        }


        internal DataSet GetState(string p)
        {
            #region 分辨身分是否停權
            DataSet ds = new DataSet();
            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                SqlCommand cmd = new SqlCommand();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    cmd.CommandText = p;
                    cmd.Connection = cn;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds, "state");
                    cn.Close();
                }

            }
            catch
            {
                return null;
            }

            return ds;
            #endregion
        }

        internal DataSet GetMemberInfo()
        {
            #region 個人資料查詢
            SqlConnectionStringBuilder cb = ConnectionAzure();
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();
            try
            {
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    cmd.CommandText = "SELECT * FROM member"; //設定SQL的語法(I->新增S->修改U->查詢D->刪除)(ISUD=CRUD)
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表
                    dr.Fill(ds, "member_info");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }
            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            return ds;//回傳DataSet的表
            #endregion
        }

        internal DataSet GetGroupInfo()
        {
            #region 群組資料查詢

            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();
            SqlConnectionStringBuilder cb = ConnectionAzure();
            try
            {
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    cmd.CommandText = "SELECT * FROM rolegroup";//設定SQL的語法(I->新增S->修改U->查詢D->刪除)(ISUD=CRUD)
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表
                    dr.Fill(ds, "group_info");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }

            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            return ds;//回傳DataSet的表
            #endregion
        }

        internal DataSet GetGroup(String p)
        {
            #region 執行SQL語法-顯示群組資料
            String tmpSql = "SELECT r_id, r_name FROM roles" + p;
            SqlConnectionStringBuilder cb = ConnectionAzure();
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫

                    cmd.CommandText = tmpSql;

                    cmd.Connection = cn;//指定連線物件

                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                    dr.Fill(ds, "roles");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }


            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值

            }

            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetRolesAuth(String p)
        {
            #region 執行SQL語法-顯示群組及權限資料
            String tmpSql = "SELECT roles_auth.*,auth.* FROM roles_auth,auth WHERE roles_auth.r_id='" + p + "' AND roles_auth.a_id=auth.a_id  ";
            SqlConnectionStringBuilder cb = ConnectionAzure();
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫

                    cmd.CommandText = tmpSql;

                    cmd.Connection = cn;//指定連線物件

                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                    dr.Fill(ds, "rolesauth");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }


            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值

            }

            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetAuth(String p)
        {
            #region 執行SQL語法-顯示權限資料

            String tmpSql = "SELECT * FROM auth " + p;


            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();

                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmpSql;
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表
                    dr.Fill(ds, "authgroup");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }

            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetMember(String p)
        {
            #region 執行SQL語法-顯示帳號資料
            String tmpSql = "SELECT member.*,roles.r_name FROM member,roles WHERE member.r_id=roles.r_id  " + p;
            SqlConnectionStringBuilder cb = ConnectionAzure();
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫

                    cmd.CommandText = tmpSql;

                    cmd.Connection = cn;//指定連線物件

                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                    dr.Fill(ds, "member");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }
            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }


            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetMemberEdit(String p)
        {
            #region 執行SQL語法-顯示帳號資料
            String tmpSql = "SELECT member.*,roles.r_name FROM member,roles WHERE member.m_id='" + p + "' AND member.r_id=roles.r_id";
            SqlConnectionStringBuilder cb = ConnectionAzure();
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫

                    cmd.CommandText = tmpSql;

                    cmd.Connection = cn;//指定連線物件

                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                    dr.Fill(ds, "member");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }
            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }


            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetMemberInfo(string p)
        {
            #region 查詢member資料
            string tmp = "SELECT * FROM member WHERE m_id=@m_id";
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmp;//
                    cmd.Parameters.AddWithValue("@m_id", p);//定義參數
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                    dr.Fill(ds, "member_info");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }

            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetCompanyInfo()
        {
            #region 查詢company資料
            string tmp = "SELECT * FROM company";
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmp;//
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                    dr.Fill(ds, "company_info");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }

            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetGroupInfo(string p)
        {
            #region 查詢group資料
            string tmp = "SELECT * FROM roles WHERE r_id=@r_id";
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmp;//
                    cmd.Parameters.AddWithValue("@r_id", p);//定義參數
                    cmd.Connection = cn;//指定連線物件

                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                    dr.Fill(ds, "group_info");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }

            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }


            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetAuthInfo(string p)
        {
            #region 查詢auth資料
            string tmp = "SELECT * FROM auth WHERE a_id=@a_id";
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmp;//
                    cmd.Parameters.AddWithValue("@a_id", p);//定義參數
                    cmd.Connection = cn;//指定連線物件

                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                    dr.Fill(ds, "auth_info");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }

            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }


            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetSupplier(String p)
        {
            #region 執行SQL語法-顯示廠商資料
            String tmpSql = "SELECT * FROM supplier" + p;
            SqlConnectionStringBuilder cb = ConnectionAzure();
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmpSql;
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表
                    dr.Fill(ds, "supplier");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }
            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }


            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetPurchases(String p)
        {
            #region 執行SQL語法-顯示進貨單單頭資料
            String tmpSql = "SELECT * FROM purchases" + p;
            SqlConnectionStringBuilder cb = ConnectionAzure();
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();
            try
            {
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmpSql;
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表
                    dr.Fill(ds, "purchases");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }
            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            return ds;//回傳DataSet的表
            #endregion
        }

        internal DataSet GetPurchasesinfoInfo(String p)
        {
            #region 執行SQL語法-顯示進貨單單頭資料
            String tmpSql = "SELECT purchases_info.*,product.*  FROM purchases_info,product WHERE purchases_info.pur_id='" + p + "' AND  purchases_info.p_id= product.p_id";
            SqlConnectionStringBuilder cb = ConnectionAzure();
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmpSql;
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表
                    dr.Fill(ds, "purchases_info_info");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }
            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }


            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetProductType(String p)
        {
            #region 執行SQL語法-顯示商品種類資料
            String tmpSql = "SELECT * FROM product_type" + p;
            SqlConnectionStringBuilder cb = ConnectionAzure();
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmpSql;
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表
                    dr.Fill(ds, "product_type");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }
            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }


            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetProduct(String p)
        {
            #region 執行SQL語法-顯示商品資料
            String tmpSql = "SELECT * FROM product" + p;
            SqlConnectionStringBuilder cb = ConnectionAzure();
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmpSql;
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表
                    dr.Fill(ds, "product");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }
            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }


            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetPrice(string p_id)
        {
            #region 分辨身分是否停權
            DataSet ds = new DataSet();
            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                SqlCommand cmd = new SqlCommand();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    string p = "SELECT p_price FROM product WHERE p_id = '" + p_id + "'";
                    cmd.CommandText = p;
                    cmd.Connection = cn;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds, "price");
                    cn.Close();
                }

            }
            catch
            {
                return null;
            }

            return ds;
            #endregion
        }

        internal DataSet GetClient(String p)
        {
            #region 執行SQL語法-顯示帳號資料
            String tmpSql = "SELECT * FROM client " + p;
            SqlConnectionStringBuilder cb = ConnectionAzure();
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmpSql;
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表
                    dr.Fill(ds, "client");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }
            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }


            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetSupplierInfo(string p)
        {
            #region 查詢supplier資料


            string tmp = "SELECT * FROM supplier WHERE s_id=@s_id";
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();
            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmp;//
                    cmd.Parameters.AddWithValue("@s_id", p);//定義參數
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                    dr.Fill(ds, "supplier_info");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }

            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetClientInfo(string p)
        {
            #region 查詢client資料

            string tmp = "SELECT * FROM client WHERE c_id=@c_id";
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();
            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmp;//
                    cmd.Parameters.AddWithValue("@c_id", p);//定義參數
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                    dr.Fill(ds, "client_info");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }

            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetProductTypeInfo(string p)
        {
            #region 查詢product_type資料


            string tmp = "SELECT * FROM product_type WHERE pt_id=@pt_id";
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();
            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmp;//
                    cmd.Parameters.AddWithValue("@pt_id", p);//定義參數
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                    dr.Fill(ds, "product_type_info");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }

            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetProductInfo(string p)
        {
            #region 查詢product資料


            string tmp = "SELECT * FROM product WHERE p_id=@p_id";
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();
            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmp;//
                    cmd.Parameters.AddWithValue("@p_id", p);//定義參數
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                    dr.Fill(ds, "product_info");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }

            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetSupplierPriceInfo(string p)
        {
            #region 查詢supplier_price資料


            string tmp = "SELECT * FROM supplier_price WHERE sp_id=@sp_id";
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();
            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmp;//
                    cmd.Parameters.AddWithValue("@sp_id", p);//定義參數
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                    dr.Fill(ds, "supplier_price_info");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }

            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetClientPriceInfo(string p)
        {
            #region 查詢client_price資料


            string tmp = "SELECT * FROM client_price WHERE cp_id=@cp_id";
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();
            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmp;//
                    cmd.Parameters.AddWithValue("@cp_id", p);//定義參數
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                    dr.Fill(ds, "client_price_info");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }

            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetPurchasesInfo(string p)
        {
            #region 查詢purchases資料


            string tmp = "SELECT * FROM purchases WHERE pur_id=@pur_id";
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();
            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmp;//
                    cmd.Parameters.AddWithValue("@pur_id", p);//定義參數
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                    dr.Fill(ds, "purchases_info");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }

            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            return ds;//回傳DataSet的表

            #endregion
        }

        internal void InsertCampData(Dictionary<string, object> tmpViewData, String this_member)
        {
            #region 執行SQL語法-新增至資料庫
            string tmp = @"INSERT INTO House_detail(house_guid, house_title, house_city, house_area,house_address,
house_rent,house_deposit,house_footage,house_floor,house_totalfloor,house_patterns,house_situation,
house_parking,house_community,house_fee,house_renttime,IS_cook,IS_pet,
house_state_student,house_state_woker,house_staet_family,house_sex_ask,house_moved,
IS_TV, IS_REF, IS_ac, IS_Cac, IS_W, IS_dryer, IS_H, IS_df,IS_lamp,IS_Net,IS_CATV,IS_phone,
IS_sofa,IS_wardrobe,IS_single_bed,IS_double_bed,IS_bookcase,IS_desk_chair,
IS_balc,IS_yard,IS_metro_P,IS_car_P,IS_elev,IS_LR,IS_KIT,IS_window,
IS_natural_gas,IS_bottledl_gas,IS_indoorsl_gas,IS_outdoorsl_gas,IS_electricl_gas,IS_sun_gas,
IS_access,IS_FE,IS_smoke,IS_fire,IS_esladder,IS_essling,IS_EL,IS_moniter,IS_exhauster,IS_COalarm,IS_header,IS_security,IS_route,house_inside,member_guid)
Values(@house_guid,@house_title,@house_city,@house_area,@house_address,
@house_rent,@house_deposit,@house_footage,@house_floor,@house_totalfloor,@house_patterns,@house_situation,
@house_parking,@house_community,@house_fee,@house_renttime,@IS_cook,@IS_pet,
@house_state_student,@house_state_woker,@house_staet_family,@house_sex_ask,@house_moved,
@IS_TV,@IS_REF,@IS_ac,@IS_Cac,@IS_W,@IS_dryer,@IS_H,@IS_df,@IS_lamp,@IS_Net,@IS_CATV,@IS_phone,
@IS_sofa,@IS_wardrobe,@IS_single_bed,@IS_double_bed,@IS_bookcase,@IS_desk_chair,
@IS_balc,@IS_yard,@IS_metro_P,@IS_car_P,@IS_elev,@IS_LR,@IS_KIT,@IS_window,
@IS_natural_gas,@IS_bottledl_gas,@IS_indoorsl_gas,@IS_outdoorsl_gas,@IS_electricl_gas,@IS_sun_gas,
@IS_access,@IS_FE,@IS_smoke,@IS_fire,@IS_esladder,@IS_essling,@IS_EL,@IS_moniter,@IS_exhauster,@IS_COalarm,@IS_header,@IS_security,@IS_route,@house_inside,@member_guid)";
            //利用參數方式寫SQL語法
            SqlConnection cn = new SqlConnection("");
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            try
            {

                cn.Open();//開啟資料庫


                tran = cn.BeginTransaction();//建立SqlConnection交易

                cmd.CommandText = tmp;//新增
                #region 定義參數


                cmd.Parameters.AddWithValue("@house_guid", Guid.NewGuid().ToString());//新增亂數

                cmd.Parameters.AddWithValue("@house_title", tmpViewData["house_title"]);

                cmd.Parameters.AddWithValue("@house_city", tmpViewData["house_city"]);
                cmd.Parameters.AddWithValue("@house_area", tmpViewData["house_area"]);
                cmd.Parameters.AddWithValue("@house_address", tmpViewData["house_address"]);

                cmd.Parameters.AddWithValue("@house_rent", tmpViewData["house_rent"]);
                cmd.Parameters.AddWithValue("@house_deposit", tmpViewData["house_deposit"]);

                cmd.Parameters.AddWithValue("@house_footage", tmpViewData["house_footage"]);
                cmd.Parameters.AddWithValue("@house_floor", tmpViewData["house_floor"]);
                cmd.Parameters.AddWithValue("@house_totalfloor", tmpViewData["house_totalfloor"]);

                cmd.Parameters.AddWithValue("@house_patterns", tmpViewData["house_patterns"]);
                cmd.Parameters.AddWithValue("@house_situation", tmpViewData["house_situation"]);

                cmd.Parameters.AddWithValue("@house_parking", tmpViewData["house_parking"]);
                cmd.Parameters.AddWithValue("@house_community", tmpViewData["house_community"]);

                cmd.Parameters.AddWithValue("@house_fee", tmpViewData["house_fee"]);
                cmd.Parameters.AddWithValue("@house_renttime", tmpViewData["house_renttime"]);

                cmd.Parameters.AddWithValue("@IS_cook", tmpViewData["IS_cook"]);
                cmd.Parameters.AddWithValue("@IS_pet", tmpViewData["IS_pet"]);

                cmd.Parameters.AddWithValue("@house_state_student", tmpViewData["house_state_student"]);
                cmd.Parameters.AddWithValue("@house_state_woker", tmpViewData["house_state_woker"]);
                cmd.Parameters.AddWithValue("@house_staet_family", tmpViewData["house_staet_family"]);

                cmd.Parameters.AddWithValue("@house_sex_ask", tmpViewData["house_sex_ask"]);
                cmd.Parameters.AddWithValue("@house_moved", tmpViewData["house_moved"]);

                cmd.Parameters.AddWithValue("@IS_TV", tmpViewData["IS_TV"]);
                cmd.Parameters.AddWithValue("@IS_REF", tmpViewData["IS_REF"]);
                cmd.Parameters.AddWithValue("@IS_ac", tmpViewData["IS_ac"]);
                cmd.Parameters.AddWithValue("@IS_Cac", tmpViewData["IS_Cac"]);
                cmd.Parameters.AddWithValue("@IS_W", tmpViewData["IS_W"]);
                cmd.Parameters.AddWithValue("@IS_dryer", tmpViewData["IS_dryer"]);
                cmd.Parameters.AddWithValue("@IS_H", tmpViewData["IS_H"]);
                cmd.Parameters.AddWithValue("@IS_df", tmpViewData["IS_df"]);
                cmd.Parameters.AddWithValue("@IS_lamp", tmpViewData["IS_lamp"]);
                cmd.Parameters.AddWithValue("@IS_Net", tmpViewData["IS_Net"]);
                cmd.Parameters.AddWithValue("@IS_CATV", tmpViewData["IS_CATV"]);
                cmd.Parameters.AddWithValue("@IS_phone", tmpViewData["IS_phone"]);

                cmd.Parameters.AddWithValue("@IS_sofa", tmpViewData["IS_sofa"]);
                cmd.Parameters.AddWithValue("@IS_wardrobe", tmpViewData["IS_wardrobe"]);
                cmd.Parameters.AddWithValue("@IS_single_bed", tmpViewData["IS_single_bed"]);
                cmd.Parameters.AddWithValue("@IS_double_bed", tmpViewData["IS_double_bed"]);
                cmd.Parameters.AddWithValue("@IS_bookcase", tmpViewData["IS_bookcase"]);
                cmd.Parameters.AddWithValue("@IS_desk_chair", tmpViewData["IS_desk_chair"]);

                cmd.Parameters.AddWithValue("@IS_balc", tmpViewData["IS_balc"]);
                cmd.Parameters.AddWithValue("@IS_yard", tmpViewData["IS_yard"]);
                cmd.Parameters.AddWithValue("@IS_metro_P", tmpViewData["IS_metro_P"]);
                cmd.Parameters.AddWithValue("@IS_car_P", tmpViewData["IS_car_P"]);
                cmd.Parameters.AddWithValue("@IS_elev", tmpViewData["IS_elev"]);
                cmd.Parameters.AddWithValue("@IS_LR", tmpViewData["IS_LR"]);
                cmd.Parameters.AddWithValue("@IS_KIT", tmpViewData["IS_KIT"]);
                cmd.Parameters.AddWithValue("@IS_window", tmpViewData["IS_window"]);

                cmd.Parameters.AddWithValue("@IS_natural_gas", tmpViewData["IS_natural_gas"]);
                cmd.Parameters.AddWithValue("@IS_bottledl_gas", tmpViewData["IS_bottledl_gas"]);
                cmd.Parameters.AddWithValue("@IS_indoorsl_gas", tmpViewData["IS_indoorsl_gas"]);
                cmd.Parameters.AddWithValue("@IS_outdoorsl_gas", tmpViewData["IS_outdoorsl_gas"]);
                cmd.Parameters.AddWithValue("@IS_electricl_gas", tmpViewData["IS_electricl_gas"]);
                cmd.Parameters.AddWithValue("@IS_sun_gas", tmpViewData["IS_sun_gas"]);

                cmd.Parameters.AddWithValue("@IS_access", tmpViewData["IS_access"]);
                cmd.Parameters.AddWithValue("@IS_FE", tmpViewData["IS_FE"]);
                cmd.Parameters.AddWithValue("@IS_smoke", tmpViewData["IS_smoke"]);
                cmd.Parameters.AddWithValue("@IS_fire", tmpViewData["IS_fire"]);
                cmd.Parameters.AddWithValue("@IS_esladder", tmpViewData["IS_esladder"]);
                cmd.Parameters.AddWithValue("@IS_essling", tmpViewData["IS_essling"]);
                cmd.Parameters.AddWithValue("@IS_EL", tmpViewData["IS_EL"]);
                cmd.Parameters.AddWithValue("@IS_moniter", tmpViewData["IS_moniter"]);
                cmd.Parameters.AddWithValue("@IS_exhauster", tmpViewData["IS_exhauster"]);
                cmd.Parameters.AddWithValue("@IS_COalarm", tmpViewData["IS_COalarm"]);
                cmd.Parameters.AddWithValue("@IS_header", tmpViewData["IS_header"]);
                cmd.Parameters.AddWithValue("@IS_security", tmpViewData["IS_security"]);
                cmd.Parameters.AddWithValue("@IS_route", tmpViewData["IS_route"]);

                cmd.Parameters.AddWithValue("@house_inside", tmpViewData["house_inside"]);

                cmd.Parameters.AddWithValue("@member_guid", this_member);

                #endregion

                cmd.Connection = cn;//指定連線物件

                cmd.Transaction = tran;//建立SqlConnection交易


                cmd.ExecuteNonQuery();//執行SQL語法

                cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }
            finally
            {
                if (cn.State.Equals(ConnectionState.Open))
                {
                    cn.Close();
                }
            }
            #endregion
        }

        internal void UpdateMemberData(String member_position, String m_id)
        {
            #region 執行SQL語法-修改員工資料(停權與否)
            string tmp = "Update member set m_state='" + member_position + "'  WHERE m_id='" + m_id + "'";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();

                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫


                    tran = cn.BeginTransaction();//建立SqlConnection交易

                    cmd.CommandText = tmp;//新增

                    cmd.Connection = cn;//指定連線物件

                    cmd.Transaction = tran;//建立SqlConnection交易


                    cmd.ExecuteNonQuery();//執行SQL語法

                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void DeleteGroup(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-刪除群組資料
            string tmp = @"Delete  FROM roles WHERE r_id=@r_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫


                    tran = cn.BeginTransaction();//建立SqlConnection交易

                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@r_id", tmpViewData["r_id"]);
                    #endregion
                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法
                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void DeleteAuth(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-刪除權限資料
            string tmp = @"Delete  FROM auth WHERE a_id=@a_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫


                    tran = cn.BeginTransaction();//建立SqlConnection交易

                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@a_id", tmpViewData["a_id"]);
                    #endregion
                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法
                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void DeleteSupplier(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-刪除廠商資料
            string tmp = @"Delete  FROM supplier WHERE s_id=@s_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫


                    tran = cn.BeginTransaction();//建立SqlConnection交易

                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@s_id", tmpViewData["s_id"]);
                    #endregion
                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法
                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void DeleteClient(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-刪除客戶資料
            string tmp = @"Delete  FROM client WHERE c_id=@c_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫


                    tran = cn.BeginTransaction();//建立SqlConnection交易

                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@c_id", tmpViewData["c_id"]);
                    #endregion
                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法
                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void DeleteProductType(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-刪除商品類別資料
            string tmp = @"Delete  FROM product_type WHERE pt_id=@pt_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫


                    tran = cn.BeginTransaction();//建立SqlConnection交易

                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@pt_id", tmpViewData["pt_id"]);
                    #endregion
                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法
                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void DeleteProduct(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-刪除商品資料
            string tmp = @"Delete  FROM product WHERE p_id=@p_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫


                    tran = cn.BeginTransaction();//建立SqlConnection交易

                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@p_id", tmpViewData["p_id"]);
                    #endregion
                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法
                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void DeletePurchases(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-刪除進貨單資料
            string tmp = @"Delete FROM purchases WHERE pur_id=@pur_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫


                    tran = cn.BeginTransaction();//建立SqlConnection交易

                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@pur_id", tmpViewData["pur_id"]);
                    #endregion
                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法
                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }
        internal void DeletePurchasesInfo(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-刪除進貨單詳細資料
            string tmp = @"Delete FROM purchases_info WHERE pur_id=@pur_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫


                    tran = cn.BeginTransaction();//建立SqlConnection交易

                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@pur_id", tmpViewData["pur_id"]);
                    #endregion
                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法
                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal DataSet Getmemberall(string s_id, string s_name)
        {
            #region 執行SQL語法-顯示資料


            String tmpSql = "SELECT member_guid,member_id,member_pwd,member_name,member_email FROM Member_Info WHERE 1=1  AND member_id LIKE '%" + s_id + "%' AND  member_name LIKE'%" + s_name + "%'";
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    cmd.CommandText = tmpSql;
                    cmd.Connection = cn;//指定連線物件
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表
                    dr.Fill(ds, "member_all");//在DataSet中查詢,為DataSet中的資料表重新命名
                    cn.Close();
                }
            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            return ds;//回傳DataSet的表

            #endregion
        }

        internal DataSet GetMemberData(string p)
        {
            #region 修改/刪除會員
            string tmp = "SELECT * FROM Member_Info WHERE member_guid=@member_guid";
            SqlConnection cn = new SqlConnection("");
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();
            try
            {
                cn.Open();//開啟資料庫
                cmd.CommandText = tmp;//
                cmd.Parameters.AddWithValue("@member_guid", p);//定義參數
                cmd.Connection = cn;//指定連線物件

                SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                dr.Fill(ds, "MemberData");//在DataSet中查詢,為DataSet中的資料表重新命名

            }
            catch (Exception)
            {
                return null;//如果錯誤  回傳null值
            }
            finally
            {
                if (cn.State.Equals(ConnectionState.Open))
                {
                    cn.Close();
                }
            }

            return ds;//回傳DataSet的表

            #endregion
        }

        internal void UpDateMemberData(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-修改會員
            string tmp = @"Update Member_Info set member_name=@member_name, member_email=@member_email  WHERE member_guid=@member_guid";//利用參數方式寫SQL語法
            SqlConnection cn = new SqlConnection("");
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {

                cn.Open();//開啟資料庫


                tran = cn.BeginTransaction();//建立SqlConnection交易

                cmd.CommandText = tmp;//新增
                #region 定義參數
                cmd.Parameters.AddWithValue("@member_guid", tmpViewData["member_guid"]);
                cmd.Parameters.AddWithValue("@member_name", tmpViewData["member_name"]);
                cmd.Parameters.AddWithValue("@member_email", tmpViewData["member_email"]);



                #endregion

                cmd.Connection = cn;//指定連線物件

                cmd.Transaction = tran;//建立SqlConnection交易


                cmd.ExecuteNonQuery();//執行SQL語法

                cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }
            finally
            {
                if (cn.State.Equals(ConnectionState.Open))
                {
                    cn.Close();
                }
            }
            #endregion
        }

        internal void UpdataPassword(string m_id, string m_pwd)
        {
            #region 執行SQL語法-重設密碼
            string tmp = @"Update member set m_pwd=@m_pwd WHERE m_id=@m_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    tran = cn.BeginTransaction();//建立SqlConnection交易
                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@m_pwd", m_pwd);
                    cmd.Parameters.AddWithValue("@m_id", m_id);
                    #endregion
                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法
                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }

            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void DeleteMemberData(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-刪除會員
            string tmp = @"Delete  FROM Member_Info WHERE member_guid=@member_guid";//利用參數方式寫SQL語法
            SqlConnection cn = new SqlConnection("");
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {

                cn.Open();//開啟資料庫


                tran = cn.BeginTransaction();//建立SqlConnection交易

                cmd.CommandText = tmp;//新增
                #region 定義參數
                cmd.Parameters.AddWithValue("@member_guid", tmpViewData["member_guid"]);

                #endregion

                cmd.Connection = cn;//指定連線物件

                cmd.Transaction = tran;//建立SqlConnection交易


                cmd.ExecuteNonQuery();//執行SQL語法

                cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }
            finally
            {
                if (cn.State.Equals(ConnectionState.Open))
                {
                    cn.Close();
                }
            }
            #endregion
        }

        internal void UpdateGroup(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-修改群組資料
            // string tmp = "Update roles set r_name=@r_name,r_info=@r_info,update_time= GETDATE()  WHERE r_id=@r_id";//利用參數方式寫SQL語法
            string tmp = "Update roles set r_name=@r_name  WHERE r_id=@r_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    tran = cn.BeginTransaction();//建立SqlConnection交易
                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@r_id", tmpViewData["r_id"]);
                    cmd.Parameters.AddWithValue("@r_name", tmpViewData["r_name"]);
                    //cmd.Parameters.AddWithValue("@r_info", tmpViewData["r_info"]);
                    #endregion

                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法

                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }

            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void UpdateMember(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-修改個人資料

            string tmp = "Update member set m_name=@m_name,m_sex=@m_sex,m_phone=@m_phone,m_email=@m_email  WHERE m_id=@m_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    tran = cn.BeginTransaction();//建立SqlConnection交易
                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@m_name", tmpViewData["m_name"]);
                    cmd.Parameters.AddWithValue("@m_sex", tmpViewData["m_sex"]);
                    cmd.Parameters.AddWithValue("@m_phone", tmpViewData["m_phone"]);
                    cmd.Parameters.AddWithValue("@m_email", tmpViewData["m_email"]);
                    cmd.Parameters.AddWithValue("@m_id", tmpViewData["m_id"]);

                    #endregion

                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法

                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }

            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void UpdateAuth(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-修改權限資料
            string tmp = "Update auth set a_name=@a_name  WHERE a_id=@a_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    tran = cn.BeginTransaction();//建立SqlConnection交易
                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@a_id", tmpViewData["a_id"]);
                    cmd.Parameters.AddWithValue("@a_name", tmpViewData["a_name"]);
                    //cmd.Parameters.AddWithValue("@r_info", tmpViewData["r_info"]);
                    #endregion

                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法

                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }

            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void UpdateCompany(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-修改公司資料

            string tmp = "Update company set com_name=@com_name,com_address=@com_address,com_un=@com_un,com_agent=@com_agent,com_tel=@com_tel,com_fax=@com_fax  WHERE com_id='C0001'";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    tran = cn.BeginTransaction();//建立SqlConnection交易
                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@com_name", tmpViewData["com_name"]);
                    cmd.Parameters.AddWithValue("@com_address", tmpViewData["com_address"]);
                    cmd.Parameters.AddWithValue("@com_un", tmpViewData["com_un"]);
                    cmd.Parameters.AddWithValue("@com_agent", tmpViewData["com_agent"]);
                    cmd.Parameters.AddWithValue("@com_tel", tmpViewData["com_tel"]);
                    cmd.Parameters.AddWithValue("@com_fax", tmpViewData["com_fax"]);
                    #endregion

                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法

                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }

            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void UpdateSupplier(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-修改廠商資料
            string tmp = "Update supplier set s_name=@s_name,s_address=@s_address,s_phone=@s_phone,s_email=@s_email  WHERE s_id=@s_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    tran = cn.BeginTransaction();//建立SqlConnection交易
                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@s_id", tmpViewData["s_id"]);
                    cmd.Parameters.AddWithValue("@s_name", tmpViewData["s_name"]);
                    cmd.Parameters.AddWithValue("@s_address", tmpViewData["s_address"]);
                    cmd.Parameters.AddWithValue("@s_phone", tmpViewData["s_phone"]);
                    cmd.Parameters.AddWithValue("@s_email", tmpViewData["s_email"]);
                    #endregion

                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法

                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }

            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void UpdateClient(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-修改客戶資料
            string tmp = "Update client set c_name=@c_name,c_address=@c_address,c_phone=@c_phone,c_email=@c_email  WHERE c_id=@c_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    tran = cn.BeginTransaction();//建立SqlConnection交易
                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@c_id", tmpViewData["c_id"]);
                    cmd.Parameters.AddWithValue("@c_name", tmpViewData["c_name"]);
                    cmd.Parameters.AddWithValue("@c_address", tmpViewData["c_address"]);
                    cmd.Parameters.AddWithValue("@c_phone", tmpViewData["c_phone"]);
                    cmd.Parameters.AddWithValue("@c_email", tmpViewData["c_email"]);
                    #endregion

                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法

                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }

            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void UpdateProductType(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-修改商品類別資料
            string tmp = "Update product_type set pt_name=@pt_name  WHERE pt_id=@pt_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    tran = cn.BeginTransaction();//建立SqlConnection交易
                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@pt_id", tmpViewData["pt_id"]);
                    cmd.Parameters.AddWithValue("@pt_name", tmpViewData["pt_name"]);
                    #endregion

                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法

                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }

            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void UpdateProduct(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-修改商品資料
            string tmp = "Update product set p_name=@p_name,pt_id=@pt_id WHERE p_id=@p_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    tran = cn.BeginTransaction();//建立SqlConnection交易
                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@p_id", tmpViewData["p_id"]);
                    cmd.Parameters.AddWithValue("@p_name", tmpViewData["p_name"]);
                    cmd.Parameters.AddWithValue("@pt_id", tmpViewData["pt_id"]);
                    #endregion

                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法

                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }

            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void UpdatePurchases(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-修改進貨單資料
            string tmp = "Update purchases set m_id=@m_id,accept=@accept,deliverydate=@deliverydate,update_time=GETDATE()  WHERE pur_id=@pur_id";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    tran = cn.BeginTransaction();//建立SqlConnection交易
                    cmd.CommandText = tmp;//新增
                    #region 定義參數
                    cmd.Parameters.AddWithValue("@pur_id", tmpViewData["pur_id"]);
                    cmd.Parameters.AddWithValue("@m_id", tmpViewData["m_id"]);
                    cmd.Parameters.AddWithValue("@accept", tmpViewData["accept"]);
                    cmd.Parameters.AddWithValue("@deliverydate", tmpViewData["deliverydate"]);
                    #endregion

                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法

                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }

            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }

        internal void UpdateAuthGroup(String view, String raid)
        {
            #region 執行SQL語法-修改進貨單資料
            string tmp = "Update roles_auth set viewmode='" + view + "'  WHERE ra_id='" + raid + "'";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    tran = cn.BeginTransaction();//建立SqlConnection交易
                    cmd.CommandText = tmp;//新增

                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法

                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }

            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }
        internal void UpdatePurchasesInfo(String price, String qty, String purinid)
        {
            #region 執行SQL語法-修改進貨單資料
            string tmp = "Update purchases_info set purin_price='" + price + "',purin_qty='" + qty + "'  WHERE purin_id='" + purinid + "'";//利用參數方式寫SQL語法
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                SqlConnectionStringBuilder cb = ConnectionAzure();
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();//開啟資料庫
                    tran = cn.BeginTransaction();//建立SqlConnection交易
                    cmd.CommandText = tmp;//新增

                    cmd.Connection = cn;//指定連線物件
                    cmd.Transaction = tran;//建立SqlConnection交易
                    cmd.ExecuteNonQuery();//執行SQL語法

                    cmd.Transaction.Commit();//確認交易 這時才會在資料庫中產生資料
                    cn.Close();
                }

            }
            catch (Exception)
            {
                cmd.Transaction.Rollback();
            }

            #endregion
        }


    }
}