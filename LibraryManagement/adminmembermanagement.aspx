<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="LibraryManagement.adminmembermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            console.log("sasa");
            $("#texting").keypress(function () {
                console.log("sasaasasa");
            });

        });
   
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
                                    <h2>Member Details</h2>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="images/generaluser.png" width="100px" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                    <div class="form-group">
                                    <label>Member ID</label>
                                        <center>
                                            <div class="input-group"> <!-- Input group class will set these text box and button together(Button inside text box)-->
                                               <%--   <input type="text" id="texting" name="memberid_txt" class="form-control"  runat="server" /> --%>
                                                <asp:TextBox ID="memberid_txt" runat="server" class="form-control"></asp:TextBox> 
                                                 <asp:Button class="form-control btn btn-dark" ID="button2" runat="server" Text="Go" OnClick="button2_Click"/>
                                            </div>
                                        </center>
                                    </div>
                            </div>
                            <div class="col-md-4">
                                     <div class="form-group">
                                     <label>Full Name</label>
                                         <center>
                                             <asp:TextBox ReadOnly="true" ID="fullname_txt" runat="server" class="form-control"></asp:TextBox>
                                         </center>
                                    </div>
                            </div>

                            <div class="col-md-4">
                                <label>Account Status</label>
                                <div class="form-group">
                                      <div class="input-group"> <!-- Input group class will set these text box and button together(Button inside text box)-->
                                           <asp:TextBox ReadOnly="true" ID="accountstatus_txt" runat="server" class="form-control"></asp:TextBox>
                                           
                                         
                                          <%-- <asp:Button class="form-control btn btn-success" ID="button1" runat="server" Text="S"><i class="fas fa-check-circle"></i></asp:Button>  -->
                                          Italic tag from fontawesome is only works with LinkButton. So have to replace the normal aspButton into LinkButton --%>
                                         
                                           <asp:LinkButton class="form-control btn btn-success mr-1" ID="button3" runat="server" Text="P" OnClick="button3_Click" > <i class="fas fa-check-circle"></i> </asp:LinkButton>
                                           <asp:LinkButton class="form-control btn btn-warning mr-1" ID="LinkButton1" runat="server" Text="P" OnClick="LinkButton1_Click" > <i class="fas fa-pause-circle"></i> </asp:LinkButton>
                                          <asp:LinkButton class="form-control btn btn-danger" ID="LinkButton2" runat="server" Text="P" OnClick="LinkButton2_Click" > <i class="far fa-times-circle"></i> </asp:LinkButton>
                                          
                                      </div>
                                    </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                    <div class="form-group">
                                    <label>DOB</label>
                                        <center>
                                            <asp:TextBox TextMode="Date" ReadOnly="true" ID="dob_txt" runat="server" class="form-control"></asp:TextBox>
                                        </center>
                                    </div>
                            </div>
                            <div class="col-md-4">
                                     <div class="form-group">
                                     <label>Contact Number</label>
                                         <center>
                                             <asp:TextBox TextMode="Number" ReadOnly="true" ID="contactno_txt" runat="server" class="form-control"></asp:TextBox>
                                         </center>
                                    </div>
                            </div>

                             <div class="col-md-4">
                                     <div class="form-group">
                                     <label>Email</label>
                                         <center>
                                             <asp:TextBox TextMode="Email" ReadOnly="true" ID="email_txt" runat="server" class="form-control"></asp:TextBox>
                                         </center>
                                    </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                     <div class="form-group">
                                        <label>State</label>
                                            <asp:DropDownList ReadOnly="true" class="form-control" runat="server" ID="state_dropdown">
                                            <asp:ListItem Text="Colombo" value="colombo" />
                                            <asp:ListItem Text="Kandy" value="kandy" />
                                            <asp:ListItem Text="Select" value="select" />

                                        </asp:DropDownList>
                                    </div>
                            </div>
                            <div class="col-md-4">
                                     <div class="form-group">
                                     <label>City</label>
                                         <center>
                                             <asp:TextBox ReadOnly="true" ID="city_txt" runat="server" class="form-control"></asp:TextBox>
                                         </center>
                                    </div>
                            </div>

                            <div class="col-md-4">
                                     <div class="form-group">
                                     <label>Pin Code</label>
                                         <center>
                                             <asp:TextBox TextMode="Number" ReadOnly="true" ID="pincode_txt" runat="server" class="form-control"></asp:TextBox>
                                         </center>
                                    </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Full Postal Address</label>
                                        <center>
                                            <asp:TextBox ReadOnly="true" ID="address_txt" runat="server" class="form-control"></asp:TextBox>
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
                            <div class="col-md-6 mx-auto">
                                <asp:Button ReadOnly="false" ID="btn" runat="server" Text="Delete User Permanently" class="btn btn-danger form-control" OnClick="btn_Click"/>
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
                                    <h2>Member List</h2>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:librarymanagementConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="gridview3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="full_name" HeaderText="full_name" SortExpression="full_name" />
                                        <asp:BoundField DataField="dob" HeaderText="dob" SortExpression="dob" />
                                        <asp:BoundField DataField="contact_no" HeaderText="contact_no" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="state" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                                        <asp:BoundField DataField="pin_code" HeaderText="pin_code" SortExpression="pin_code" />
                                        <asp:BoundField DataField="full_address" HeaderText="full_address" SortExpression="full_address" />
                                        <asp:BoundField DataField="member_id" HeaderText="member_id" SortExpression="member_id" />
                                        <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                                        <asp:BoundField DataField="account_status" HeaderText="account_status" SortExpression="account_status" />
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
