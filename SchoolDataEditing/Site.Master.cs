using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolDataEditing
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NameDes"] == null)
                {
                    Response.Redirect("frmLogin.aspx");
                }
            else
            {
                nameDes.Text = Session["NameDes"].ToString();
                nameDese.Text = Session["NameDes"].ToString();
            }
           
        }
    }
}