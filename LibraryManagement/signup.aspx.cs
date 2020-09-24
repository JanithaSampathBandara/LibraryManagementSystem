using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class signup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void Button_Click1(object sender, EventArgs e)
        {
            Signup();
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

        void Signup()
        {
            //   Response.Write("<script> alert('helloo') </script>");

            try
            {
                Connection();

                var memberId = member_id.Text.Trim();
                SqlCommand cmd2 = new SqlCommand("select * from member_master_tbl where member_id = @memberId", Connection());
                cmd2.Parameters.AddWithValue("@memberId", memberId);

                using (SqlDataReader reader = cmd2.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        System.Diagnostics.Debug.WriteLine("have");
                        Response.Write("<script> alert('User Id <" + memberId + "> is Already Registered. Try Another One.') </script>");
                    }
                    else
                    {
                        //  System.Diagnostics.Debug.WriteLine("null");

                        SqlCommand cmd = new SqlCommand("insert into member_master_tbl(full_name,dob,contact_no,email,state,city,pin_code,full_address,member_id,password,account_status) values(@full_name,@dob,@contact_no,@email,@state,@city,@pin_code,@full_address,@member_id,@password,@account_status)", Connection());

                        cmd.Parameters.AddWithValue("@full_name", full_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@dob", dob.Text.Trim());
                        cmd.Parameters.AddWithValue("@contact_no", contact_no.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", email.Text.Trim());
                        cmd.Parameters.AddWithValue("@state", state.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@city", city.Text.Trim());
                        cmd.Parameters.AddWithValue("@pin_code", pin_code.Text.Trim());
                        cmd.Parameters.AddWithValue("@full_address", full_address.Text.Trim());
                        cmd.Parameters.AddWithValue("@member_id", member_id.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", password.Text.Trim());
                        cmd.Parameters.AddWithValue("@account_status", "Pending");

                        cmd.ExecuteNonQuery();
                        Connection().Close();

                        Response.Write("<script> alert('Sign Up successful. Go to Log In to Log in') </script>");
                    }
                }

            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("sadAd");
                System.Diagnostics.Debug.WriteLine(ex.Message);
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
                Console.WriteLine(ex.StackTrace);
                Response.Write("<script> alert('" + ex.Message + "'); </script>");
            }

        }

        /*
                    //    cmd2.Parameters.AddWithValue("@memberId", memberId);

                        using (SqlDataReader reader = cmd2.ExecuteReader()) {

                            while (reader.Read())
                            {
                                //   Console.WriteLine(String.Format("{0}", reader["id"]));
                                string memberid = (string)reader["member_id"];
                              //  string dob = (string)reader["dob"];
                             //   System.Diagnostics.Debug.WriteLine(fullname);
                                System.Diagnostics.Debug.WriteLine(memberid);

                            }
        */
        /*
                            DataTable schemaTable = reader.GetSchemaTable();

                        foreach (DataRow row in schemaTable.Rows)
                        {
                            foreach (DataColumn column in schemaTable.Columns)
                            {
                                Console.WriteLine(String.Format("{0} = {1}",
                                column.ColumnName, row[column]));
                            }
                        }
                        */

        //  Console.WriteLine(reader.GetValue(i));


        /*
                if (cmd2 == null)
                {
                    SqlCommand cmd = new SqlCommand("insert into member_master_tbl(full_name,dob,contact_no,email,state,city,pin_code,full_address,member_id,password,account_status) values(@full_name,@dob,@contact_no,@email,@state,@city,@pin_code,@full_address,@member_id,@password,@account_status)", Connection());

                    cmd.Parameters.AddWithValue("@full_name", full_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@dob", dob.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact_no", contact_no.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", email.Text.Trim());
                    cmd.Parameters.AddWithValue("@state", state.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@city", city.Text.Trim());
                    cmd.Parameters.AddWithValue("@pin_code", pin_code.Text.Trim());
                    cmd.Parameters.AddWithValue("@full_address", full_address.Text.Trim());
                    cmd.Parameters.AddWithValue("@member_id", member_id.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", password.Text.Trim());
                    cmd.Parameters.AddWithValue("@account_status", "Pending");

                    cmd.ExecuteNonQuery();
                    Connection().Close();
                    //  con.Close();
                    Response.Write("<script> alert('Sign Up successful. Go to Log In to Log in') </script>");
                }

                else
                {
                    Response.Write("<script> alert('User Id <"+ memberId+"> is Already Registered. Try Another One.') </script>");

                }

            }
           


        }
     */

        /*     void Signup()
              {
                  //   Response.Write("<script> alert('helloo') </script>");

                  try
                  {
                      //   System.Diagnostics.Debug.WriteLine("try");
                      SqlConnection con = new SqlConnection(strcon);
                      //   System.Diagnostics.Debug.WriteLine("sqlcnnectn");
                      if (con.State == System.Data.ConnectionState.Closed)
                      {
                          //    System.Diagnostics.Debug.WriteLine("beforevcon open");
                          con.Open();
                          //   System.Diagnostics.Debug.WriteLine("after con open");
                      }

                      SqlCommand cmd = new SqlCommand("insert into member_master_tbl(full_name,dob,contact_no,email,state,city,pin_code,full_address,member_id,password,account_status) values(@full_name,@dob,@contact_no,@email,@state,@city,@pin_code,@full_address,@member_id,@password,@account_status)", con);

                      //  Response.Write("<script> alert('near sl command'); </script>");
                      //   System.Diagnostics.Debug.WriteLine("after cmd");
                      // text with @ sign are placeholders. So in belowe, we assign values to those placeholders. 

                      cmd.Parameters.AddWithValue("@full_name", full_name.Text.Trim());
                      cmd.Parameters.AddWithValue("@dob", dob.Text.Trim());
                      cmd.Parameters.AddWithValue("@contact_no", contact_no.Text.Trim());
                      cmd.Parameters.AddWithValue("@email", email.Text.Trim());
                      cmd.Parameters.AddWithValue("@state", state.SelectedItem.Value);
                      cmd.Parameters.AddWithValue("@city", city.Text.Trim());
                      cmd.Parameters.AddWithValue("@pin_code", pin_code.Text.Trim());
                      cmd.Parameters.AddWithValue("@full_address", full_address.Text.Trim());
                      cmd.Parameters.AddWithValue("@member_id", member_id.Text.Trim());
                      cmd.Parameters.AddWithValue("@password", password.Text.Trim());
                      cmd.Parameters.AddWithValue("@account_status", "Pending");

                      cmd.ExecuteNonQuery();
                      con.Close();
                      Response.Write("<script> alert('Sign Up successful. Go to Log In to Log in') </script>");


                  }
                  catch (Exception ex)
                  {
                      System.Diagnostics.Debug.WriteLine("sadAd");
                      System.Diagnostics.Debug.WriteLine(ex.Message);
                      Response.Write("<script> alert('" + ex.Message + "'); </script>");
                      Console.WriteLine(ex.StackTrace);
                      Response.Write("<script> alert('" + ex.Message + "'); </script>");
                  }
              } 

              */
    }
}
