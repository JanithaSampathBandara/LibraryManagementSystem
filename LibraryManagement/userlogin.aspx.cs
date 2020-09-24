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
    public partial class userlogin : System.Web.UI.Page
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
            var memberId = member_id.Text.Trim();
            var pwd = password.Text.Trim();

            SqlCommand member = new SqlCommand("select * from member_master_tbl where member_id =@memberid", Connection());
            member.Parameters.AddWithValue("@memberid", memberId);

            using (SqlDataReader reader = member.ExecuteReader())
            {
                if (reader.Read())
                {
                    //  System.Diagnostics.Debug.WriteLine("have");
                    //  Response.Write("<script> alert('User Id <" + memberId + "> is Already Registered. Try Another One.') </script>");
                    string memberid = (string)reader["member_id"];
                    string password = (string)reader["password"];
                 //   string dob = (string)reader.GetValue(1);

                    if (memberid==memberId && pwd == password)
                    {
                        Response.Write("<script> alert('both matching') </script>");

                        //Creating Session variables which remain throughout the application

                        Session["username"] = reader.GetValue(8).ToString();
                        Session["fullname"] = reader.GetValue(0).ToString();
                        Session["role"] = "user";
                        Session["status"] = reader.GetValue(10).ToString();

                        Response.Redirect("homepage.aspx");
                    }

                    else if(memberid == memberId && pwd != password)
                    {
                        Response.Write("<script> alert('password not matching') </script>");
                    }

                }
                else
                {
                    //  System.Diagnostics.Debug.WriteLine("null");

                    Response.Write("<script> alert('User Name Not Exist') </script>");
                }

                Connection().Close();
            }

            // System.Diagnostics.Debug.WriteLine(member.ExecuteNonQuery());

        }
    }
}