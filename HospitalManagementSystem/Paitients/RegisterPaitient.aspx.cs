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
    public partial class RegisterPaitient : System.Web.UI.Page
    {
        public static string filetype = string.Empty, filename = string.Empty, contentType = string.Empty;
        public static byte[] bytes;
        DBAccess db = new DBAccess();
        protected void Page_Load(object sender, EventArgs e)
        {

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
                        string sqlPatient = @"INSERT INTO PatientTB(IDNo, Title, FName, Surname, Email_Address, Cell_No, Tel_No, Gender, Race, Residential_Address, Postal_Address)
                                       SELECT @IDNo, @Title, @FName, @Surname, @Email_Address, @Cell_No, @Tel_No, @Gender, @Race, @Residential_Address, @Postal_Address";

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

                        if (db.InsertUpdateData(cmdPatient))
                        {

                            string sqlProfile = @"INSERT INTO ProfileTB(IDNo, Username, Password, ProfileImage, contentType, FileName, Role)
                                                SELECT @IDNo, @Username, @Password, @ProfileImage, @contentType, @FileName, @Role";

                            SqlCommand cmdProfile = new SqlCommand(sqlProfile);
                            cmdProfile.Parameters.AddWithValue("@IDNo", this.txtIDNo.Text.ToString());
                            cmdProfile.Parameters.AddWithValue("@Username", this.lblUsername.Text.ToString());
                            cmdProfile.Parameters.AddWithValue("@Password", this.txtPassword1.Text.ToString());
                            cmdProfile.Parameters.AddWithValue("@ProfileImage", bytes);
                            cmdProfile.Parameters.AddWithValue("@contentType", contentType);
                            cmdProfile.Parameters.AddWithValue("@FileName", filename);
                            cmdProfile.Parameters.AddWithValue("@Role", 3);

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
            else {
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
        public bool ValidateCellNumber(string p_Number) {

            string zero = string.Empty, second = string.Empty;

            zero = p_Number.Substring(0,1);
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

            switch (RDLGender.SelectedIndex) {
                case 0: {
                    imgPath = "'../images/gender/0.png'";
                    break;
                }
                default:{
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
    }
}