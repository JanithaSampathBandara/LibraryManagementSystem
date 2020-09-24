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
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gridview1.DataBind();
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            AddAuthor();
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

         void AddAuthor()
        {


            string authorid;
            string authorname; 

            if(textboxs.Text.Equals("") || textbox1.Text.Equals(""))
            {
                Response.Write("<script> alert('Author ID And Name Fields Should Be Filled') </script>");
            }
            else
            {
                authorid = textboxs.Text.Trim();
                authorname = textbox1.Text.Trim();
                SqlCommand authorexist = new SqlCommand("select * from author_master_tbl where author_id=@authorid ", Connection());
                authorexist.Parameters.AddWithValue("@authorid", authorid);
              //  authorexist.ExecuteNonQuery();

                using (SqlDataReader reader = authorexist.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Response.Write("<script> alert('Author ID Already Exist') </script>");
                     //   textboxs.Text = "";
                      //  textbox1.Text = "";
                    }
                    else
                    {
                        SqlCommand author = new SqlCommand("insert into author_master_tbl(author_id, author_name) values(@authorid,@authorname)", Connection());
                        author.Parameters.AddWithValue("@authorid", authorid);
                        author.Parameters.AddWithValue("@authorname", authorname);

                        author.ExecuteNonQuery();

                        Response.Write("<script> alert('Author Added Successfully') </script>");
                        gridview1.DataBind();

                    }
                    Connection().Close();
                }
            }

            
            

          //  SqlCommand authorexist = new SqlCommand("select * from author_master_tbl where author_id=@authorid ", Connection());

          //  author.ExecuteNonQuery();
          //  Connection().Close();

        }

        protected void buttona_Click(object sender, EventArgs e)
        {
           // string authorid = textboxs.Text.Trim();
            
            Random rnd = new Random();

            if (textboxs.Text.Equals(""))
            {
                string authorid;
                authorid = rnd.Next().ToString();
             //   System.Diagnostics.Debug.WriteLine(authorid);
                textboxs.Text = authorid;
                textbox1.Text = "";
              //  textbox1.Visible = true;
                textbox1.Attributes.Add("placeholder", "Enter a New Author Name Here");
              //  textbox1.Attributes.Add()
                //    textbox1.Attributes.Add("onkeypress", "if(!textbox1.Text.Equals(authorid)){textbox1.Attributes.Add("+"placeholder"+","+ "Enter a New Author Name Here"+");}"+"");
                //  int count = ;
             //   if (!textbox1.Text.Equals(authorid))
            }
            else
            {
                string authorid = textboxs.Text.Trim();
                string authorname;

                SqlCommand author = new SqlCommand("select * from author_master_tbl where author_id=@authorid", Connection());
                author.Parameters.AddWithValue("@authorid", authorid);

                using (SqlDataReader reader = author.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        authorname = reader.GetValue(1).ToString();
                        textbox1.Text = authorname;
                    }
                    else
                    {
                        textbox1.Text = "";
                    //    textbox1.Visible = true;
                        textbox1.Attributes.Add("placeholder", "Enter a New Author Name Here");

                    }
                    Connection().Close();
                }
            }
        }

        protected void textboxs_TextChanged(object sender, EventArgs e)
        {
            string authorid = textboxs.Text.Trim();

            if (!textbox1.Text.Equals("50"))
            {
                textbox1.Attributes.Add("placeholder", "");
            }
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            UpdateAuthor();
        }

        void UpdateAuthor()
        {


            string authorid;
            string authorname;

            if (textboxs.Text.Equals("") || textbox1.Text.Equals(""))
            {
                Response.Write("<script> alert('Author ID And Name Fields Should Be Filled') </script>");
            }
            else
            {
                authorid = textboxs.Text.Trim();
                authorname = textbox1.Text.Trim();
                SqlCommand authorexist = new SqlCommand("select * from author_master_tbl where author_id=@authorid ", Connection());
                authorexist.Parameters.AddWithValue("@authorid", authorid);
                //  authorexist.ExecuteNonQuery();

                using (SqlDataReader reader = authorexist.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        SqlCommand author = new SqlCommand("update author_master_tbl set author_name = @author_name where author_id=@authorid", Connection());
                        author.Parameters.AddWithValue("@author_name", authorname);
                        author.Parameters.AddWithValue("@authorid", authorid);
                        author.ExecuteNonQuery();
                        Response.Write("<script> alert('Author Is Updated Successully') </script>");
                        gridview1.DataBind();
                        //   textboxs.Text = "";
                        //  textbox1.Text = "";
                    }
                    else
                    {
                        Response.Write("<script> alert('No Author For This ID') </script>");
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

            string authorid;
            string authorname;

            if (textboxs.Text.Equals("") || textbox1.Text.Equals(""))
            {
                Response.Write("<script> alert('Author Should Be Selected') </script>");
            }
            else
            {
                authorid = textboxs.Text.Trim();
                authorname = textbox1.Text.Trim();
                SqlCommand author = new SqlCommand("delete from author_master_tbl where author_id=@authorid ", Connection());
                author.Parameters.AddWithValue("@authorid", authorid);
                author.ExecuteNonQuery();
                Response.Write("<script> alert('Author Is Deleted Successully') </script>");

                textboxs.Text = "";
                textbox1.Text = "";

                gridview1.DataBind();

                Connection().Close();
            }
                
                    
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            DeleteAuthor();
        }




        //  SqlCommand authorexist = new SqlCommand("select * from author_master_tbl where author_id=@authorid ", Connection());

        //  author.ExecuteNonQuery();
        //  Connection().Close();

    }
    }
