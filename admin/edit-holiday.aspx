<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin.master" CodeFile="edit-holiday.aspx.cs" Inherits="admin_edit_holiday" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row"></div>
    <br />
    <a href="manage-holiday.aspx" class="btn btn-success" runat="server"><i class="fa fa-plus"></i>&nbsp;Manage Holiday</a>
    <br />


    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Edit Holiday
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Date<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtdate" TextMode="Date" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Holiday<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtmsg"  runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="modal-footer">
                            <button type="button" id="btnsave" runat="server" class="btn btn-success" onserverclick="btnsave_ServerClick">Submit</button>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
