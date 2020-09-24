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
    public partial class adminbookinventory : System.Web.UI.Page
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


        protected void btn_Click(object sender, EventArgs e)
        {
            AddBook();
        }

        void AddBook()
        {
            string bookid;
            string bookname;

            /*
             string bookpiclocation;

             string language;
             string authorname;
             string genre;
             string publishername;
             string publisherdate;
             string addition;
             string bookcose;
             string pages;
             string actualstock;
             string currentstock;
             string issuedbooks;
             string description;
             */

            if (bookname_txt.Text.Equals("") || bookid_txt.Text.Equals(""))
            {
                Response.Write("<script> alert('Atleast Book ID And Book Name Fields Should Be Filled') </script>");
            }
            else
            {
                bookid = bookid_txt.Text.Trim();
                bookname = bookname_txt.Text.Trim();



                SqlCommand bookexist = new SqlCommand("select * from book_master_tbl where book_id=@bookid ", Connection());
                bookexist.Parameters.AddWithValue("@bookid", bookid);
                //  authorexist.ExecuteNonQuery();

                using (SqlDataReader reader = bookexist.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Response.Write("<script> alert('Book is Already Exist') </script>");
                        //   textboxs.Text = "";
                        //  textbox1.Text = "";
                    }
                    else
                    {
                        SqlCommand book = new SqlCommand("insert into book_master_tbl(book_id,book_name,genre,author_name,publisher_name,published_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) values(@book_id,@book_name,@genre,@author_name,@publisher_name,@published_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", Connection());
                        book.Parameters.AddWithValue("@book_id", bookid);
                        book.Parameters.AddWithValue("@book_name", bookname);
                        book.Parameters.AddWithValue("@genre", genre_dropdown.SelectedValue);
                        book.Parameters.AddWithValue("@author_name", authorname_txt.Text);
                        book.Parameters.AddWithValue("@publisher_name", publishername_txt.Text);
                        book.Parameters.AddWithValue("@published_date", publisherdate_txt.Text);
                        book.Parameters.AddWithValue("@language", language_dropdown.SelectedValue);
                        book.Parameters.AddWithValue("@edition", edition_txt.Text);
                        book.Parameters.AddWithValue("@book_cost", bookcost_txt.Text);
                        book.Parameters.AddWithValue("@no_of_pages", pages_txt.Text);
                        book.Parameters.AddWithValue("@book_description", bookdescription_txtarea.Text);
                        book.Parameters.AddWithValue("@actual_stock", actualstock_txt.Text);
                        book.Parameters.AddWithValue("@current_stock", currentstock_txt.Text);
                        book.Parameters.AddWithValue("@book_img_link", fileLoader.Value);

                        book.ExecuteNonQuery();
                        Connection().Close();

                        Response.Write("<script> alert('Book Added Successfully') </script>");
                        gridview3.DataBind();

                        bookid_txt.Text = "";
                        bookname_txt.Text = "";
                        language_dropdown.SelectedValue = "Select";
                        authorname_txt.Text = "";
                        genre_dropdown.SelectedValue = "Select";
                        publishername_txt.Text = "";
                        publisherdate_txt.Text = "";
                        edition_txt.Text = "";
                        bookcost_txt.Text = "";
                        pages_txt.Text = "";
                        actualstock_txt.Text = "";
                        currentstock_txt.Text = "";
                        bookdescription_txtarea.Text = "";
                        //       gridview1.DataBind();

                    }

                }
            }




            //  SqlCommand authorexist = new SqlCommand("select * from author_master_tbl where author_id=@authorid ", Connection());

            //  author.ExecuteNonQuery();
            //  Connection().Close();

        }

        void UpdateBook()
        {
            if (bookid_txt.Text.Equals(""))
            {
                Response.Write("<script> alert('Book ID Should Be Filled') </script>");
            }
            else
            {
                string bookid = bookid_txt.Text.Trim();
                //   string bookname = bookname_txt.Text.Trim();

                SqlCommand book2 = new SqlCommand("select * from book_master_tbl where book_id=@bookid", Connection());
                book2.Parameters.AddWithValue("@bookid", bookid);

                using (SqlDataReader reader2 = book2.ExecuteReader())
                {
                    if (reader2.Read())
                    {
                        reader2.Close();

                        SqlCommand updatebook = new SqlCommand("update book_master_tbl set book_name=@book_name,genre=@genre,author_name=@author_name,publisher_name=@publisher_name,published_date=@published_date,language=@language,edition=@edition,book_cost=@book_cost,no_of_pages=@no_of_pages,book_description=@book_description,actual_stock=@actual_stock,current_stock=@current_stock,book_img_link=@book_img_link where book_id=@book_id", Connection());
                        updatebook.Parameters.AddWithValue("@book_id", bookid);
                        updatebook.Parameters.AddWithValue("@book_name", bookname_txt.Text.ToString());
                        updatebook.Parameters.AddWithValue("@genre", genre_dropdown.SelectedValue.ToString());
                        updatebook.Parameters.AddWithValue("@author_name", authorname_txt.Text.ToString());
                        updatebook.Parameters.AddWithValue("@publisher_name", publishername_txt.Text.ToString());
                        updatebook.Parameters.AddWithValue("@published_date", publisherdate_txt.Text.ToString());
                        updatebook.Parameters.AddWithValue("@language", language_dropdown.SelectedValue.ToString());
                        updatebook.Parameters.AddWithValue("@edition", edition_txt.Text.ToString());
                        updatebook.Parameters.AddWithValue("@book_cost", bookcost_txt.Text.ToString());
                        updatebook.Parameters.AddWithValue("@no_of_pages", pages_txt.Text.ToString());
                        updatebook.Parameters.AddWithValue("@book_description", bookdescription_txtarea.Text.ToString());
                        updatebook.Parameters.AddWithValue("@actual_stock", actualstock_txt.Text.ToString());
                        updatebook.Parameters.AddWithValue("@current_stock", currentstock_txt.Text.ToString());
                        updatebook.Parameters.AddWithValue("@book_img_link", fileLoader.Value);


                        updatebook.ExecuteNonQuery();

                        Connection().Close();

                        Response.Write("<script> alert('Book Updated Successfully') </script>");
                        gridview3.DataBind();

                        bookid_txt.Text = "";
                        bookname_txt.Text = "";
                        language_dropdown.SelectedValue = "Select";
                        authorname_txt.Text = "";
                        genre_dropdown.SelectedValue = "Select";
                        publishername_txt.Text = "";
                        publisherdate_txt.Text = "";
                        edition_txt.Text = "";
                        bookcost_txt.Text = "";
                        pages_txt.Text = "";
                        actualstock_txt.Text = "";
                        currentstock_txt.Text = "";
                        bookdescription_txtarea.Text = "";


                    }
                    else
                    {
                        Response.Write("<script> alert('No Book is Available For This ID.') </script>");

                    }

                }
            }
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            if (bookid_txt.Text.Equals(""))
            {
                string bookid;
                bookid = rnd.Next().ToString();
                //   System.Diagnostics.Debug.WriteLine(authorid);
                bookid_txt.Text = bookid;

                //  fileLoader.Value = "";
                bookname_txt.Text = "";
                language_dropdown.SelectedValue = "Select";
                authorname_txt.Text = "";
                genre_dropdown.SelectedValue = "Select";
                publishername_txt.Text = "";
                publisherdate_txt.Text = "";
                edition_txt.Text = "";
                bookcost_txt.Text = "";
                pages_txt.Text = "";
                actualstock_txt.Text = "";
                currentstock_txt.Text = "";
                bookdescription_txtarea.Text = "";

                //    fileLoader.Value = "Select Book Image";
                bookname_txt.Attributes.Add("placeholder", "Enter New Book Name Here");
                authorname_txt.Attributes.Add("placeholder", "Enter Author Name Here");
                publishername_txt.Attributes.Add("placeholder", "Enter Publisher Name Here");
                publisherdate_txt.Attributes.Add("placeholder", "Enter Published Date Here");
                edition_txt.Attributes.Add("placeholder", "Enter Edition Here");
                bookcost_txt.Attributes.Add("placeholder", "Enter Book Cost Here");
                pages_txt.Attributes.Add("placeholder", "Enter No of Pages Here");
                actualstock_txt.Attributes.Add("placeholder", "Enter Actual Stock Here");
                currentstock_txt.Attributes.Add("placeholder", "Enter Current Stock Here");
                bookdescription_txtarea.Attributes.Add("placeholder", "Enter Book Description Here");

            }
            else
            {
                string bookid = bookid_txt.Text.Trim();

                SqlCommand book3 = new SqlCommand("select * from book_master_tbl where book_id=@bookid", Connection());
                book3.Parameters.AddWithValue("@bookid", bookid);

                using (SqlDataReader reader = book3.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        bookid_txt.Text = reader.GetValue(0).ToString();
                        bookname_txt.Text = reader.GetValue(1).ToString();
                        genre_dropdown.SelectedValue = reader.GetValue(2).ToString();
                        authorname_txt.Text = reader.GetValue(3).ToString();
                        publishername_txt.Text = reader.GetValue(4).ToString();
                        publisherdate_txt.Text = reader.GetValue(5).ToString();
                        language_dropdown.SelectedValue = reader.GetValue(6).ToString();
                        edition_txt.Text = reader.GetValue(7).ToString();
                        bookcost_txt.Text = reader.GetValue(8).ToString();
                        pages_txt.Text = reader.GetValue(9).ToString();
                        bookdescription_txtarea.Text = reader.GetValue(10).ToString();
                        actualstock_txt.Text = reader.GetValue(11).ToString();
                        currentstock_txt.Text = reader.GetValue(12).ToString();
                        //   fileLoader.Value = reader.GetValue(13).ToString();


                        // bookid_txt.Text = authorname;
                    }
                    else
                    {
                        Response.Write("<script> alert('No Book For This ID. Fill Details For New Book') </script>");

                        //   fileLoader.Value = "";
                        bookname_txt.Text = "";
                        language_dropdown.SelectedValue = "Select";
                        authorname_txt.Text = "";
                        genre_dropdown.SelectedValue = "Select";
                        publishername_txt.Text = "";
                        publisherdate_txt.Text = "";
                        edition_txt.Text = "";
                        bookcost_txt.Text = "";
                        pages_txt.Text = "";
                        actualstock_txt.Text = "";
                        currentstock_txt.Text = "";
                        bookdescription_txtarea.Text = "";

                        //   fileLoader.Value = "Select Book Image";
                        bookname_txt.Attributes.Add("placeholder", "Enter New Book Name Here");
                        authorname_txt.Attributes.Add("placeholder", "Enter Author Name Here");
                        publishername_txt.Attributes.Add("placeholder", "Enter Publisher Name Here");
                        publisherdate_txt.Attributes.Add("placeholder", "Enter Published Date Here");
                        edition_txt.Attributes.Add("placeholder", "Enter Edition Here");
                        bookcost_txt.Attributes.Add("placeholder", "Enter Book Cost Here");
                        pages_txt.Attributes.Add("placeholder", "Enter No of Pages Here");
                        actualstock_txt.Attributes.Add("placeholder", "Enter Actual Stock Here");
                        currentstock_txt.Attributes.Add("placeholder", "Enter Current Stock Here");
                        bookdescription_txtarea.Attributes.Add("placeholder", "Enter Book Description Here");

                    }
                    reader.Close();
                    Connection().Close();

                }
            }
        }

        protected void Buttton1_Click(object sender, EventArgs e)
        {
            UpdateBook();
        }

        protected void Buttron3_Click(object sender, EventArgs e)
        {
            DeleteBook();
        }

        void DeleteBook()
        {
            if (bookid_txt.Text.Equals(""))
            {
                Response.Write("<script> alert('Book ID Should Be Entered') </script>");
            }
            else
            {
                string bookid = bookid_txt.Text.Trim();

                SqlCommand deleteexist = new SqlCommand("select * from book_master_tbl where book_id=@bookid", Connection());
                deleteexist.Parameters.AddWithValue("@bookid", bookid);

                using (SqlDataReader reader123 = deleteexist.ExecuteReader())
                {
                    if (reader123.Read())
                    {
                        reader123.Close();
                        SqlCommand deletedeletebook = new SqlCommand("delete from book_master_tbl where book_id=@bookid", Connection());
                        deletedeletebook.Parameters.AddWithValue("@bookid",bookid);
                        deletedeletebook.ExecuteNonQuery();
                        Connection().Close();
                        Response.Write("<script> alert('Book Deleted Successfully') </script>");
                        gridview3.DataBind();

                        bookid_txt.Text = "";
                        bookname_txt.Text = "";
                        language_dropdown.SelectedValue = "Select";
                        authorname_txt.Text = "";
                        genre_dropdown.SelectedValue = "Select";
                        publishername_txt.Text = "";
                        publisherdate_txt.Text = "";
                        edition_txt.Text = "";
                        bookcost_txt.Text = "";
                        pages_txt.Text = "";
                        actualstock_txt.Text = "";
                        currentstock_txt.Text = "";
                        bookdescription_txtarea.Text = "";


                    }
                    else
                    {
                        Response.Write("<script> alert('No Book Exist For This ID') </script>");
                    }

                }
            }
        }
    }
}