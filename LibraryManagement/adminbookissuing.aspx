<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookissuing.aspx.cs" Inherits="LibraryManagement.adminbookissuing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-5">
                <div class="card" style="border: solid 3px darkred">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h2>Book Issuing</h2>
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
                            <div class="col-6">
                                    <div class="form-group">
                                    <label>Member ID</label>
                                        <center>
                                            <asp:TextBox ID="textbox1" runat="server" class="form-control"></asp:TextBox>
                                        </center>
                                    </div>
                            </div>
                            <div class="col-6">
                                     <div class="form-group">
                                     <label>Book ID</label>
                                         <center>
                                                <div class="input-group"> <!-- Input group class will set these text box and button together(Button inside text box)-->
                                                    <asp:TextBox ID="textboxs" runat="server" class="form-control"></asp:TextBox>
                                                    <asp:Button class="form-control btn btn-dark" ID="buttona" runat="server" Text="Go"/>
                                                </div>
                                         </center>
                                    </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                    <div class="form-group">
                                    <label>Member Name</label>
                                        <center>
                                            <asp:TextBox ReadOnly="true" ID="textbox2" runat="server" class="form-control"></asp:TextBox>
                                        </center>
                                    </div>
                            </div>
                            <div class="col-6">
                                     <div class="form-group">
                                     <label>Book Name</label>
                                         <center>
                                             <asp:TextBox ReadOnly="true" ID="textbox3" runat="server" class="form-control"></asp:TextBox>
                                         </center>
                                    </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                    <div class="form-group">
                                    <label>Start Date</label>
                                        <center>
                                            <asp:TextBox ID="textbox4" runat="server" class="form-control" TextMode="Date"></asp:TextBox>
                                        </center>
                                    </div>
                            </div>
                            <div class="col-6">
                                     <div class="form-group">
                                     <label>End Date</label>
                                         <center>
                                             <asp:TextBox ID="textbox5" runat="server" class="form-control" TextMode="Date"></asp:TextBox>
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
                            <div class="col-6">
                                <asp:Button ID="btn" runat="server" Text="Issue" class="btn btn-success form-control"/>
                            </div>
                            <div class="col-6">
                                <asp:Button ID="Button1" runat="server" Text="Return" class="btn btn-primary form-control"/>
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
                                    <h2>Issued Book List</h2>
                                </center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
