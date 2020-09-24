using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    LinksButton2.Visible = true; //Signup button
                    LinkdButton1.Visible = true; //User login button
                    LinkdaButton3.Visible = false; // logout button
                    LainkButton4.Visible = false; // Hello user button

                    linkbudtton1.Visible = true; //Admin login
                    linkbutston5.Visible = false; //Author management button
                    linkbutston6.Visible = false; //Publisher management
                    linkbustton7.Visible = false; //Book inventory
                    linkbutdton8.Visible = false; //Book issuing
                    linkbuatton9.Visible = false; //Member management

                }
                else if(Session["role"].Equals("user"))
                {
                    LinksButton2.Visible = false; //Signup button
                    LinkdButton1.Visible = false; //User login button
                    LinkdaButton3.Visible = true; // logout button
                    LainkButton4.Visible = true;
                    LainkButton4.Text = "Hello " + Session["username"].ToString(); // Hello user button

                    linkbudtton1.Visible = false; //Admin login
                    linkbutston5.Visible = false; //Author management button
                    linkbutston6.Visible = false; //Publisher management
                    linkbustton7.Visible = false; //Book inventory
                    linkbutdton8.Visible = false; //Book issuing
                    linkbuatton9.Visible = false; //Member management
                }
                else if(Session["role"].Equals("admin"))
                {
                    LinksButton2.Visible = false; //Signup button
                    LinkdButton1.Visible = false; //User login button
                    LinkdaButton3.Visible = true; // logout button
                    LainkButton4.Visible = true;
                    LainkButton4.Text = "Hello " + Session["username"].ToString(); // Hello user button

                    linkbudtton1.Visible = true; //Admin login
                    linkbutston5.Visible = true; //Author management button
                    linkbutston6.Visible = true; //Publisher management
                    linkbustton7.Visible = true; //Book inventory
                    linkbutdton8.Visible = true; //Book issuing
                    linkbuatton9.Visible = true; //Member management
                }

            }catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        protected void adminLogin(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void adminAuthor(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void adminPublisher(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void adminBookInventory(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void adminBookIssuing(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void adminMemberManagement(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void userLogin(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void userProfile(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }

        protected void signup(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        protected void viewBooks(object sender, EventArgs e)
        {
            Response.Redirect("booklist.aspx");
        }

        protected void LinkdaButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["status"] = "";
            Session["role"] = "";

            LinksButton2.Visible = true; //Signup button
            LinkdButton1.Visible = true; //User login button
            LinkdaButton3.Visible = false; // logout button
            LainkButton4.Visible = false; // Hello user button

            linkbudtton1.Visible = true; //Admin login
            linkbutston5.Visible = false; //Author management button
            linkbutston6.Visible = false; //Publisher management
            linkbustton7.Visible = false; //Book inventory
            linkbutdton8.Visible = false; //Book issuing
            linkbuatton9.Visible = false; //Member management

            Response.Redirect("homepage.aspx");
        }
    }
}