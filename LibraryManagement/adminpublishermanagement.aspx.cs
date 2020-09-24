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
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gridview2.DataBind();
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

        void AddPublisher()
        {

            string publisherid;
            string publishername;

            if (textboxs.Text.Equals("") || textbox1.Text.Equals(""))
            {
                Response.Write("<script> alert('Publisher ID And Name Fields Should Be Filled') </script>");
            }
            else
            {
                publisherid = textboxs.Text.Trim();
                publishername = textbox1.Text.Trim();
                SqlCommand publisherexist = new SqlCommand("select * from publisher_master_tbl where publisher_id = @publisherid ", Connection());
                publisherexist.Parameters.AddWithValue("@publisherid", publisherid);
                //  authorexist.ExecuteNonQuery();

                using (SqlDataReader reader = publisherexist.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Response.Write("<script> alert('Publisher ID Already Exist') </script>");
                        //   textboxs.Text = "";
                        //  textbox1.Text = "";
                    }
                    else
                    {
                        SqlCommand publisher = new SqlCommand("insert into publisher_master_tbl(publisher_id, publisher_name) values(@publisher_id,@publisher_name)", Connection());
                        publisher.Parameters.AddWithValue("@publisher_id", publisherid);
                        publisher.Parameters.AddWithValue("@publisher_name", publishername);

                        publisher.ExecuteNonQuery();

                        Response.Write("<script> alert('Publisher Added Successfully') </script>");
                        gridview2.DataBind();

                    }
                    Connection().Close();
                }
            }

        }

        void UpdatePublisher()
        {


            string publisherid;
            string publishername;

            if (textboxs.Text.Equals("") || textbox1.Text.Equals(""))
            {
                Response.Write("<script> alert('Publisher ID And Name Fields Should Be Filled') </script>");
            }
            else
            {
                publisherid = textboxs.Text.Trim();
                publishername = textbox1.Text.Trim();
                SqlCommand publisherexist = new SqlCommand("select * from publisher_master_tbl where publisher_id=@publisherid ", Connection());
                publisherexist.Parameters.AddWithValue("@publisherid", publisherid);
                //  authorexist.ExecuteNonQuery();

                using (SqlDataReader reader = publisherexist.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        SqlCommand publisher = new SqlCommand("update publisher_master_tbl set publisher_name = @publisher_name where publisher_id=@publisher_id", Connection());
                        publisher.Parameters.AddWithValue("@publisher_name", publishername);
                        publisher.Parameters.AddWithValue("@publisher_id", publisherid);
                        publisher.ExecuteNonQuery();
                        Response.Write("<script> alert('Publisher Is Updated Successully') </script>");
                        gridview2.DataBind();
                        //   textboxs.Text = "";
                        //  textbox1.Text = "";
                    }
                    else
                    {
                        Response.Write("<script> alert('No Publisher For This ID') </script>");
                        //   SqlCommand author = new SqlCommand("insert into author_master_tbl(author_id, author_name) values(@authorid,@authorname)", Connection());
                        //   author.Parameters.AddWithValue("@authorid", authorid);
                        //   author.Parameters.AddWithValue("@authorname", authorname);
                        //   author.ExecuteNonQuery();

                    }
                    Connection().Close();
                }
            }




            //  SqlCommand authorexist = new SqlCommand("select * from author_master_tbl where author_id=@authorid ", Connection());

            //  author.ExecuteNonQuery();
            //  Connection().Close();

        }

        void DeleteAuthor()
        {

            string publisherid;
            string publishername;

            if (textboxs.Text.Equals("") || textbox1.Text.Equals(""))
            {
                Response.Write("<script> alert('Publisher Should Be Selected') </script>");
            }
            else
            {
                publisherid = textboxs.Text.Trim();
                publishername = textbox1.Text.Trim();
                SqlCommand publisher = new SqlCommand("delete from publisher_master_tbl where publisher_id=@publisherid ", Connection());
                publisher.Parameters.AddWithValue("@publisherid", publisherid);
                publisher.ExecuteNonQuery();
                Response.Write("<script> alert('Publisher Is Deleted Successully') </script>");

                textboxs.Text = "";
                textbox1.Text = "";

                gridview2.DataBind();

                Connection().Close();
            }


        }

        protected void button1_Click(object sender, EventArgs e)
        {
            AddPublisher();
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            UpdatePublisher();
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            DeleteAuthor();
        }

        protected void buttona_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            if (textboxs.Text.Equals(""))
            {
                string publisherid;
                publisherid = rnd.Next().ToString();
                //   System.Diagnostics.Debug.WriteLine(authorid);
                textboxs.Text = publisherid;
                textbox1.Text = "";
                //  textbox1.Visible = true;
                textbox1.Attributes.Add("placeholder", "Enter a New Publisher Name Here");
                //  textbox1.Attributes.Add()
                //    textbox1.Attributes.Add("onkeypress", "if(!textbox1.Text.Equals(authorid)){textbox1.Attributes.Add("+"placeholder"+","+ "Enter a New Author Name Here"+");}"+"");
                //  int count = ;
                //   if (!textbox1.Text.Equals(authorid))
            }
            else
            {
                string publisherid = textboxs.Text.Trim();
                string publishername;

                SqlCommand publisher = new SqlCommand("select * from publisher_master_tbl where publisher_id=@publisherid", Connection());
                publisher.Parameters.AddWithValue("@publisherid", publisherid);

                using (SqlDataReader reader = publisher.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        publishername = reader.GetValue(1).ToString();
                        textbox1.Text = publishername;
                    }
                    else
                    {
                        textbox1.Text = "";
                        //    textbox1.Visible = true;
                        textbox1.Attributes.Add("placeholder", "Enter a New Publisher Name Here");

                    }
                    Connection().Close();
                }
            }
        }
    }
}