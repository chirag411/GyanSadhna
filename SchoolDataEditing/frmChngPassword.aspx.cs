using SchoolDataEditing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolDataEditing
{
    public partial class frmChngPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text == "" || txtNewPassword.Text == "" || txtRePassword.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter credentials..!');", true);
                return;
            }
            else if (txtNewPassword.Text != txtRePassword.Text)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter same value for new password and confirm password..!');", true);
                return;
            }
            else if (txtNewPassword.Text == ConfigurationManager.AppSettings["defaultPwd"].ToString())
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Default password not set as new password..!');", true);
                return;
            }
            else
            {
                chngPassword();
            }

        }

        public void chngPassword()
        {
            try
            {


                LoginCS login = new LoginCS();
                login.userId = Session["usrName"].ToString();
                login.Password = txtNewPassword.Text;


                DataTable dtresult = new DataTable();
                dtresult = login.ChangePassword();
                if (dtresult.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Password change sucessfully..!');", true);
                    Response.Redirect("frmLogin.aspx");

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "Something went wrong please contact admin..!');", true);

                }


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}