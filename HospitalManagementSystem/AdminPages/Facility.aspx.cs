using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HospitalManagementSystem.Classes;
using System.Data;
using System.Data.SqlClient;


namespace HospitalManagementSystem.AdminPages
{
    public partial class Facility : System.Web.UI.Page
    {
        DBAccess db = new DBAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                loadGrid();
            }
        }
        private void loadGrid()
        {
            string sql = string.Format(@"SELECT FacilityTB.*
                                        FROM FacilityTB");

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
        protected void LBClear_Click(object sender, EventArgs e)
        {
            this.txtName.Text = "";
            this.txtTel.Text = "";
            this.txtPhysicalAdr.Text = "";
            this.txtPostalAdr.Text = "";

            this.txtName.Focus();
        }

        protected void LBReg_Click(object sender, EventArgs e)
        {
            string sql = string.Format(@"INSERT INTO FacilityTB(FacilityName, Physical_Address, Postal_Address, TelNo)
                                            SELECT     @FacilityName, @Physical_Address, @Postal_Address, @TelNo");

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@FacilityName", this.txtName.Text.ToString());
            cmd.Parameters.AddWithValue("@Physical_Address", this.txtPhysicalAdr.Text.ToString());
            cmd.Parameters.AddWithValue("@Postal_Address", this.txtPostalAdr.Text.ToString());
            cmd.Parameters.AddWithValue("@TelNo", this.txtTel.Text.ToString());

            if (db.InsertUpdateData(cmd))
            {
                Response.Write("<script typr=\"text/javascript\">alert('Process Successful!!');</script>");
            }
            loadGrid();
        }

        protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            datagrid.PageIndex = e.NewPageIndex;
            string sql = string.Format(@"SELECT FacilityTB.*
                                        FROM FacilityTB");

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

        protected void datagrid_SelectedIndexChanged(object sender, EventArgs e)
        { 
            Session["fID"] = datagrid.Rows[datagrid.SelectedIndex].Cells[1].Text;
            string sql = string.Format(@"SELECT     FacilityID, FacilityName, Physical_Address, Postal_Address, TelNo
                                            FROM         FacilityTB
                                            WHERE     (FacilityID = @ID)");

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@ID", Session["fID"].ToString());

            DataTable dt = db.GetData(cmd);

            if (dt.Rows.Count >= 1) {
                foreach (DataRow row in dt.Rows) {
                    this.txtName.Text = row["FacilityName"].ToString();
                    this.txtPhysicalAdr.Text = row["Physical_Address"].ToString();
                    this.txtPostalAdr.Text = row["Postal_Address"].ToString();
                    this.txtTel.Text = row["TelNo"].ToString();
                }
            }
        }

        protected void datagrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string fID = datagrid.Rows[e.RowIndex].Cells[1].Text;
            string sqldelete = @"DELETE FROM FacilityTB
                                WHERE     (FacilityID = @ID)";
            try
            {
                SqlCommand cmdDel = new SqlCommand(sqldelete);
                cmdDel.Parameters.AddWithValue("@ID", fID);
                


                if (db.InsertUpdateData(cmdDel))
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
            finally
            {
                loadGrid();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string sql = string.Format(@"UPDATE FacilityTB
                                        SET FacilityName = @FacilityName, Physical_Address = @Physical_Address, Postal_Address = @Postal_Address, TelNo = @TelNo
                                        WHERE (FacilityID = @ID)");

            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@FacilityID", Session["fID"].ToString());
            cmd.Parameters.AddWithValue("@FacilityName", this.txtName.Text.ToString());
            cmd.Parameters.AddWithValue("@Physical_Address", this.txtPhysicalAdr.Text.ToString());
            cmd.Parameters.AddWithValue("@Postal_Address", this.txtPostalAdr.Text.ToString());
            cmd.Parameters.AddWithValue("@TelNo", this.txtTel.Text.ToString());
            cmd.Parameters.AddWithValue("@ID", Session["fID"].ToString());

            if (db.InsertUpdateData(cmd))
            {
                Response.Write("<script typr=\"text/javascript\">alert('Process Successful!!');</script>");
            }
            loadGrid();
        }

        

        
    }
}