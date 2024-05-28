using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolDataEditing
{
    public partial class frmSchoolEditAdd : System.Web.UI.Page
    {
        private List<SchoolDetail> SchoolDetails
        {
            get
            {
                if (ViewState["SchoolDetails"] == null)
                {
                    ViewState["SchoolDetails"] = new List<SchoolDetail>();
                }
                return (List<SchoolDetail>)ViewState["SchoolDetails"];
            }
            set
            {
                ViewState["SchoolDetails"] = value;
            }
        }

        private DataTable GetGridViewData()
        {
            if (ViewState["GridViewData"] == null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("SchoolCategory");
                dt.Columns.Add("SchoolIndex");
                dt.Columns.Add("SchoolMgmt");
                dt.Columns.Add("Std9FRC");
                dt.Columns.Add("Std10FRC");
                dt.Columns.Add("SchoolMedium");
                ViewState["GridViewData"] = dt;
            }
            return (DataTable)ViewState["GridViewData"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    submitBtn.Enabled = false;
                    BindGrid();

                    string schoolUDISECode = Request.QueryString["SchoolUDISECode"];
                    if (!string.IsNullOrEmpty(schoolUDISECode))
                    {
                        udiseCode.ReadOnly = true;
                        LoadSchoolData(schoolUDISECode);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (logging, user feedback, etc.)
            }
        }

        private void LoadSchoolData(string schoolUDISECode)
        {
            try
            {
                clsMasterActivity Master = new clsMasterActivity();
                Master.SchoolId = Convert.ToDouble(schoolUDISECode);
                DataTable dtresult = Master.getSchoolsByUDIS();
                if (dtresult.Rows.Count > 0)
                {
                    DataRow row = dtresult.Rows[0];

                    // Populate form fields
                    udiseCode.Text = row["schoolid"].ToString();
                    district.Text = row["District"].ToString();
                    schoolName.Text = row["School"].ToString();
                    schoolType.SelectedValue = row["SchoolBoard"].ToString();
                    taluka.Text = row["block"].ToString();
                    schoolAddress.Text = row["SchoolAddress"].ToString();
                    schoolManagement.SelectedValue = row["Management"].ToString();
                    SQue1.SelectedValue = row["Que1"].ToString();
                    SQue2.SelectedValue = row["Que2"].ToString();
                    SQue3.SelectedValue = row["Que3"].ToString();
                    LoadSchoolGrid(schoolUDISECode);
                }
            }
            catch (Exception ex)
            {
                // Handle exception (logging, user feedback, etc.)
            }
        }

        private void LoadSchoolGrid(string schoolUDISECode)
        {
            try
            {
                clsMasterActivity Master = new clsMasterActivity();
                Master.SchoolId = Convert.ToDouble(schoolUDISECode);
                DataTable dtresult = Master.getSchoolGridByUDIS();
                if (dtresult.Rows.Count > 0)
                {
                    gvSchoolDetails.Columns.Clear();
                    foreach (DataColumn column in dtresult.Columns)
                    {
                        BoundField boundField = new BoundField
                        {
                            DataField = column.ColumnName,
                            HeaderText = column.ColumnName
                        };
                        gvSchoolDetails.Columns.Add(boundField);
                    }

                    gvSchoolDetails.DataSource = dtresult;
                    gvSchoolDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Handle exception (logging, user feedback, etc.)
            }
        }

        protected void gvSchoolDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                var schoolDetails = SchoolDetails;
                schoolDetails.RemoveAt(e.RowIndex);
                SchoolDetails = schoolDetails;
                BindGrid();
            }
            catch (Exception ex)
            {
                // Handle exception (logging, user feedback, etc.)
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkAcceptTerms.Checked)
                {
                    clsMasterActivity Master = new clsMasterActivity();
                    Master.SchoolId = Convert.ToDouble(udiseCode.Text);
                    Master.delDtlsGrid();

                    string schoolUDISECode = udiseCode.Text;
                    string district1 = district.Text;
                    string schoolName1 = schoolName.Text;
                    string schoolType1 = schoolType.SelectedItem.Value;
                    string taluka1 = taluka.Text;
                    string schoolAddress1 = schoolAddress.Text;
                    string schoolManagement1 = schoolManagement.SelectedItem.Value;
                    string Que1 = SQue1.SelectedItem.Value;
                    string Que2 = SQue2.SelectedItem.Value;
                    string Que3 = SQue3.SelectedItem.Value;

                    SaveSchoolMaster(schoolUDISECode, district1, schoolName1, schoolType1, taluka1, schoolAddress1, schoolManagement1, Que1, Que2, Que3);
                    foreach (GridViewRow row in gvSchoolDetails.Rows)
                    {
                        var lblSchoolCategory = (Label)row.FindControl("SchoolCategory");
                        var lblIndexNo = (Label)row.FindControl("SchoolIndex");
                        var lblSchoolManagement = (Label)row.FindControl("SchoolMgmt");
                        var lblStd9FrcFee = (Label)row.FindControl("Std9FRC");
                        var lblStd10FrcFee = (Label)row.FindControl("Std10FRC");
                        var lblSchoolMedium = (Label)row.FindControl("SchoolMedium");

                        string schoolCategory = lblSchoolCategory.Text;
                        string indexNo = lblIndexNo.Text;
                        string gridSchoolManagement = lblSchoolManagement.Text;
                        decimal std9FrcFee = decimal.Parse(lblStd9FrcFee.Text == "" ? "0" : lblStd9FrcFee.Text);
                        decimal std10FrcFee = decimal.Parse(lblStd10FrcFee.Text == "" ? "0" : lblStd10FrcFee.Text);
                        string schoolMedium = lblSchoolMedium.Text;

                        SaveSchoolDetail(schoolUDISECode, schoolCategory, indexNo, gridSchoolManagement, std9FrcFee, std10FrcFee, schoolMedium);
                    }
                    string script = "alert('Record Saved Successfully..!'); window.location='default.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Tick Verify Checkbox..!');", true);
                }
            }
            catch (Exception ex)
            {
                // Handle exception (logging, user feedback, etc.)
            }
        }

        private void SaveSchoolMaster(string schoolUDISECode, string district, string schoolName, string schoolType, string taluka, string schoolAddress, string schoolManagement, string Que1, string Que2, string Que3)
        {
            try
            {
                clsMasterActivity Master = new clsMasterActivity();
                Master.SchoolId = Convert.ToDouble(schoolUDISECode);
                Master.district = district;
                Master.SchoolName = schoolName;
                Master.SchoolType = schoolType;
                Master.Taluka = taluka;
                Master.SchoolAddress = schoolAddress;
                Master.SchoolManagement = schoolManagement;
                Master.Que1 = Que1;
                Master.Que2 = Que2;
                Master.Que3 = Que3;
                Master.UpsertSchool();
            }
            catch (Exception ex)
            {
                // Handle exception (logging, user feedback, etc.)
            }
        }

        private void SaveSchoolDetail(string schoolId, string schoolCategory, string indexNo, string schoolManagement, decimal std9FrcFee, decimal std10FrcFee, string schoolMedium)
        {
            try
            {
                clsMasterActivity Master = new clsMasterActivity();
                Master.SchoolId = Convert.ToDouble(schoolId);
                Master.SchoolCategory = schoolCategory;
                Master.IndexNo = indexNo;
                Master.SchoolMgmt = schoolManagement;
                Master.Std9FRC = Convert.ToDouble(std9FrcFee);
                Master.Std10FRC = Convert.ToDouble(std10FrcFee);
                Master.SchoolMedium = schoolMedium;
                Master.insDtlsData();
            }
            catch (Exception ex)
            {
                // Handle exception (logging, user feedback, etc.)
            }
        }

        private void BindGrid()
        {
            try
            {
                gvSchoolDetails.DataSource = SchoolDetails;
                gvSchoolDetails.DataBind();
            }
            catch (Exception ex)
            {
                // Handle exception (logging, user feedback, etc.)
            }
        }

        [Serializable]
        public class SchoolDetail
        {
            public string SchoolCategory { get; set; }
            public string IndexNo { get; set; }
            public string SchoolManagement { get; set; }
            public string Std9FrcFee { get; set; }
            public string Std10FrcFee { get; set; }
            public string SchoolMedium { get; set; }
        }

        protected void schoolManagement_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the school management selected index change event
        }

        protected void udiseCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string districtId = Session["districtId"].ToString();

                clsMasterActivity Master = new clsMasterActivity();
                Master.SchoolId = Convert.ToDouble(udiseCode.Text);
                DataTable dtresult = Master.getDeletedSchoolsByUDIS();
                if (udiseCode.Text.Substring(0, 4) == districtId || districtId == "0")
                {
                    if (dtresult.Rows.Count > 0)
                    {
                        if (dtresult.Rows[0]["isDeleted"].ToString() == "Yes")
                        {

                        
                        DataRow row = dtresult.Rows[0];

                        try
                        {
                            udiseCode.Text = row["schoolid"].ToString();
                            district.Text = row["District"].ToString();
                            schoolName.Text = row["School"].ToString();
                            schoolType.SelectedValue = row["SchoolType"].ToString();
                            taluka.Text = row["block"].ToString();
                            schoolAddress.Text = row["SchoolAddress"].ToString();
                            schoolManagement.SelectedValue = row["Management"].ToString();
                            SQue1.SelectedValue = row["Que1"].ToString();
                            SQue2.SelectedValue = row["Que2"].ToString();
                            SQue3.SelectedValue = row["Que3"].ToString();
                            submitBtn.Enabled = true;
                            LoadSchoolGrid(udiseCode.Text);
                        }
                        catch (Exception)
                        {
                            // Handle exception
                        }
                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('તઆ શાળાની વિગત આપે પહેલાથી દાખલ કરેલી છે. ...!');", true);
                            udiseCode.Text = "";
                            udiseCode.Focus();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('તમે દાખલ કરેલ ડાયસ ધરાવતી શાળા અસ્તિત્વમાં નથી. ..!');", true);
                        udiseCode.Text = "";
                        udiseCode.Focus();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('તમે બીજા જીલ્લાની શાળા એડ કરી શકશો નહિ. ..!');", true);
                    udiseCode.Text = "";
                    udiseCode.Focus();
                }
            }
            catch (Exception ex)
            {
                // Handle exception (logging, user feedback, etc.)
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlSchoolCategory.SelectedItem.Value == "Select" || ddlSchoolManagement.SelectedValue == "Select" || ddlSchoolMedium.SelectedValue == "Select")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select All The Fields...!');", true);
            }
            else
            {
                // Get the current data from the GridView
                DataTable dt = GetGridViewData();

                // Add new row with TextBox and DropDownList values
                DataRow dr = dt.NewRow();
                dr["SchoolCategory"] = ddlSchoolCategory.SelectedItem.Value;
                dr["SchoolIndex"] = txtIndexNo.Text;
                dr["SchoolMgmt"] = ddlSchoolManagement.SelectedValue;
                dr["Std9FRC"] = txtStd9FrcFee.Text;
                dr["Std10FRC"] = txtStd10FrcFee.Text;
                dr["SchoolMedium"] = ddlSchoolMedium.SelectedValue;
                dt.Rows.Add(dr);
                submitBtn.Enabled = true;
                // Bind the updated DataTable to the GridView
                gvSchoolDetails.DataSource = dt;
                gvSchoolDetails.DataBind();

                // Reset the form fields
                ddlSchoolCategory.SelectedIndex = 0;
                txtIndexNo.Text = "";
                ddlSchoolManagement.SelectedIndex = 0;
                txtStd9FrcFee.Text = "";
                txtStd10FrcFee.Text = "";
                ddlSchoolMedium.SelectedIndex = 0;
            }
        }
    }
}
