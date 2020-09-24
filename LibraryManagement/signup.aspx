<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="LibraryManagement.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto"> <!-- mx-auto class is to center the whole division-->
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
                                    <h2>User Registration</h2>
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
                                    <asp:TextBox class="form-control" ID="full_name" runat="server" placeholder="Enter name here"></asp:TextBox><br />
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group>">
                                    <label>Date of Birth</label>
                                    <asp:TextBox class="form-control" ID="dob" runat="server" placeholder="Enter DOB here" TextMode="Date"></asp:TextBox><br />
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group>">
                                    <label>Contact Number</label>
                                    <asp:TextBox class="form-control" ID="contact_no" runat="server" placeholder="Enter contact no here" TextMode="Number"></asp:TextBox><br />
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group>">
                                    <label>Email Address</label>
                                    <asp:TextBox class="form-control" ID="email" runat="server" placeholder="Enter email here" TextMode="Email"></asp:TextBox><br />
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>State</label>
                                    <asp:DropDownList class="form-control" runat="server" ID="state">
                                        <asp:ListItem Text="Colombo" value="colombo" />
                                        <asp:ListItem Text="Kandy" value="kandy" />
                                        <asp:ListItem Text="Select" value="select" />

                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <asp:TextBox class="form-control" ID="city" runat="server" placeholder="Enter city here"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label>Pin Code</label>
                                <asp:TextBox class="form-control" ID="pin_code" runat="server" placeholder="Enter city here" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group>">
                                    <label>Full Address</label>
                                    <asp:TextBox class="form-control" ID="full_address" runat="server" placeholder="Enter full address here" TextMode="MultiLine"></asp:TextBox>
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
                            <div class="col-md-6">
                                <div class="form-group>">
                                    <label>User Id</label>
                                    <asp:TextBox class="form-control" ID="member_id" runat="server" placeholder="Enter prefered User Id here"></asp:TextBox><br />
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group>">
                                    <label>Password</label>
                                    <asp:TextBox class="form-control" ID="password" runat="server" placeholder="Enter prefered Password here"></asp:TextBox><br />
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
                                    <asp:Button runat="server" class="form-control btn btn-primary btn-block" Text="Sign Up" OnClick="Button_Click1" />
                                
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <p>Already Signed Up? <a href="userlogin.aspx">Log in here</a></p>
                                </center>
                            </div>
                        </div>

                    </div>
                </div>

                <a href="homepage.aspx"><< Back to Home </a>
            </div>
        </div>
    </div>

</asp:Content>
