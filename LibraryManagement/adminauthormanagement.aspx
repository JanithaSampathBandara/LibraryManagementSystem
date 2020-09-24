<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminauthormanagement.aspx.cs" Inherits="LibraryManagement.adminauthormanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
    // $('#myTable').DataTable();
} );
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="card" style="border: solid 3px darkred">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h2>Author Details</h2>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="images/writer.png" width="100px" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-5">
                                <div class="form-group">
                                    <label>Author ID</label>
                                    <div class="input-group"> <!-- Input group class will set these text box and button together(Button inside text box)-->
                                        <asp:TextBox ID="textboxs" runat="server" class="form-control"></asp:TextBox>
                                        <asp:Button class="form-control btn btn-dark" ID="buttona" runat="server" Text="Go" OnClick="buttona_Click"/>
                                    </div>
                                    
                                </div>
                            </div>
                            <div class="col-7">
                                <div class="form-group">
                                    <label>Author Name</label>
                                    <asp:TextBox ID="textbox1" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button class=" form-control btn btn-success" ID="button1" runat="server" Text="Add" OnClick="button1_Click"/>
                            </div>
                            <div class="col-4">
                                <asp:Button class="form-control btn btn-primary" ID="button2" runat="server" Text="Update" OnClick="button2_Click"/>
                            </div>
                            <div class="col-4">
                                <asp:Button class="form-control btn btn-danger" ID="button3" runat="server" Text="Delete" OnClick="button3_Click"/>
                            </div>
                        </div>

                        
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="card" style="border: solid 3px darkred">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>   
                                    <h2>Author List</h2>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:librarymanagementConnectionString %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="gridview1" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                        <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
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
