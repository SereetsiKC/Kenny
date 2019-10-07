using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem.Blogs
{
    public partial class AddBlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string date = setDates();
            string script = "setDates(" + date + ")";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", script, true);
        }
        public string setDates(){
         
            string dates = "Posted on ";
            dates = dates + (DateTime.Now.Month).ToString() + " ,";
            dates = dates + (DateTime.Today).ToString() + " ";
            dates = dates + (DateTime.Now.Year).ToString()+" ";
            return dates;
        }
    }
}