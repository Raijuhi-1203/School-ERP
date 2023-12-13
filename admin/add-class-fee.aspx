<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin.master" CodeFile="add-class-fee.aspx.cs" Inherits="admin_add_class_fee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row"></div>
    <br />
    <a href="manage-class-fee.aspx" class="btn btn-success" runat="server"><i class="fa fa-plus"></i>&nbsp;Manage Class-Fee</a>
    <br />


    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Add Class-Fee
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
                                    <asp:DropDownList ID="dblclass" AppendDataBoundItems="True" class="selectpicker form-control" data-live-search="true" runat="server">
                                    </asp:DropDownList>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Tution Fee<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtution" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Lab Fee<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtlab" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Library Fee<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtlibrary" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Total Fee<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtotal" runat="server" class="form-control" placeholder=""></asp:TextBox>
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

