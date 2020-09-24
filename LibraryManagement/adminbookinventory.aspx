<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookinventory.aspx.cs" Inherits="LibraryManagement.adminbookinventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
    // $('#myTable').DataTable();
} );
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card" style="border: solid 3px darkred">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h2>Book Details</h2>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="images/books.png" width="100px" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <input class="form-control" type="file" ID="fileLoader" name="files" title="Load File" runat="server" />  
                                    <%-- <asp:FileUpload runat="server"/> --%>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-5">
                                    <div class="form-group">
                                    <label>Book ID</label>
                                        <center>
                                            <div class="input-group"> <!-- Input group class will set these text box and button together(Button inside text box)-->
                                                 <asp:TextBox ID="bookid_txt" runat="server" class="form-control"></asp:TextBox>
                                                 <asp:Button class="form-control btn btn-dark" ID="button2" runat="server" Text="Go" OnClick="button2_Click"/>
                                            </div>
                                        </center>
                                    </div>
                            </div>
                            <div class="col-md-7">
                                     <div class="form-group">
                                     <label>Book Name</label>
                                         <center>
                                             <asp:TextBox ID="bookname_txt" runat="server" class="form-control"></asp:TextBox>
                                         </center>
                                    </div>
                            </div>


                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                    <div class="form-group">
                                    <label>Language</label>
                                        <center>
                                            <asp:DropDownList class="form-control" runat="server" ID="language_dropdown">
                                            <asp:ListItem Text="Sinhala" value="sinhala" />
                                            <asp:ListItem Text="English" value="english" />
                                            <asp:ListItem Text="Select" value="select" />

                                        </asp:DropDownList>
                                        </center>
                                    </div>
                            </div>
                            <div class="col-md-4">
                                     <div class="form-group">
                                     <label>Author Name</label>
                                         <center>
                                             <asp:TextBox ID="authorname_txt" runat="server" class="form-control"></asp:TextBox>
                                         </center>
                                    </div>
                            </div>

                             <div class="col-md-4">
                                     <div class="form-group">
                                     <label>Genre</label>
                                         <center>
                                            <asp:DropDownList class="form-control" runat="server" ID="genre_dropdown">
                                            <asp:ListItem Text="Action" value="action" />
                                            <asp:ListItem Text="Adventure" value="adventure" />
                                            <asp:ListItem Text="Comic" value="comic" />
                                                 <asp:ListItem Text="Select" value="comic" />

                                        </asp:DropDownList>
                                        </center>
                                    </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                     <div class="form-group">
                                        <label>Publisher Name</label>
                                            <asp:TextBox class="form-control" runat="server" ID="publishername_txt"></asp:TextBox>
                                    </div>
                            </div>
                            <div class="col-md-6">
                                     <div class="form-group">
                                     <label>Published Date</label>
                                         <center>
                                             <asp:TextBox TextMode="Date" ID="publisherdate_txt" runat="server" class="form-control"></asp:TextBox>
                                         </center>
                                    </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                    <div class="form-group">
                                    <label>Edition</label>
                                        <center>
                                            <asp:TextBox TextMode="Number" class="form-control" runat="server" ID="edition_txt"></asp:TextBox>
                                        </center>
                                    </div>
                            </div>
                            <div class="col-md-4">
                                     <div class="form-group">
                                     <label>Book Cost (Per Units)</label>
                                         <center>
                                             <asp:TextBox TextMode="Number" ID="bookcost_txt" runat="server" class="form-control"></asp:TextBox>
                                         </center>
                                    </div>
                            </div>

                             <div class="col-md-4">
                                     <div class="form-group">
                                     <label>Pages</label>
                                         <center>
                                            <asp:TextBox TextMode="Number" ID="pages_txt" runat="server" class="form-control"></asp:TextBox>
                                        </center>
                                    </div>
                            </div>

                        </div>

                         <div class="row">
                            <div class="col-md-4">
                                    <div class="form-group">
                                    <label>Actual Stock</label>
                                        <center>
                                            <asp:TextBox TextMode="Number" class="form-control" runat="server" ID="actualstock_txt"></asp:TextBox>
                                        </center>
                                    </div>
                            </div>
                            <div class="col-md-4">
                                     <div class="form-group">
                                     <label>Current Stock</label>
                                         <center>
                                             <asp:TextBox ReadOnly="false" TextMode="Number" ID="currentstock_txt" runat="server" class="form-control"></asp:TextBox>
                                         </center>
                                    </div>
                            </div>

                         <%--    <div class="col-md-4">
                                     <div class="form-group">
                                     <label>Issued Books</label>
                                         <center>
                                            <asp:TextBox ReadOnly="true" TextMode="Number" ID="issuedbooks_txt" runat="server" class="form-control"></asp:TextBox>
                                        </center>
                                    </div>
                            </div> --%>

                        </div>


                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Book Description</label>
                                        <center>
                                            <asp:TextBox id="bookdescription_txtarea" TextMode="multiline" Columns="50" Rows="3" runat="server" />
                                        </center>
                                    </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <asp:Button ID="btn" runat="server" Text="Add" class="btn btn-success form-control" OnClick="btn_Click"/>
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="Buttton1" runat="server" Text="Update" class="btn btn-warning form-control" OnClick="Buttton1_Click"/>
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="Buttron3" runat="server" Text="Delete" class="btn btn-danger form-control" OnClick="Buttron3_Click"/>
                            </div>
                        </div>

                    </div>
                </div>

                <a href="homepage.aspx"><< Back to Home </a>
            </div>

            <div class="col-md-7">
                <div class="card" style="border: solid 3px darkred">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>   
                                    <h2>Book List</h2>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:librarymanagementConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="gridview3" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="book_id">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="book_id" ReadOnly="True" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                                        <asp:BoundField DataField="genre" HeaderText="genre" SortExpression="genre" />
                                        <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                                        <asp:BoundField DataField="published_date" HeaderText="published_date" SortExpression="published_date" />
                                        <asp:BoundField DataField="language" HeaderText="language" SortExpression="language" />
                                        <asp:BoundField DataField="edition" HeaderText="edition" SortExpression="edition" />
                                        <asp:BoundField DataField="book_cost" HeaderText="book_cost" SortExpression="book_cost" />
                                        <asp:BoundField DataField="no_of_pages" HeaderText="no_of_pages" SortExpression="no_of_pages" />
                                        <asp:BoundField DataField="book_description" HeaderText="book_description" SortExpression="book_description" />
                                        <asp:BoundField DataField="actual_stock" HeaderText="actual_stock" SortExpression="actual_stock" />
                                        <asp:BoundField DataField="current_stock" HeaderText="current_stock" SortExpression="current_stock" />
                                        <asp:BoundField DataField="book_img_link" HeaderText="book_img_link" SortExpression="book_img_link" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
