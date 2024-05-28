using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SchoolDataEditing
{
    public partial class frmLogin : System.Web.UI.Page
    {
        string usrDefaultPassword = ConfigurationManager.AppSettings["defaultPwd"];
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtUserName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter credentials..!');", true);
                return;
            }
            else
            {
                chkLogin();
            }
        }
        public void chkLogin()
        {
            try
            {

                chkPhase();

                LoginCS login = new LoginCS();
                login.userId = txtUserName.Text;
                

                    login.Password = txtPassword.Text;
                

                DataTable dtresult = new DataTable();
                dtresult = login.LoginUser();
                if (dtresult.Rows.Count > 0)
                {

                    Session["districtId"] = dtresult.Rows[0]["districtId"].ToString();
                    Session["NameDes"] = dtresult.Rows[0]["Name"].ToString() + " - " + dtresult.Rows[0]["Designation"].ToString();
                    Response.Redirect("Default.aspx");


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid credentials..!');", true);

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void chkPhase()
        {
            try
            {


                LoginCS login = new LoginCS();

                DataTable dtresult = new DataTable();
                dtresult = login.chkPhase();
                if (dtresult.Rows.Count > 0)
                {
                    Session["Phase"] = dtresult.Rows[0]["Phase"].ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}