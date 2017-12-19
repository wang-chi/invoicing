using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invoicing_T
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_id_manage_Click(object sender, EventArgs e)
        {
            Response.Redirect("id_manage.aspx");
        }

        protected void btn_group_manage_Click(object sender, EventArgs e)
        {
            Response.Redirect("group_manage.aspx");
        }

        protected void btn_role_manag_Click(object sender, EventArgs e)
        {
            Response.Redirect("auth_manage.aspx");
        }



    }
}