<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:Label ID="lblsmscredit" hidden runat="server" Text=""></asp:Label>

    <div class="row" style="margin-top: 20px;">

        <div class="col-lg-4 col-md-6">
            <div class="small-box" style="background-color: #3f51b5;">
                <div class="inner">
                    <h3>
                        <asp:Label ID="lblstudent" runat="server" Text="0"></asp:Label></h3>
                    <p style="color: white">Total Student</p>
                </div>
                <div class="icon">
                    <i class="fas fa-asterisk"></i>
                </div>

            </div>
        </div>

        <div class="col-lg-4 col-md-6">
            <div class="small-box" style="background-color: #4db6ac;">
                <div class="inner">
                    <h3>
                        <asp:Label ID="lblemployee" runat="server" Text="0"></asp:Label></h3>
                    <p style="color: white">Total Employee</p>
                </div>
                <div class="icon">
                    <i class="fas fa-expand-arrows-alt"></i>
                </div>

            </div>
        </div>

        <div class="col-lg-4 col-md-6">
            <div class="small-box" style="background-color: #9575cd;">
                <div class="inner">
                    <h3>
                        <asp:Label ID="lblcollection" runat="server" Text="0"></asp:Label></h3>
                    <p style="color: white">Total Collection</p>
                </div>
                <div class="icon">
                    <i class="fas fa-gift"></i>
                </div>

            </div>
        </div>

       

    </div>

   

</asp:Content>

