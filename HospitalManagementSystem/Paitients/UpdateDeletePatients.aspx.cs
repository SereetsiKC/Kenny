using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HospitalManagementSystem.Classes;
using System.Data.SqlClient;
using System.Data;

namespace HospitalManagementSystem.Paitients
{
    public partial class UpdateDeletePatients : System.Web.UI.Page
    {
        DBAccess db = new DBAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            loadGrid();
        }
        private void loadGrid()
        {
            string sql = string.Format(@"SELECT     PatientTB.*, ProfileTB.*
                                        FROM        PatientTB INNER JOIN
                                                              ProfileTB ON PatientTB.IDNo = ProfileTB.IDNo");

            SqlCommand cmd = new SqlCommand(sql);
            DataTable dt = db.GetData(cmd);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    datagrid.DataSource = dt;
                    datagrid.DataBind();
                }
            }
        }

        protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            datagrid.PageIndex = e.NewPageIndex;
            string sql = string.Format(@"SELECT     PatientTB.*, ProfileTB.*
                                        FROM        PatientTB INNER JOIN
                                                              ProfileTB ON PatientTB.IDNo = ProfileTB.IDNo");

            SqlCommand cmd = new SqlCommand(sql);
            DataTable dt = db.GetData(cmd);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    datagrid.DataSource = dt;
                    datagrid.DataBind();
                }
            }
        }

        protected void datagrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //string IDNo = datagrid.DataKeys[e.RowIndex + 1].Values["IDNo"].ToString();

            string IDNo = datagrid.Rows[e.RowIndex].Cells[1].Text;
            
            string sqldelete = @"DELETE FROM PatientTB
                                WHERE     (IDNo = @ID)";

            string sqldelet = @"DELETE FROM ProfileTB
                                WHERE     (IDNo = @ID)";
            try
            {
                SqlCommand cmdDel = new SqlCommand(sqldelete);
                cmdDel.Parameters.AddWithValue("@ID", IDNo);
                SqlCommand sqldell = new SqlCommand(sqldelet);
                sqldell.Parameters.AddWithValue("@ID", IDNo);


                if (db.InsertUpdateData(cmdDel) && db.InsertUpdateData(sqldell))
                {
                    Response.Write("<script typr=\"text/javascript\">alert('Process Successful!!');</script>");
                }
                else
                {
                    Response.Write("<script typr=\"text/javascript\">alert('Process Unsuccessful!!');</script>");
                }                
            }
            catch (Exception ex) 
            {
                Response.Write("<script typr=\"text/javascript\">alert('Error :" + ex.Message + "');</script>"); 
            }
            finally {
                loadGrid();
            }
        }

        protected void datagrid_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session["EDITUSER"] = datagrid.Rows[datagrid.SelectedIndex].Cells[1].Text;
            Response.Redirect("~/Paitients/EditUserProfile.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string sql = string.Format(@"SELECT     PatientTB.*, ProfileTB.*
                                        FROM         PatientTB INNER JOIN
                                                              ProfileTB ON PatientTB.IDNo = ProfileTB.IDNo
                                        WHERE     (PatientTB.IDNo = @ID)");

            SqlCommand cmd = new SqlCommand(sql);
            DataTable dt = db.GetData(cmd);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    datagrid.DataSource = dt;
                    datagrid.DataBind();
                }
            }
        }
    }
}