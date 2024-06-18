using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolDataEditing
{
    public partial class frmStudentEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    //submitBtn.Enabled = false;
                    //BindGrid();

                    string AadharUID = Request.QueryString["AadharUID"];
                    if (!string.IsNullOrEmpty(AadharUID))
                    {
                        LoadStudentsData(AadharUID);
                        hfUploadedFilePathBanks.Value = "";
                        hfUploadedFilePathCons.Value = "";
                    }

                    //to hide extra dropdown questions
                    //divQuestion3Part2Optional1.Style["display"] = "none";
                    //divQuestion3Part2Optional3.Style["display"] = "none";
                    //divConsentLetterSection.Style["display"] = "none";
                    //old2NewDISE.Style["display"] = "none";
                    //divBankStatementSection.Style["display"] = "none";
                }
            }
            catch (Exception ex)
            {
                // Handle exception (logging, user feedback, etc.)
            }
        }

        private void LoadStudentsData(string AadharUID)
        {
            try
            {
                clsMasterActivity Master = new clsMasterActivity();
                Master.AadharUID = AadharUID;
                DataTable dtresult = Master.getStudentByAadhar();
                if (dtresult.Rows.Count > 0)
                {
                    DataRow row = dtresult.Rows[0];

                    // Populate form fields

                    txtChildUid.Text = row["AadharUID"].ToString();
                    txtChildName.Text = row["StudentName"].ToString();
                    txtGender.Text = row["Gender"].ToString();
                    txtMobile.Text = row["MobileNo"].ToString();
                    txtDiseCode.Text = row["SchoolDIESCode"].ToString();
                    hfDiseCode.Value = row["SchoolDIESCode"].ToString();
                    txtSchoolName.Text = row["SchoolName"].ToString();
                    hfSchoolName.Value = row["SchoolName"].ToString();
                    txtDistrictName.Text = row["DistrictName"].ToString();
                    hfSchoolDistrict.Value = row["DistrictName"].ToString();
                    txtBlock.Text = row["BlockName"].ToString();
                    hfSchoolBlock.Value = row["BlockName"].ToString();
                    txtSchoolType.Text = row["SchoolTypeName"].ToString();
                    hfSchoolType.Value = row["SchoolTypeName"].ToString();
                    //txtIsRTE.Text = row["RTE"].ToString();
                    //hfIsRTE.Value = row["RTE"].ToString();
                    txtStudentsAccountNumber.Text = row["RefTableBankAccountNo"].ToString();
                    txtBankName.Text = row["RefTableBankName"].ToString();
                    txtIFSC.Text = row["RefTableIFSC"].ToString();
                    txtHolderName.Text = row["RefTableBenificiaryName"].ToString();
                    txtCreditedOn.Text = row["RefTableCreditedOn"].ToString();
                    txtLastAmount.Text = row["RefTableAmount"].ToString();
                    if (row["BankAccountRelation"].ToString() == "1")
                    {
                        txtAccountType.Text = "SELF";
                    }
                    else if (row["BankAccountRelation"].ToString() == "2")
                    {
                        txtAccountType.Text = "MOTHER";
                    }
                    else if (row["BankAccountRelation"].ToString() == "3")
                    {
                        txtAccountType.Text = "FATHER";
                    }
                    else if (row["BankAccountRelation"].ToString() == "4")
                    {
                        txtAccountType.Text = "GUARDIAN";
                    }
                    drpQuestion3Part1.SelectedValue = row["isContinuingSameSchool"].ToString();
                    if (row["isContinuingSameSchool"].ToString() == "No")
                    {                        
                        divQuestion3Part2Optional1.Style["display"] = "flex";
                        studyingInRegisteredSchool.SelectedValue = row["isRegSchool2024"].ToString();
                        if(row["isRegSchool2024"].ToString()== "Yes")
                        {
                            old2NewDISE.Style["display"] = "flex";
                            newDISECode.Text = row["SchoolDIESCode"].ToString();
                            divConsentLetterSection.Style["display"] = "flex";
                            imgPreview.Style["display"] = "flex";
                            imgPreview.Src = row["consentLetterPath"].ToString().Replace("\\", "/");
                        }
                        else if (row["isRegSchool2024"].ToString()== "No")
                        {

                            divQuestion3Part2Optional3.Style["display"] = "flex";
                            reasonForLeaving.SelectedValue = row["reasonForLeaving"].ToString();
                        }
                    }
                    twoInstallments.SelectedValue = row["isReceived2Installments"].ToString();
                    if (row["isReceived2Installments"].ToString() == "No")
                    {
                        divBankStatementSection.Style["display"] = "flex";
                        imgPreview1.Style["display"] = "flex";
                        imgPreview1.ImageUrl = ResolveUrl(row["bankStatementPath"].ToString());
                    }
                    eightyPercentAttend.SelectedValue = row["is80PercentAttendance"].ToString();
                    
                    //LoadSchoolGrid(schooltxtDiseCode);
                }
            }
            catch (Exception ex)
            {
                // Handle exception (logging, user feedback, etc.)
            }
        }
        //protected void btnDiseSearch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string districtId = Session["districtId"].ToString();

        //        clsMasterActivity Master = new clsMasterActivity();
        //        Master.SchoolId = Convert.ToDouble(txtDiseCode.Text);
        //        DataTable dtresult = Master.getDeletedSchoolsByUDIS();
        //        if (dtresult.Rows.Count > 0)
        //        {


        //            DataRow row = dtresult.Rows[0];

        //            try
        //            {
        //                txtDiseCode.Text = row["schoolid"].ToString();
        //                txtDistrictName.Text = row["District"].ToString();
        //                txtSchoolName.Text = row["School"].ToString();
        //                txtSchoolType.Text = row["SchoolType"].ToString();
        //                txtBlock.Text = row["block"].ToString();
        //                //schoolAddress.Text = row["SchoolAddress"].ToString();
        //                txtSchoolType.Text = row["Management"].ToString();
        //                //submitBtn.Enabled = true;
        //                //LoadSchoolGrid(txtDiseCode.Text);
        //            }
        //            catch (Exception)
        //            {
        //                // Handle exception
        //            }

        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('તમે દાખલ કરેલ ડાયસ ધરાવતી શાળા અસ્તિત્વમાં નથી. ..!');", true);
        //            txtDiseCode.Text = "";
        //            txtDiseCode.Focus();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exception (logging, user feedback, etc.)
        //    }
        //}
        //public void onSelectedQues(string AadharUID)
        //{
        //    try
        //    {
        //        clsMasterActivity clsMA = new clsMasterActivity();
        //        clsMA.AadharUID = AadharUID;
        //        DataTable dtRes = clsMA.updateOnQuestionSelection();
        //        if(dtRes.Rows.Count > 0)
        //        {
        //            DataRow dr = dtRes.Rows[0];
        //        }
        //    }
        //}

        //New function for Updating data based on Selection of Question 1,2,3
        protected void btnOnSelectedQues(object sender, EventArgs e)
        {
            if (drpQuestion3Part1.SelectedValue == "" || eightyPercentAttend.SelectedValue == "" || twoInstallments.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select All Detail`s Answer...!');", true);
            }
            else if (twoInstallments.SelectedValue == "No" && fuBankStatement.FileName == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Upload Required Documents...!');", true);
            }
            else if (studyingInRegisteredSchool.SelectedValue == "Yes" && fuConsentLetter.FileName == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Upload Required Documents...!');", true);
            }
            else if(drpQuestion3Part1.SelectedValue=="No" && studyingInRegisteredSchool.SelectedValue=="")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select a Valid Option...!');", true);
            }
            else if (studyingInRegisteredSchool.SelectedValue == "Yes" && newDISECode.Text=="")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter a Valid DIES Code...!');", true);
            }
            else
            {

                if (!isValidExtension() && fuBankStatement.FileName != "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Upload Document of Valid Extension...!');", true);
                }
                if (!isCLValidExtension() && fuConsentLetter.FileName != "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Upload Document of Valid Extension...!');", true);
                }
                else
                {
                    updateFinalData();
                    string script = "alert('Record Saved Successfully..!'); window.location='frmStudentList.aspx';";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
                }
            }
        }

        public bool isValidExtension()
        {
            bool isValid = false;
            string extension = System.IO.Path.GetExtension(fuBankStatement.FileName);
            if (fuBankStatement.FileName.ToString() != "" && (extension == ".jpeg" || extension == ".png" || extension == ".jpg" || extension == ".pdf"))
            {
                isValid = true;
            }
            return isValid;
        }
        public void updateFinalData()
        {
            try
            {
                string isDistrictTransfer = "No";
                if (studyingInRegisteredSchool.SelectedValue.ToString() == "Yes")
                {
                    if (hfDiseCode.Value.Substring(0, 4).ToString() == newDISECode.Text.Substring(0, 4).ToString())
                    {
                        isDistrictTransfer = "No";
                    }
                    else
                    {
                        isDistrictTransfer = "Yes";
                    }
                }
                string ext = System.IO.Path.GetExtension(fuConsentLetter.FileName);
                string clPath = Path.Combine(Server.MapPath("~/ConsentLetters"), "ConsentLetter_" + txtChildUid.Text.ToString() + ext.ToString());
                fuConsentLetter.SaveAs(clPath);
                string extension = System.IO.Path.GetExtension(fuBankStatement.FileName);
                string path = Path.Combine(Server.MapPath("~/BankStatement") , "BankStatement_" + txtChildUid.Text.ToString() + extension.ToString());
                fuBankStatement.SaveAs(path);
                clsMasterActivity clsMA = new clsMasterActivity();
                clsMA.BankStatementPath = "~\\BankStatement\\BankStatement_" + txtChildUid.Text.ToString() + extension.ToString();
                clsMA.ConsentPath = "~\\ConsentLetters\\ConsentLetter_" + txtChildUid.Text.ToString() + extension.ToString();
                clsMA.AadharUID = txtChildUid.Text;
                clsMA.isContinuingSameSchool = drpQuestion3Part1.SelectedValue.ToString();
                clsMA.isRegSchool2024 = studyingInRegisteredSchool.SelectedValue.ToString();
                clsMA.reasonForLeaving = reasonForLeaving.SelectedValue.ToString();
                clsMA.is80PercentAttendance = eightyPercentAttend.SelectedValue.ToString();
                clsMA.isReceived2Installments = twoInstallments.SelectedValue.ToString();
                clsMA.newDISECode = txtDiseCode.Text.ToString();
                clsMA.SchoolName = txtSchoolName.Text.ToString();
                clsMA.district = txtDistrictName.Text.ToString();
                clsMA.block = txtBlock.Text.ToString();
                clsMA.SchoolManagement = txtSchoolType.Text.ToString();
                clsMA.isDistrictTransfer = isDistrictTransfer.ToString();
                clsMA.oldSchoolTypeName = hfSchoolType.Value.ToString();
                clsMA.oldSchoolName = hfSchoolName.Value.ToString();
                clsMA.oldSchoolDISECode = hfDiseCode.Value.ToString();
                clsMA.oldDistrictName = hfSchoolDistrict.Value.ToString();
                clsMA.oldBlockName = hfSchoolBlock.Value.ToString();
                clsMA.updateOnQuestionSelection();

            }
            catch (Exception)
            {

                throw;
            }
           

        }



        //To Hide the dropdown fields based on selection of DEO
        protected void sameSchoolSelectionChange(object sender, EventArgs e)
        {
            try
            {
                if (drpQuestion3Part1.SelectedValue == "No")
                {

                    divQuestion3Part2Optional1.Style["display"] = "flex";
                    studyingInRegisteredSchool.SelectedIndex = 0;
                    reasonForLeaving.SelectedIndex = 0;
                    restoreSchoolItem();
                }
                else
                {
                    divConsentLetterSection.Style["display"] = "none";
                    studyingInRegisteredSchool.SelectedIndex = 0;
                    reasonForLeaving.SelectedIndex = 0;
                    divQuestion3Part2Optional1.Style["display"] = "none";
                    divQuestion3Part2Optional3.Style["display"] = "none";
                    old2NewDISE.Style["display"] = "none";
                    restoreSchoolItem();
                }

            }
            catch { }
        }

        protected void regSchoolSelectionChange(object sender, EventArgs e)
        {
            try
            {
                if (studyingInRegisteredSchool.SelectedValue == "Yes")
                {
                    old2NewDISE.Style["display"] = "flex";
                    divQuestion3Part2Optional3.Style["display"] = "none";
                    divConsentLetterSection.Style["display"] = "flex";
                    clearSchoolItem();

                }
                else if (studyingInRegisteredSchool.SelectedValue == "No")
                {
                    //clearSchoolItem();
                    old2NewDISE.Style["display"] = "none";
                    divConsentLetterSection.Style["display"] = "none";
                    divQuestion3Part2Optional3.Style["display"] = "flex";
                }
                else
                {
                    old2NewDISE.Style["display"] = "none";
                    divConsentLetterSection.Style["display"] = "none";
                    divQuestion3Part2Optional3.Style["display"] = "none";
                    restoreSchoolItem();
                }
            }
            catch { }
        }

        public void clearSchoolItem()
        {
            txtDiseCode.Text = "";
            txtSchoolName.Text = "";
            txtSchoolType.Text = "";
            //txtIsRTE.Text = "";
            txtBlock.Text = "";
            txtDistrictName.Text = "";
        }
        public void restoreSchoolItem()
        {
            txtDiseCode.Text = hfDiseCode.Value;
            txtSchoolName.Text = hfSchoolName.Value;
            txtSchoolType.Text = hfSchoolType.Value;
            //txtIsRTE.Text = hfIsRTE.Value;
            txtBlock.Text = hfSchoolBlock.Value;
            txtDistrictName.Text = hfSchoolDistrict.Value;
        }

        protected void btnSearchForNewSchool(object sender, EventArgs e)
        {
            try
            {
                if (newDISECode.Text == hfDiseCode.Value.ToString())
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('આ શાળાની વિગત આપે પહેલાથી દાખલ કરેલી છે. ...!');", true);
                    return;
                }
                clsMasterActivity clsMA = new clsMasterActivity();
                clsMA.newDISECode = newDISECode.Text;
                DataTable dtRes = clsMA.getSchoolByNewDISE();
                if (dtRes.Rows.Count > 0)
                {
                    DataRow dtr = dtRes.Rows[0];
                    txtDiseCode.Text = dtr["SchoolId"].ToString();
                    txtSchoolName.Text = dtr["School"].ToString();
                    txtDistrictName.Text = dtr["District"].ToString();
                    txtBlock.Text = dtr["Block"].ToString();
                    txtSchoolType.Text = dtr["Management"].ToString();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('આપે દાખલ કરેલ ડાયસ કોડ ધરાવતી શાળા DEO દ્વારા એમ્પેનલ મોડ્યુલ માં એડ કરેલ નથી...!');", true);
                }

            }
            catch { }
        }
        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            try
            {
                clsMasterActivity clsMA = new clsMasterActivity();
                clsMA.AadharUID = txtChildUid.Text;
                DataTable dtRes = clsMA.updateDispute();
                string script = "alert('Student Record has been added to disputed..!'); window.location='frmStudentList.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);

            }
            catch { }
        }
        protected void twoInstallments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (twoInstallments.SelectedValue == "" || twoInstallments.SelectedValue == "Yes")
            {
                divBankStatementSection.Style["display"] = "none";
            }
            else
            {
                divBankStatementSection.Style["display"] = "flex";
                string fileName = Path.GetFileName(fuBankStatement.FileName);
                string filePath = Server.MapPath("~/Uploads/") + fileName;
                fuBankStatement.SaveAs(filePath);

                imgPreview1.Visible = true;
                imgPreview1.ImageUrl = "~/Uploads/" + fileName;
            }
        }

        public bool isCLValidExtension()
        {
            bool isValid = false;
            //Method 1 to get the extension of a file
            //FileInfo fi = new FileInfo(fuBankStatement.FileName);
            //string ext = fi.Extension;
            //method 2 to get the extension of a file
            string extension = System.IO.Path.GetExtension(fuConsentLetter.FileName);
            if (fuConsentLetter.FileName.ToString() != "" && (extension == ".jpeg" || extension == ".png" || extension == ".jpg" || extension == ".pdf"))
            {
                isValid = true;
            }
            return isValid;
        }

    }
}