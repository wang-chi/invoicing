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
        public object ConnectionAzure()
        {
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "nutc106db.database.windows.net";
            cb.UserID = "nutc03";
            cb.Password = "NUTCia03";
            cb.InitialCatalog = "invoicing";
            return cb;
        }

        public string DB_Cnstr { get; set; }
        public void Insert(string p)
        {
            #region 執行SQL語法-新增員工/群組
            //SqlConnection cn = new SqlConnection(DB_Cnstr);
            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "nutc106db.database.windows.net";
                cb.UserID = "nutc03";
                cb.Password = "NUTCia03";
                cb.InitialCatalog = "invoicing";
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
            /*
            finally
            {
                if (cn.State.Equals(ConnectionState.Open))
                {
                    cn.Close();
                }
            }
            */
            #endregion
        }

        public DataSet Getid(string p)
        {
            #region 檢測帳號是否重複
            //SqlConnection cn = new SqlConnection(DB_Cnstr);
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
        public DataSet Getgroupid(string p)
        {
            #region 檢測群組帳號是否重複
            //SqlConnection cn = new SqlConnection(DB_Cnstr);
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


        public DataSet check_id_pwd(string p1)
        {
            #region 驗證帳號及密碼        
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
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
                    cmd.CommandText = p1;
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

        internal DataSet GetPosition(string p2)
        {
            #region 分辨身分是否停權
            DataSet ds = new DataSet();
            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "nutc106db.database.windows.net";
                cb.UserID = "nutc03";
                cb.Password = "NUTCia03";
                cb.InitialCatalog = "invoicing";
                SqlCommand cmd = new SqlCommand();

                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    cmd.CommandText = p2;
                    cmd.Connection = cn;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(ds, "position");
                    cn.Close();
                }

            }
            catch
            {
                return null;
            }
            /*
            finally
            {
                if (cn.State.Equals(ConnectionState.Open))
                    cn.Close();//斷線
            }
            */
            return ds;
            #endregion
        }

        internal DataSet Getinfo()
        {
            #region 個人資料查詢


            //SqlConnection cn = new SqlConnection(DB_Cnstr);
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "nutc106db.database.windows.net";
            cb.UserID = "nutc03";
            cb.Password = "NUTCia03";
            cb.InitialCatalog = "invoicing";
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

        internal DataSet Getinfo_group()
        {
            #region 群組資料查詢


            //SqlConnection cn = new SqlConnection(DB_Cnstr);
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "nutc106db.database.windows.net";
            cb.UserID = "nutc03";
            cb.Password = "NUTCia03";
            cb.InitialCatalog = "invoicing";
            //SqlCommand cmd = new SqlCommand();
            try
            {
                using (var cn = new SqlConnection(cb.ConnectionString))
                {
                    cn.Open();
                    cmd.CommandText = "SELECT * FROM rolegroup";//
                                                                //設定SQL的語法(I->新增S->修改U->查詢D->刪除)(ISUD=CRUD)
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

        /*internal DataSet Getsearch(Dictionary<string, object> tmpFilter)
        {
            #region 執行SQL語法-全部查詢

            String tmpSql = "Select house_guid,house_city,house_area,house_title,house_rent,house_address,image From House_detail Where 1=1 ";
            foreach (string tmpkey in tmpFilter.Keys)//每一個有加入KEY的查詢
            {
                //把每一個加入的key值加入到SQL語法中,利用參數式的資料查詢與法  
                if (tmpkey == "house_title")
                {
                    tmpSql += " And " + tmpkey + " Like @" + tmpkey;//模糊查詢
                }
                else
                {
                    tmpSql += " And " + tmpkey + "=@" + tmpkey;
                }

            }
            SqlConnection cn = new SqlConnection(DB_Cnstr);
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {

                cn.Open();//開啟資料庫

                cmd.CommandText = tmpSql;
                foreach (string tmpkey in tmpFilter.Keys)
                {
                    //定義key的參數,把每一個key找出來並定義參數 
                    if (tmpkey == "house_title")
                    {
                        cmd.Parameters.AddWithValue("@" + tmpkey, "%" + tmpFilter[tmpkey] + "%");//模糊查詢
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@" + tmpkey, tmpFilter[tmpkey]);
                    }

                }
                cmd.Connection = cn;//指定連線物件

                SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                dr.Fill(ds, "Search");//在DataSet中查詢,為DataSet中的資料表重新命名

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
        }*/

        internal DataSet Getgroup(String p)
        {
            #region 執行SQL語法-顯示群組資料

            String tmpSql = "Select r_id, r_name From roles" + p;

            //SqlConnection cn = new SqlConnection(DB_Cnstr);
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "nutc106db.database.windows.net";
            cb.UserID = "nutc03";
            cb.Password = "NUTCia03";
            cb.InitialCatalog = "invoicing";
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

        internal DataSet Getauth()
        {
            #region 執行SQL語法-顯示權限資料

            String tmpSql = "Select * From auth";

            SqlConnection cn = new SqlConnection(DB_Cnstr);
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {

                cn.Open();//開啟資料庫

                cmd.CommandText = tmpSql;

                cmd.Connection = cn;//指定連線物件

                SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                dr.Fill(ds, "authgroup");//在DataSet中查詢,為DataSet中的資料表重新命名

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

        internal DataSet Getmember(String p)
        {
            #region 執行SQL語法-顯示帳號資料

            String tmpSql = "SELECT * FROM member" + p;

            //SqlConnection cn = new SqlConnection(DB_Cnstr);
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "nutc106db.database.windows.net";
            cb.UserID = "nutc03";
            cb.Password = "NUTCia03";
            cb.InitialCatalog = "invoicing";
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

        internal DataSet Getmember_info(string p)
        {
            #region 查詢member資料


            string tmp = "Select * From member Where m_id=@m_id";
            SqlConnection cn = new SqlConnection(DB_Cnstr);
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {

                cn.Open();//開啟資料庫
                cmd.CommandText = tmp;//
                cmd.Parameters.AddWithValue("@m_id", p);//定義參數
                cmd.Connection = cn;//指定連線物件

                SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                dr.Fill(ds, "member_info");//在DataSet中查詢,為DataSet中的資料表重新命名

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

        internal DataSet Getgroup_info(string p)
        {
            #region 查詢group資料


            string tmp = "Select * From roles Where r_id=@r_id";
            SqlConnection cn = new SqlConnection(DB_Cnstr);
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {

                cn.Open();//開啟資料庫
                cmd.CommandText = tmp;//
                cmd.Parameters.AddWithValue("@r_id", p);//定義參數
                cmd.Connection = cn;//指定連線物件

                SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                dr.Fill(ds, "group_info");//在DataSet中查詢,為DataSet中的資料表重新命名

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
            SqlConnection cn = new SqlConnection(DB_Cnstr);
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

        internal void UpDatememberData(String member_position, String m_id)
        {
            #region 執行SQL語法-修改員工資料(停權與否)
            string tmp = "Update member set m_position='" + member_position + "'  Where m_id='" + m_id + "'";//利用參數方式寫SQL語法
            SqlConnection cn = new SqlConnection(DB_Cnstr);
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {

                cn.Open();//開啟資料庫


                tran = cn.BeginTransaction();//建立SqlConnection交易

                cmd.CommandText = tmp;//新增

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

        internal void Deletegroup(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-刪除群組資料
            string tmp = @"Delete  From roles Where r_id=@r_id";//利用參數方式寫SQL語法
            SqlConnection cn = new SqlConnection(DB_Cnstr);
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
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

        internal DataSet Getmemberall(string s_id, string s_name)
        {
            #region 執行SQL語法-顯示資料


            String tmpSql = "Select member_guid,member_id,member_pwd,member_name,member_email From Member_Info Where 1=1  AND member_id LIKE '%" + s_id + "%' AND  member_name LIKE'%" + s_name + "%'";


            SqlConnection cn = new SqlConnection(DB_Cnstr);
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {

                cn.Open();//開啟資料庫

                cmd.CommandText = tmpSql;

                cmd.Connection = cn;//指定連線物件

                SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                dr.Fill(ds, "member_all");//在DataSet中查詢,為DataSet中的資料表重新命名

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

        internal DataSet GetMemberData(string p)
        {
            #region 修改/刪除會員


            string tmp = "Select * From Member_Info Where member_guid=@member_guid";
            SqlConnection cn = new SqlConnection(DB_Cnstr);
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
            string tmp = @"Update Member_Info set member_name=@member_name, member_email=@member_email  Where member_guid=@member_guid";//利用參數方式寫SQL語法
            SqlConnection cn = new SqlConnection(DB_Cnstr);
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

        internal void DeleteMemberData(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-刪除會員
            string tmp = @"Delete  From Member_Info Where member_guid=@member_guid";//利用參數方式寫SQL語法
            SqlConnection cn = new SqlConnection(DB_Cnstr);
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

        internal DataSet GetMemberDetail(string p)
        {
            #region 房東姓名及聯絡方式


            string tmp = "Select Member_Info.*,House_detail.house_guid,House_detail.member_guid From Member_Info,House_detail Where House_detail.house_guid=@house_guid AND Member_Info.member_guid=House_detail.member_guid";
            SqlConnection cn = new SqlConnection(DB_Cnstr);
            SqlCommand cmd = new SqlCommand();//新增cmd的物件
            DataSet ds = new DataSet();

            try
            {

                cn.Open();//開啟資料庫
                cmd.CommandText = tmp;//
                cmd.Parameters.AddWithValue("@house_guid", p);//定義參數
                cmd.Connection = cn;//指定連線物件

                SqlDataAdapter dr = new SqlDataAdapter(cmd);//DataAdapter中有Fill的方法可以查詢資料表

                dr.Fill(ds, "MemberDetail");//在DataSet中查詢,為DataSet中的資料表重新命名

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

        internal void UpDategroup(Dictionary<string, object> tmpViewData)
        {
            #region 執行SQL語法-修改資料
            string tmp = "Update roles set r_name=@r_name,r_info=@r_info,update_time= GETDATE()  Where r_id=@r_id";//利用參數方式寫SQL語法
            SqlConnection cn = new SqlConnection(DB_Cnstr);
            SqlTransaction tran = null;//產生物件
            SqlCommand cmd = new SqlCommand();//新增cmd的物件

            try
            {
                cn.Open();//開啟資料庫
                tran = cn.BeginTransaction();//建立SqlConnection交易
                cmd.CommandText = tmp;//新增
                #region 定義參數
                cmd.Parameters.AddWithValue("@r_id", tmpViewData["r_id"]);
                cmd.Parameters.AddWithValue("@r_name", tmpViewData["r_name"]);
                cmd.Parameters.AddWithValue("@r_info", tmpViewData["r_info"]);
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

    }
}