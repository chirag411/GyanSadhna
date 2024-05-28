using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolDataEditing
{
    public partial class _Default : Page
    {
        public string criteria = "SELECT * FROM allocationMaster WHERE 1=1 ";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["districtId"] == null)
            {
                Response.Redirect("frmLogin.aspx");
            }
            else
            {
                ddlDistrict.SelectedValue = Session["districtId"].ToString();
            }
            if (Session["districtId"].ToString() != "0")
            {
                ddlDistrict.Enabled = false;
            }
            if (!Page.IsPostBack)
            {
                ShowData();
                GridView1.PageIndex = 0;
                getCount();
            }
        }
        public void getCount()
        {
            clsMasterActivity master = new clsMasterActivity
            {
                DistrictId = Convert.ToInt32(ddlDistrict.SelectedItem.Value)
            };

            DataSet dtResult = master.getCount();

            if (dtResult.Tables.Count > 0)
            {
                lblTotal.Text = dtResult.Tables[0].Rows[0][0].ToString();
                lblCompleted.Text = dtResult.Tables[1].Rows[0][0].ToString();
                lblPending.Text = dtResult.Tables[2].Rows[0][0].ToString();
                lblDeleted.Text = dtResult.Tables[3].Rows[0][0].ToString();
            }
            else
            {
                lblTotal.Text = "-";
                lblCompleted.Text = "-";
                lblPending.Text = "-";
                lblDeleted.Text = "-";
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
            master.Status = ddlstatus.SelectedItem.Value;
            master.Board = ddlBoard.SelectedItem.Value;
            master.SchoolManagement = ddlType.SelectedItem.Value;

            DataTable dtResult = master.getSchoolsByDistrictFront();

            if (e.CommandName == "Search")
            {
                string schoolUDISECode = ((TextBox)GridView1.HeaderRow.FindControl("txtSearchSchoolUDISECode")).Text;
                //DataTable dt = GetData();
                DataView dv = dtResult.AsDataView();
                dv.RowFilter = $"Convert(SchoolUDISECode, 'System.String') LIKE '%{schoolUDISECode}%'";

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

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridView1.EditIndex = -1;
            FindSchools();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            FindSchools();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }

        protected void btnFind_OnClick(object sender, EventArgs e)
        {
            FindSchools();
            getCount();
        }

        public void FindSchools(string sortExpression = null)
        {
            try
            {
                
                clsMasterActivity master = new clsMasterActivity
                {
                    DistrictId = Convert.ToInt32(ddlDistrict.SelectedItem.Value)
                    
                };
                master.Status = ddlstatus.SelectedItem.Value;
                master.Board = ddlBoard.SelectedItem.Value;
                master.SchoolManagement = ddlType.SelectedItem.Value;

                DataTable dtResult = master.getSchoolsByDistrictFront();

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
            getCount();
        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void ExportToExcel()
        {
            try
            {
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
            { clsMasterActivity master = new clsMasterActivity
                {
                    DistrictId = Convert.ToInt32(ddlDistrict.SelectedItem.Value)
                    
                };
                master.Status = ddlstatus.SelectedItem.Value;
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

