<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="LibraryManagement.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card" style="border:solid 3px darkred">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="images/generaluser.png" width="150px"/>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h2>Your Profile</h2>
                                    <span>Account Status : </span>
                                    <asp:Label ID="Label1" runat="server" class="badge badge-pill badge-success" Text="Active"></asp:Label>
                                    
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr/>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group>">
                                    <label>Full Name</label>
                                    <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="Enter name here"></asp:TextBox><br />
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group>">
                                    <label>Date of Birth</label>
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Enter DOB here" TextMode="Date"></asp:TextBox><br />
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group>">
                                    <label>Contact Number</label>
                                    <asp:TextBox class="form-control" ID="TextBox3" runat="server" placeholder="Enter contact no here" TextMode="Number"></asp:TextBox><br />
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group>">
                                    <label>Email Address</label>
                                    <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="Enter email here" TextMode="Email"></asp:TextBox><br />
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>State</label>
                                    <asp:DropDownList class="form-control" runat="server" ID="DropDownList1">
                                        <asp:ListItem Text="Colombo" value="colombo" />
                                        <asp:ListItem Text="Kandy" value="kandy" />
                                        <asp:ListItem Text="Select" value="select" />

                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Enter city here"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label>Pin Code</label>
                                <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="Enter city here" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group>">
                                    <label>Full Address</label>
                                    <asp:TextBox class="form-control" ID="TextBox4" runat="server" placeholder="Enter full address here" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr/>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <span class="badge badge-pill badge-primary">User Credentials</span>

                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group>">
                                    <label>User Id</label>
                                    <asp:TextBox ReadOnly="true" class="form-control" ID="TextBox6" runat="server"></asp:TextBox><br />
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group>">
                                    <label>Old Password</label>
                                    <asp:TextBox ReadOnly="true" class="form-control" ID="TextBox9" runat="server" TextMode="Password"></asp:TextBox><br />
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group>">
                                    <label>New Password</label>
                                    <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="Enter New Password here"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <hr/>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6 mx-auto">
                                <div class="form-group>">
                                <input type =" button" class="form-control btn btn-primary btn-block" id="Button2" name="update" value="Update" />
                                </div>
                            </div>
                        </div>

         <!--               <div class="row">
                            <div class="col">
                                <center>
                                    <p>Already Signed Up? <a href="userlogin.aspx">Log in here</a></p>
                                </center>
                            </div>
                        </div>
        -->
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="card" style="border:solid 3px darkred">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="images/books1.png" width="100px"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h2>Your Issued Books</h2>
                                    <span class="badge badge-pill badge-primary">Your Books Info</span>
                                </center>
                            </div>
                        </div>
                        <div class="row>">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
