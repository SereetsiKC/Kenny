using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem.Blogs
{
    public partial class Blogs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string HTML = string.Empty;
            for (int x = 0; x < 10; x++)
            {
                DateTime dt = DateTime.Now;
                string sDate = dt.ToShortDateString();
                HTML = HTML + @"<div class='post'>
                        <p><img id='Profile' src='../images/gender/0.png' alt='ProfileIMG' width='30' height='30' class='left'/><br/><h6>"+"FULLNAME(s)"+@"</h6></p>
                        <hr style='visibility: hidden; width:100%;' />
                        <h2 class='title'>"+"TITLE"+@"</h2>
                        <div class='entry'>
                            <p>"+"POST"+@"</p>
                        </div>
                        <div class='meta'>
                            <p class='byline'>Posted on " + sDate.ToString() +@"</p>
                            <p class='links'><b>|</b> <a runat='server' href='Blogs.aspx' class='comments'>Comments (" +x.ToString()+@")</a></p>
                        </div>
                    </div>
                    <hr style='visibility: hidden; width:100%;' />
                    <hr style='visibility: hidden; width:100%;' />";
            }
            this.myLiteral.Text = HTML;
        }
        
    }
}