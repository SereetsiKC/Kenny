using HospitalManagementSystem.Classes;
using HospitalManagementSystem.EmailVerify;
using HospitalManagementSystem.ValidateSAID;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem.Paitients
{
    public partial class EditUserProfile : System.Web.UI.Page
    {
        public static string filetype = string.Empty, filename = string.Empty, contentType = string.Empty;
        public static byte[] bytes;
        DBAccess db = new DBAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateFields();
            }
        }

        protected void LBReg_Click(object sender, EventArgs e)
        {

            if (ValidateSAID(this.txtIDNo.Text.ToString()))
            {
                if (ValidateCellNumber(this.txtCell.Text.Trim()))
                {
                    Image();
                    try
                    {
                        string sqlPatient = @"UPDATE    PatientTB
                                            SET IDNo = @IDNo, Title = @Title, FName = @FName, Surname = @Surname, Email_Address = @Email_Address, Cell_No = @Cell_No, Tel_No = @Tel_No, Gender = @Gender, Race = , Residential_Address = @Residential_Address, Postal_Address = @Postal_Address
                                            WHERE     (IDNo = @ID)";

                        string gender = this.RDLGender.SelectedItem.Value.ToString().Substring(0, 1);

                        SqlCommand cmdPatient = new SqlCommand(sqlPatient);
                        cmdPatient.Parameters.AddWithValue("@IDno", this.txtIDNo.Text.ToString());
                        cmdPatient.Parameters.AddWithValue("@Title", this.DDLtitle.Text.ToString());
                        cmdPatient.Parameters.AddWithValue("@FName", this.txtNames.Text.ToString());
                        cmdPatient.Parameters.AddWithValue("@Surname", this.txtSurname.Text.ToString());
                        cmdPatient.Parameters.AddWithValue("@Email_Address", this.txtEmail.Text.ToString());
                        cmdPatient.Parameters.AddWithValue("@Cell_No", this.txtCell.Text.ToString());
                        cmdPatient.Parameters.AddWithValue("@Tel_No", this.txtTel.Text.ToString());
                        cmdPatient.Parameters.AddWithValue("@Gender", gender);
                        cmdPatient.Parameters.AddWithValue("@Race", this.RDLRace.SelectedItem.Value.ToString());
                        cmdPatient.Parameters.AddWithValue("@Residential_Address", this.txtResidentialAddress.Text.ToString());
                        cmdPatient.Parameters.AddWithValue("@Postal_Address", this.txtPostalAddress.Text.ToString());
                        cmdPatient.Parameters.AddWithValue("@ID", this.txtIDNo.Text.ToString());

                        if (db.InsertUpdateData(cmdPatient))
                        {

                            string sqlProfile = @"UPDATE    ProfileTB
                                                SET              IDNo = @IDNo, Username = @Username, Password = @Password, ProfileImage = @ProfileImage, contentType = @contentType, FileName = @FileName, Role = @Role
                                                WHERE     (IDNo = @ID)";

                            SqlCommand cmdProfile = new SqlCommand(sqlProfile);
                            cmdProfile.Parameters.AddWithValue("@IDNo", this.txtIDNo.Text.ToString());
                            cmdProfile.Parameters.AddWithValue("@Username", this.lblUsername.Text.ToString());
                            cmdProfile.Parameters.AddWithValue("@Password", this.txtPassword1.Text.ToString());
                            cmdProfile.Parameters.AddWithValue("@ProfileImage", bytes);
                            cmdProfile.Parameters.AddWithValue("@contentType", contentType);
                            cmdProfile.Parameters.AddWithValue("@FileName", filename);
                            cmdProfile.Parameters.AddWithValue("@Role", 3);
                            cmdProfile.Parameters.AddWithValue("@ID", this.txtIDNo.Text.ToString());

                            if (db.InsertUpdateData(cmdProfile))
                            {
                                Response.Write("<script typr=\"text/javascript\">alert('Patient Successfully added!!');</script>");
                            }
                            else
                            {
                                Response.Write("<script typr=\"text/javascript\">alert('Error : Process Unsuccessful(Profile Uncreated)!!');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script typr=\"text/javascript\">alert('Error : Process Unsuccessful!!');</script>");
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script typr=\"text/javascript\">alert('Error :" + ex.Message + "');</script>");
                    }

                }
                else
                {
                    Response.Write("<script typr=\"text/javascript\">alert('Invalid Cell Number');</script>");
                }
                LBClear_Click(sender, e);

            }
            else
            {
                Response.Write("<script typr=\"text/javascript\">alert('Invalid SAID Number');</script>");
            }
        }
        public bool ValidateSAID(string ID)
        {
            string sSAID = ID.Trim();
            HospitalManagementSystem.ValidateSAID.saidType oReturn;

            SAIDValidator oValidate = new SAIDValidator();
            oReturn = oValidate.ValidateIdString("authToken", sSAID);

            bool blnValidated = oReturn.Valid;

            return blnValidated;

        }
        public bool ValidateCellNumber(string p_Number)
        {

            string zero = string.Empty, second = string.Empty;

            zero = p_Number.Substring(0, 1);
            second = p_Number.Substring(1, 1);
            if (zero == "0")
            {
                if (second == "6" || second == "7" || second == "8")
                {
                    if (p_Number.Length == 10)
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        protected void LBClear_Click(object sender, EventArgs e)
        {
            this.txtIDNo.Text = string.Empty;
            this.txtNames.Text = string.Empty;
            this.txtSurname.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtCell.Text = string.Empty;
            this.txtTel.Text = string.Empty;
            this.RDLGender.ClearSelection();
            this.RDLRace.ClearSelection();
            this.txtResidentialAddress.Text = string.Empty;
            this.txtPostalAddress.Text = string.Empty;
            this.AjaxFileUpload1.ClearFileListAfterUpload = true;

            try
            {
                string r = HttpRuntime.AppDomainAppPath;
                string deletePath = r.Replace(@"\", "/") + "Images/tempImg/" + filename;
                FileInfo myfile = new FileInfo(deletePath);
                myfile.Delete();
            }
            catch (FileNotFoundException ex)
            {
                Response.Write("<script typr=\"text/javascript\">alert('Error :" + ex.Message + "');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script typr=\"text/javascript\">alert('Error :" + ex.Message + "');</script>");
            }
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            this.lblUsername.Text = this.txtEmail.Text.ToString().Trim();
        }

        protected void RDLGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string imgPath = string.Empty;

            switch (RDLGender.SelectedIndex)
            {
                case 0:
                    {
                        imgPath = "'../images/gender/0.png'";
                        break;
                    }
                default:
                    {
                        imgPath = "'../images/gender/1.jpg'";
                        break;
                    }
            }

            string script = string.Format("changeImage({0})", imgPath);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", script, true);
        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            filename = System.IO.Path.GetFileName(e.FileName);
            filetype = System.IO.Path.GetExtension(e.FileName);
            string savepath = "~/Images/tempImg/";
            AjaxFileUpload1.SaveAs(Server.MapPath(savepath) + filename);

        }

        public void Image()
        {
            string filepath = Server.MapPath("~/images/tempImg/" + filename);

            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            bytes = br.ReadBytes((Int32)fs.Length);
            br.Close();
            fs.Close();


            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

            if (filetype == ".jpg")
            {
                contentType = "image/jpg";
                string byte1 = "data:image/jpg;base64," + base64String;
                string profileIMG = "'" + byte1 + "'";
                string script = string.Format("changeImage({0})", profileIMG);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", script, true);

            }
            else if (filetype == ".png")
            {
                contentType = "image/png";
                string byte1 = "data:image/png;base64," + base64String;
                string profileIMG = "'" + byte1 + "'";
                string script = string.Format("changeImage({0})", profileIMG);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", script, true);
            }
            else if (filetype == ".jpeg")
            {
                contentType = "image/jpeg";
                string byte1 = "data:image/jpeg;base64," + base64String;
                string profileIMG = "'" + byte1 + "'";
                string script = string.Format("changeImage({0})", profileIMG);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", script, true);
            }

        }

        public void PopulateFields() {
            string IDNo = Session["EDITUSER"].ToString();

            string sqlcmd = @"SELECT     PatientTB.IDNo, PatientTB.Title, PatientTB.FName, PatientTB.Surname, PatientTB.Email_Address, PatientTB.Cell_No, PatientTB.Tel_No, PatientTB.Gender, PatientTB.Race, 
                      PatientTB.Residential_Address, PatientTB.Postal_Address, ProfileTB.Username, ProfileTB.Password, ProfileTB.ProfileImage, ProfileTB.contentType, ProfileTB.FileName, ProfileTB.Role
                    FROM         PatientTB INNER JOIN
                                          ProfileTB ON PatientTB.IDNo = ProfileTB.IDNo
                    WHERE     (PatientTB.IDNo = @IDNO)";

            SqlCommand cmd = new SqlCommand(sqlcmd);
            cmd.Parameters.AddWithValue("@IDNO", IDNo);
            DataTable dt = db.GetData(cmd);
            try
            {
                /*
                byte[] bytes = (byte[])rows["Data"];
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                byte1 = "data:" + rows["contentType"].ToString() + ";base64," + base64String;
                lblInfo1.Text = " "+rows["Part_ID"].ToString() + " " + rows["Part_Name"].ToString() + "\nR" + rows["Price"].ToString();
                logo = "'" + byte1 + "'";
                break;
                 */
                if (dt.Rows.Count == 1)
                {
                    foreach (DataRow row in dt.Rows) {
                        bytes = (byte[])row["ProfileImage"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        string byte1 = "data:" + row["contentType"].ToString() + ";base64," + base64String;
                        string profileIMG = "'" + byte1 + "'";
                        string script = string.Format("changeImage({0})", profileIMG);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", script, true);

                        filename = row["FileName"].ToString();
                        contentType = row["contentType"].ToString();

                        this.DDLtitle.Text = row["Title"].ToString();
                        this.txtIDNo.Text = row["IDNo"].ToString();
                        this.txtNames.Text = row["FName"].ToString();
                        this.txtSurname.Text = row["Surname"].ToString();
                        this.txtEmail.Text = row["Email_Address"].ToString();
                        this.txtCell.Text = row["Cell_No"].ToString();
                        this.txtTel.Text = row["Tel_No"].ToString();

                        switch (row["Gender"].ToString()) {
                            case "M": {
                                this.RDLGender.SelectedIndex = 1;
                                break;
                            }
                            default: {
                                this.RDLGender.SelectedIndex = 0;
                                break;
                            }
                        }

                        this.RDLRace.SelectedValue = row["Race"].ToString();
                        this.txtResidentialAddress.Text = row["Residential_Address"].ToString();
                        this.txtPostalAddress.Text = row["Postal_Address"].ToString();
                        this.lblUsername.Text = row["Email_Address"].ToString();

                    }
                }
            }
            catch(Exception ex){}
        }
    }
}