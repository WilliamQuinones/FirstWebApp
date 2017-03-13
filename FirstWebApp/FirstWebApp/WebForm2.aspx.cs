using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.XPath;
using System.Data;
using System.Web.Security;
using System.Data.SqlClient;

namespace FirstWebApp
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        String date;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("XMLFile1.xml"));
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "name";
                DropDownList1.DataBind();
            }
       

            Label3.Text = "HEY, " + Context.User.Identity.Name + "! ";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost;Database=UserInfo;Integrated Security=True");
            SqlCommand insert = new SqlCommand("insert into UserInfo(firstname, lastname, gender, dob, pob, comments) values(@FirstName, @LastName, @Gender, @DOB, @POB, @Comments)", conn);
            insert.Parameters.AddWithValue("@firstname", TextBox1.Text);
            insert.Parameters.AddWithValue("@lastname", TextBox2.Text);
            if (Male.Checked)
            {
                insert.Parameters.AddWithValue("@gender", "Male");
            }
            else if(Female.Checked)
            {
                insert.Parameters.AddWithValue("@gender", "Female");
            }
            insert.Parameters.AddWithValue("@DOB", date = Calendar1.SelectedDate.ToShortDateString());
            insert.Parameters.AddWithValue("@POB", DropDownList1.SelectedValue);
            insert.Parameters.AddWithValue("@Comments", TextBox3.Text);
            try
            {
                conn.Open();
                insert.ExecuteNonQuery();
                Label4.Text = "Register done !";
                
            }
            catch (Exception ex)
            {
                Label4.Text = "Error: " + ex.Message;
                
                conn.Close();
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("WebForm1.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == " ")
            {
                Label5.Text = "Select First Value !!";
            }
            else
            {
                Label5.Text = "You selected value = "+DropDownList1.SelectedItem.Text;
            }
            
        }
    }
}