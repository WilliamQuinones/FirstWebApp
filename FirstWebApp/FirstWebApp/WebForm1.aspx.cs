using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace FirstWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((txtUser.Text == "wquinones1") &&
           (txtPass.Text == "hello"))
            {
                FormsAuthentication.RedirectFromLoginPage
                   (txtUser.Text, Persist.Checked);
                Response.Redirect("WebForm2.aspx");
            }
            else
            {
                Msg.Text = "Invalid credentials. Please try again.";
            }
            
        }
    }
}