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
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gridview3.DataBind();
        }

        SqlConnection Connection()
        {
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

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

        protected void button2_Click(object sender, EventArgs e)
        {
            if (memberid_txt.Text.Equals(""))
            {
                Response.Write("<script> alert('Member ID Should Be Filled'); </script>");
            }
            else
            {
                string fullname = "";
                string dob = "";
                string contactno = "";
                string email = "";
                string state = "";
                string city = "";
                string pincode = "";
                string fulladdress = "";
                string memberid = "";
             //   string password = "";
                string accountstatus = "";

                var memberId = memberid_txt.Text.Trim();
              //  var memberId = texting.Value.ToString();

                SqlCommand member = new SqlCommand("select * from member_master_tbl where member_id =@memberid", Connection());
                member.Parameters.AddWithValue("@memberid", memberId);

                using (SqlDataReader reader = member.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //  System.Diagnostics.Debug.WriteLine("have");
                        //  Response.Write("<script> alert('User Id <" + memberId + "> is Already Registered. Try Another One.') </script>");

                        fullname = (string)reader["full_name"];
                        dob = reader.GetValue(1).ToString();
                        contactno = (string)reader["contact_no"];
                        email = (string)reader["email"];
                        state = (string)reader["state"];
                        city = (string)reader["city"];
                        pincode = (string)reader["pin_code"];
                        fulladdress = (string)reader["full_address"];
                        memberid = (string)reader["member_id"];
                      //  password = (string)reader["password"];
                        accountstatus = (string)reader["account_status"];

                        fullname_txt.Text = fullname;
                        dob_txt.Text = dob;
                        contactno_txt.Text = contactno;
                        email_txt.Text = email;
                        state_dropdown.SelectedValue = state;
                        city_txt.Text = city;
                        pincode_txt.Text = pincode;
                        address_txt.Text = fulladdress;
                        memberid_txt.Text = memberid;
                        //   password_txt.Text = password;
                        accountstatus_txt.Text = accountstatus;

                    //    button3.Attributes.Remove("ReadOnly");
                    //    LinkButton1.Attributes.Remove("ReadOnly");
                    //    LinkButton2.Attributes.Remove("ReadOnly");
                        //  LinkButton2.Attributes.Add("ReadOnly","false");

                        //   LinkButton2.Attributes
                        //      memberid_txt.

                        gridview3.DataBind();

                        btn.Attributes.Remove("ReadOnly");


                    }
                    else
                    {
                        Response.Write("<script> alert('No User For This Member ID') </script>");
                    }

                    
                }
            }
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            string memberid = memberid_txt.Text.ToString();
            accountstatus_txt.Text = "";
            accountstatus_txt.Text = "Active";

            SqlCommand cmd = new SqlCommand("update member_master_tbl set account_status = @account_status where member_id=@member_id", Connection());
            cmd.Parameters.AddWithValue("@account_status", accountstatus_txt.Text.Trim());
            cmd.Parameters.AddWithValue("@member_id", memberid);
            cmd.ExecuteNonQuery();
            Connection().Close();
            gridview3.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string memberid = memberid_txt.Text.ToString();
            accountstatus_txt.Text = "";
            accountstatus_txt.Text = "Pending";

            SqlCommand cmd = new SqlCommand("update member_master_tbl set account_status = @account_status where member_id=@member_id", Connection());
            cmd.Parameters.AddWithValue("@account_status", accountstatus_txt.Text.Trim());
            cmd.Parameters.AddWithValue("@member_id", memberid);
            cmd.ExecuteNonQuery();
            Connection().Close();
            gridview3.DataBind();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string memberid = memberid_txt.Text.ToString();
            accountstatus_txt.Text = "";
            accountstatus_txt.Text = "Disabled";

            SqlCommand cmd = new SqlCommand("update member_master_tbl set account_status = @account_status where member_id=@member_id", Connection());
            cmd.Parameters.AddWithValue("@account_status", accountstatus_txt.Text.Trim());
            cmd.Parameters.AddWithValue("@member_id", memberid);
            cmd.ExecuteNonQuery();
            Connection().Close();
            gridview3.DataBind();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string memberid = memberid_txt.Text.ToString();

            SqlCommand cmd = new SqlCommand("delete from member_master_tbl where member_id=@member_id", Connection());
            cmd.Parameters.AddWithValue("@member_id", memberid);
            cmd.ExecuteNonQuery();
            Connection().Close();

            Response.Write("<script> alert('Member Deleted Successfully') </script>");
            gridview3.DataBind();

        }



        /*   protected void memberid_txt_TextChanged(object sender, EventArgs e)
           {
               fullname_txt.Text = "";
               dob_txt.Text = "";
               contactno_txt.Text = "";
               email_txt.Text = "";
               state_dropdown.SelectedValue = "";
               city_txt.Text = "";
               pincode_txt.Text = "";
               address_txt.Text = "";
              // memberid_txt.Text = "";
               //   password_txt.Text = password;
               accountstatus_txt.Text = "";
           }
           */
    }
}