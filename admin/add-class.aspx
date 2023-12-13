<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="add-class.aspx.cs" Inherits="auth_add_service" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:Label ID="lblcategoryidtemp" hidden runat="server" Text=""></asp:Label>
    <asp:Label ID="lblcategoryidplus" hidden runat="server" Text=""></asp:Label>
    <asp:Label ID="lblcategoryid" hidden runat="server" Text=""></asp:Label>



    <div class="row"></div>
    <br />
    <a href="manage-class.aspx" class="btn btn-success" runat="server"><i class="fa fa-plus"></i>&nbsp;Manage Class</a>
    <br />


    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Add Class
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Class<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtclass" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Section<span style="color: red">&nbsp;*</span> </label>
                                    <asp:DropDownList ID="dblsection" AppendDataBoundItems="True" class="selectpicker form-control" data-live-search="true" runat="server">
                                        
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" id="btnsave" runat="server" class="btn btn-success" onserverclick="btnsave_ServerClick">Submit & Save</button>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>

