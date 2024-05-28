using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolDataEditing
{
    public partial class frmDeletedSchools : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["districtId"] == null)
            {
                Response.Redirect("frmLogin.aspx");
            }
            
            
            if (!Page.IsPostBack)
            {
                ShowData();
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

            clsMasterActivity master = new clsMasterActivity();
            

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
          
        }

        public void FindSchools(string sortExpression = null)
        {
            try
            {
                clsMasterActivity master = new clsMasterActivity();
                master.DistrictId = Convert.ToInt32(Session["districtId"].ToString());
                DataTable dtResult = master.getSchoolsByDeleteFront();

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
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            FindSchools(sortExpression);
        }
    }
}