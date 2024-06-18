using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolDataEditing
{
    public partial class frmGridDataShow : Page
    {
        public string criteria = "SELECT * FROM allocationMaster WHERE 1=1 ";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                GridView1.PageIndex = 0;
              
            }
        }
     
        public void ShowData()
        {
            FindSchools();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            FindSchools();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            clsMasterActivity master = new clsMasterActivity
            {
                DistrictId = Convert.ToInt32(ddlDistrict.SelectedItem.Value)

            };
            master.Status = "Completed";
            master.Board = ddlBoard.SelectedItem.Value;
            master.SchoolManagement = ddlType.SelectedItem.Value;

            DataTable dtResult = master.getSchoolsByDistrictFrontView();

            if (e.CommandName == "Search")
            {
                string schoolUDISECode = ((TextBox)GridView1.HeaderRow.FindControl("txtSearchSchoolUDISECode")).Text;
                //DataTable dt = GetData();
                DataView dv = dtResult.AsDataView();
                dv.RowFilter = $"Convert(SchoolUDISECode, 'System.String') LIKE '%{schoolUDISECode}%'";

                GridView1.DataSource = dv;
                GridView1.DataBind();
            }
            if (e.CommandName == "SearchName")
            {
                string schoolName = ((TextBox)GridView1.HeaderRow.FindControl("txtSearchSchoolName")).Text;
                //DataTable dt = GetData();
                DataView dv = dtResult.AsDataView();
                dv.RowFilter = $"Convert([School Name], 'System.String') LIKE '%{schoolName}%'";

                GridView1.DataSource = dv;
                GridView1.DataBind();
            }

            if (e.CommandName == "Edit")
            {
                string schoolUDISECode = e.CommandArgument.ToString();
                Response.Redirect("frmSchoolEditAdd.aspx?SchoolUDISECode=" + HttpUtility.UrlEncode(schoolUDISECode));
            }
            if (e.CommandName == "Delete")
            {
                // Get the SchoolUDISECode from the CommandArgument
                string schoolUDISECode = e.CommandArgument.ToString();

                // Call a method to delete the record from the database
                DeleteSchool(schoolUDISECode);

                // Rebind the GridView to reflect changes
                ShowData();
            }
        }

        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    GridView1.EditIndex = -1;
        //    FindSchools();
        //}

        //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridView1.EditIndex = -1;
        //    FindSchools();
        //}

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }

        protected void btnFind_OnClick(object sender, EventArgs e)
        {
            if (ddlBoard.SelectedValue == "" || ddlDistrict.SelectedValue == "" ||  ddlType.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select All The Fields in Grid..!');", true);
            }
            else
            {
                FindSchools();
            }
        }

        public void FindSchools(string sortExpression = null)
        {
            try
            {

                clsMasterActivity master = new clsMasterActivity
                {
                    DistrictId = Convert.ToInt32(ddlDistrict.SelectedItem.Value)

                };
                master.Status = "Completed";
                master.Board = ddlBoard.SelectedItem.Value;
                master.SchoolManagement = ddlType.SelectedItem.Value;

                DataTable dtResult = master.getSchoolsByDistrictFrontView();

                if (dtResult.Rows.Count > 0)
                {

                    if (sortExpression != null)
                    {
                        DataView dv = dtResult.AsDataView();
                        dv.Sort = sortExpression;
                        GridView1.DataSource = dv;
                    }
                    else
                    {
                        GridView1.DataSource = dtResult;
                    }
                    GridView1.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No Data Found For Particular Search..!');", true);
                    GridView1.DataSource = "";
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Display a friendly error message
                //lblErrorMessage.Text = "An error occurred while retrieving the data. Please try again later.";
            }
        }

        public void GetClusterByBlock()
        {
            try
            {
                // Implement the method to get clusters by block
            }
            catch (Exception ex)
            {
                // Log the exception
                // Display a friendly error message
                //lblErrorMessage.Text = "An error occurred while retrieving the clusters. Please try again later.";
            }
        }

        public void SearchCriteria()
        {
            if (ddlBoard.SelectedIndex != 0)
            {
                criteria += " AND District = @District";
            }
            if (ddlType.SelectedIndex != 0)
            {
                criteria += " AND Block = @Block";
            }
            if (ddlDistrict.SelectedIndex != 0)
            {
                criteria += " AND Cluster = @Cluster";
            }

            // Use the criteria in a parameterized query to avoid SQL injection
        }
        private void DeleteSchool(string schoolUDISECode)
        {
            clsMasterActivity master = new clsMasterActivity();
            master.SchoolId = Convert.ToDouble(schoolUDISECode);
            master.delSchool();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            FindSchools();
           
        }
        //protected void btnExportToExcel_Click(object sender, EventArgs e)
        //{
        //    ExportToExcel();
        //}

        private void ExportToExcel()
        {
            try
            {
                GridView1.HeaderRow.FindControl("txtSearchSchoolUDISECode").Visible = false;
                GridView1.HeaderRow.FindControl("btnSearchSchoolUDISECode").Visible = false;
                // Hide the edit and delete buttons before exporting
                HideEditDeleteButtons(true);

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=SchoolData.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridView1.AllowPaging = false; // Disable paging to export all data
                ShowDataExcel(); // Retrieve data for GridView
                GridView1.RenderControl(hw);

                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
                //GridView1.HeaderRow.FindControl("txtSearchSchoolUDISECode").Visible = true;
                //GridView1.HeaderRow.FindControl("btnSearchSchoolUDISECode").Visible = true;
            }
            catch (Exception ex)
            {
                // Handle exception
                //lblErrorMessage.Text = "An error occurred while exporting data to Excel.";
            }
            finally
            {
                // Show the edit and delete buttons after exporting
                HideEditDeleteButtons(false);
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // Required to avoid the runtime error "Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."
        }

        public void ShowDataExcel()
        {
            try
            {
                clsMasterActivity master = new clsMasterActivity
                {
                    DistrictId = Convert.ToInt32(ddlDistrict.SelectedItem.Value)

                };
                master.Status = "Completed";
                master.Board = ddlBoard.SelectedItem.Value;
                master.SchoolManagement = ddlType.SelectedItem.Value;

                DataTable dtResult = master.getSchoolsByDistrictFront();

                if (dtResult.Rows.Count > 0)
                {
                    GridView1.DataSource = dtResult;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Display a friendly error message
                //lblErrorMessage.Text = "An error occurred while retrieving the data. Please try again later.";
            }
        }

        private void HideEditDeleteButtons(bool hide)
        {

            // Hide the header column for actions
            foreach (DataControlField column in GridView1.Columns)
            {
                if (column.HeaderText == "Action")
                {
                    column.Visible = !hide;
                }

            }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            FindSchools(sortExpression);
        }



        // Other methods and event handlers...
    }
}

