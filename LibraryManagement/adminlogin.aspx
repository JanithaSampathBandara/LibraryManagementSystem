<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="LibraryManagement.adminlogin" %>
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
                                    <img src="images/adminuser.png" width="150px"/>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h2>Admin Login</h2>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr/>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group>">
                                    <asp:TextBox class="form-control" ID="adminId" runat="server" placeholder="Admin Id"></asp:TextBox><br />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group>">
                                    <asp:TextBox class="form-control" ID="password" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
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
                                <div class="form-group>">
                                    <asp:Button class="form-control btn btn-success btn-block" ID="Button1" runat="server" name="login" Text="Log In" OnClick="Button1_Click" />
                                </div>
                            </div>
                            <!--
                            <div class="col">
                                <div class="form-group>">
                                <a href="signup.aspx"><input type =" button" class="form-control btn btn-primary btn-block" id="Button2" name="signup" value="Sign Up" /></a>
                                </div>
                            </div>
                            -->
                        </div>

                    </div>
                </div>

                <a href="homepage.aspx"><< Back to Home </a>
            </div>
        </div>
    </div>

</asp:Content>
