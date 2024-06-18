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
                    getDistrictNameSession();
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
        public void getDistrictNameSession()
        {
            if (Session["districtId"].ToString() == "0")
            {
                Session["districtName"] = "";
            }
            else if (Session["districtId"].ToString() == "2401")
            {
                Session["districtName"] = "KACHCHH";
            }
            else if (Session["districtId"].ToString() == "2402")
            {
                Session["districtName"] = "BANASKANTHA";
            }
            else if (Session["districtId"].ToString() == "2403")
            {
                Session["districtName"] = "PATAN";
            }
            else if (Session["districtId"].ToString() == "2404")
            {
                Session["districtName"] = "MAHESANA";

            }
            else if (Session["districtId"].ToString() == "2405")
            {
                Session["districtName"] = "SABAR KANTHA";

            }
            else if (Session["districtId"].ToString() == "2406")
            {
                Session["districtName"] = "GANDHINAGAR";

            }
            else if (Session["districtId"].ToString() == "2407")
            {
                Session["districtName"] = "AHMEDABAD";

            }
            else if (Session["districtId"].ToString() == "2408")
            {
                Session["districtName"] = "SURENDRANAGAR";

            }
            else if (Session["districtId"].ToString() == "2409")
            {
                Session["districtName"] = "RAJKOT";

            }
            else if (Session["districtId"].ToString() == "2410")
            {
                Session["districtName"] = "JAMNAGAR";

            }
            else if (Session["districtId"].ToString() == "2411")
            {
                Session["districtName"] = "PORBANDAR";

            }
            else if (Session["districtId"].ToString() == "2412")
            {
                Session["districtName"] = "JUNAGADH";

            }
            else if (Session["districtId"].ToString() == "2413")
            {
                Session["districtName"] = "AMRELI";

            }
            else if (Session["districtId"].ToString() == "2414")
            {
                Session["districtName"] = "BHAVNAGAR";

            }
            else if (Session["districtId"].ToString() == "2415")
            {
                Session["districtName"] = "ANAND";

            }
            else if (Session["districtId"].ToString() == "2416")
            {
                Session["districtName"] = "KHEDA";

            }
            else if (Session["districtId"].ToString() == "2417")
            {
                Session["districtName"] = "PANCH MAHALS";

            }
            else if (Session["districtId"].ToString() == "2418")
            {
                Session["districtName"] = "DOHAD";

            }
            else if (Session["districtId"].ToString() == "2419")
            {
                Session["districtName"] = "VADODARA";
            }
            else if (Session["districtId"].ToString() == "2420")
            {
                Session["districtName"] = "NARMADA";
            }
            else if (Session["districtId"].ToString() == "2421")
            {
                Session["districtName"] = "BHARUCH";
            }
            else if (Session["districtId"].ToString() == "2422")
            {
                Session["districtName"] = "SURAT";

            }
            else if (Session["districtId"].ToString() == "2423")
            {
                Session["districtName"] = "THE DANGS";
            }
            else if (Session["districtId"].ToString() == "2424")
            {
                Session["districtName"] = "NAVSARI";
            }
            else if (Session["districtId"].ToString() == "2425")
            {
                Session["districtName"] = "VALSAD";
            }
            else if (Session["districtId"].ToString() == "2426")
            {
                Session["districtName"] = "TAPI";
            }
            else if (Session["districtId"].ToString() == "2427")
            {
                Session["districtName"] = "ARAVALLI";
            }
            else if (Session["districtId"].ToString() == "2428")
            {
                Session["districtName"] = "BOTAD";
            }
            else if (Session["districtId"].ToString() == "2429")
            {
                Session["districtName"] = "DEVBHOOMI DWARKA";
            }
            else if (Session["districtId"].ToString() == "2430")
            {
                Session["districtName"] = "GIR SOMNATH";
            }
            else if (Session["districtId"].ToString() == "2431")
            {
                Session["districtName"] = "MAHISAGAR";
            }
            else if (Session["districtId"].ToString() == "2432")
            {
                Session["districtName"] = "CHHOTAUDEPUR";
            }
            else if (Session["districtId"].ToString() == "2433")
            {
                Session["districtName"] = "MORBI";
            }
            else
            {
                Session["districtName"] = "";
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