using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class adminlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            checkValidity();
        }

        SqlConnection Connection()
        {
            SqlConnection con = null;
            try
            {
                //   System.Diagnostics.Debug.WriteLine("try");
                con = new SqlConnection(strcon);
                //   System.Diagnostics.Debug.WriteLine("sqlcnnectn");
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    //    System.Diagnostics.Debug.WriteLine("beforevcon open");
                    con.Open();
                    //   System.Diagnostics.Debug.WriteLine("after con open");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return con;
        }

        void checkValidity()
        {
            var username = adminId.Text.Trim();
            var pwd = password.Text.Trim();

            SqlCommand member = new SqlCommand("select * from admin_login_table where user_name=@username", Connection());
            member.Parameters.AddWithValue("@username", username);

            using (SqlDataReader reader = member.ExecuteReader())
            {
                if (reader.Read())
                {
                    //  System.Diagnostics.Debug.WriteLine("have");
                    //  Response.Write("<script> alert('User Id <" + memberId + "> is Already Registered. Try Another One.') </script>");
                    string usrnme = (string)reader["user_name"];
                    string pswrd = (string)reader["password"];
                    //   string dob = (string)reader.GetValue(1);

                    if (username == usrnme && pwd == pswrd)
                    {
                        Response.Write("<script> alert('both matching') </script>");

                        Session["username"] = reader.GetValue(0).ToString();
                        Session["fullname"] = reader.GetValue(2).ToString();
                        Session["role"] = "admin";

                        Response.Redirect("homepage.aspx");
                    }

                    else if (username == usrnme && pwd != pswrd)
                    {
                        Response.Write("<script> alert('password not matching') </script>");
                    }

                }
                else
                {
                    //  System.Diagnostics.Debug.WriteLine("null");

                    Response.Write("<script> alert('Admin Not Exist') </script>");
                }

                Connection().Close();
            }

            // System.Diagnostics.Debug.WriteLine(member.ExecuteNonQuery());

        }
    }
}