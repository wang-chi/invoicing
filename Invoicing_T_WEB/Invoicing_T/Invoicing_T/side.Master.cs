using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class side : System.Web.UI.MasterPage
    {
        DBHandle tmp = new DBHandle();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CheckAuth();
        }
        private void CheckAuth()
        {
            #region 確認可到訪頁面權限
            if (Session["UserID"] != null)
            {
                String UserID = Session["UserID"].ToString();
                DataSet ds = tmp.CheckAuth(UserID);
                if (ds != null)
                {
<<<<<<< HEAD
=======
                    //DataTable dt = ds.Tables["CheckAuth"];
>>>>>>> CJT
                    foreach (DataRow dr in ds.Tables["CheckAuth"].Rows)//DBHamdle中的table"allInfo"
                    {
                        //HomePage
                        if (dr["a_page"].ToString().Equals("member_manage"))
                        {
                            Boolean member_manage = false;
                            member_manage = Convert.ToBoolean(dr["viewmode"].ToString());
<<<<<<< HEAD
                            auth_member_manage.Style.Add("display", "block");
=======
                            if (member_manage)
                            {
                                auth_member_manage.Style.Add("display", "block");
                            }
                            
>>>>>>> CJT
                        }
                        if (dr["a_page"].ToString().Equals("group_manage"))
                        {
                            Boolean group_manage = false;
                            group_manage = Convert.ToBoolean(dr["viewmode"].ToString());
<<<<<<< HEAD
                            auth_group_manage.Style.Add("display", "block");
=======
                            if (group_manage)
                            {
                                auth_group_manage.Style.Add("display", "block");
                            }
>>>>>>> CJT
                        }
                        if (dr["a_page"].ToString().Equals("auth_manage"))
                        {
                            Boolean auth_manage = false;
                            auth_manage = Convert.ToBoolean(dr["viewmode"].ToString());
<<<<<<< HEAD
                            auth_auth_manage.Style.Add("display", "block");
=======
                            
                            if (auth_manage)
                            {
                                auth_auth_manage.Style.Add("display", "block");
                            }
>>>>>>> CJT
                        }
                        //ManagePage
                        if (dr["a_page"].ToString().Equals("company_manage"))
                        {
                            Boolean company_manage = false;
                            company_manage = Convert.ToBoolean(dr["viewmode"].ToString());
<<<<<<< HEAD
                            auth_company_manage.Style.Add("display", "block");
=======
                            
                            if (company_manage)
                            {
                                auth_company_manage.Style.Add("display", "block");
                            }
>>>>>>> CJT
                        }
                        if (dr["a_page"].ToString().Equals("supplier_manage"))
                        {
                            Boolean supplier_manage = false;
                            supplier_manage = Convert.ToBoolean(dr["viewmode"].ToString());
<<<<<<< HEAD
                            auth_supplier_manage.Style.Add("display", "block");
=======
                            
                            if (supplier_manage)
                            {
                                auth_supplier_manage.Style.Add("display", "block");
                            }
>>>>>>> CJT
                        }
                        if (dr["a_page"].ToString().Equals("client_manage"))
                        {
                            Boolean client_manage = false;
                            client_manage = Convert.ToBoolean(dr["viewmode"].ToString());
                            auth_client_manage.Style.Add("display", "block");
<<<<<<< HEAD
=======
                            if (client_manage)
                            {
                                auth_client_manage.Style.Add("display", "block");
                            }
                        }
                        if (dr["a_page"].ToString().Equals("product_manage"))
                        {
                            Boolean product_manage = false;
                            product_manage = Convert.ToBoolean(dr["viewmode"].ToString());
                            
                            if (product_manage)
                            {
                                auth_product_manage.Style.Add("display", "block");
                            }
                        }
                        if (dr["a_page"].ToString().Equals("product_type_manage"))
                        {
                            Boolean product_type_manage = false;
                            product_type_manage = Convert.ToBoolean(dr["viewmode"].ToString());

                            if (product_type_manage)
                            {
                                auth_product_type_manage.Style.Add("display", "block");
                            }
                        }
                        if (dr["a_page"].ToString().Equals("purchases_manage"))
                        {
                            Boolean purchases_manage = false;
                            purchases_manage = Convert.ToBoolean(dr["viewmode"].ToString());

                            if (purchases_manage)
                            {
                                auth_purchases_manage.Style.Add("display", "block");
                            }
                        }
                        if (dr["a_page"].ToString().Equals("purchases_manage"))
                        {
                            Boolean purchases_manage = false;
                            purchases_manage = Convert.ToBoolean(dr["viewmode"].ToString());

                            if (purchases_manage)
                            {
                                auth_purchases_manage.Style.Add("display", "block");
                            }
>>>>>>> CJT
                        }

                    }
                }
                else
                {
                    Response.Redirect("login.aspx");//跳轉到登入頁面
                }
                #endregion
            }
        }
    }
}