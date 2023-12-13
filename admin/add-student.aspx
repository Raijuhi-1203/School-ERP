<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="add-student.aspx.cs" Inherits="auth_add_delivery_boy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <style>
        .error {
            color: red
        }
    </style>

    <div class="alert" id="alert_container"></div>

    <asp:Label ID="lbl_id" hidden runat="server" Text=""></asp:Label>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Basic Details
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <div class="col-md-3 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-email-2">Name <span style="color: red">*</span></label>
                                    <asp:TextBox ID="txt_name" onkeypress="return isAlphaKey(event)" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-email-2">Mobile No <span style="color: red">*</span></label>
                                    <asp:TextBox ID="txt_mobileno" TextMode="Phone" MaxLength="10" onkeypress="return isNumberKey(event)" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>



                            <div class="col-md-3 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-email-2">Father's Name <span style="color: red">*</span></label>
                                    <asp:TextBox ID="txt_father" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-email-2">Mother's Name <span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtx_mother" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>



                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">
                                        Class<span style="color: red">&nbsp;*</span>
                                    </label>
                                    <asp:DropDownList ID="dblclass" AutoPostBack="true" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">
                                        Section<span style="color: red">&nbsp;*</span>
                                    </label>
                                    <asp:DropDownList ID="dblsection" AutoPostBack="true" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-email-2">Status <span style="color: red">*</span></label>
                                    <asp:DropDownList ID="dbl_status" class="form-control" runat="server">
                                        <asp:ListItem>Active</asp:ListItem>
                                        <asp:ListItem>Deactive</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>


            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2" style="text-decoration: none">Address Details
                        </a>
                    </h4>
                </div>
                <div id="collapse2" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <contenttemplate>

                                    <div class="row">

                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label for="singin-password-2">Address<span style="color: red">&nbsp;*</span></label>
                                                <asp:TextBox ID="txt_address_line_1" TextMode="MultiLine" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-4 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label for="singin-password-2">
                                                    State<span style="color: red">&nbsp;*</span>
                                                </label>
                                                <asp:DropDownList ID="dbl_state" AutoPostBack="true" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server" OnSelectedIndexChanged="dbl_state_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-md-4 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label for="singin-password-2">
                                                    City<span style="color: red">&nbsp;*</span>
                                                </label>
                                                <asp:DropDownList ID="dbl_city" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>


                                        <div class="col-md-4 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <label for="singin-password-2">Pincode <span style="color: red">&nbsp;*</span> </label>
                                                <asp:TextBox ID="txt_pincode" MaxLength="6" onkeypress="return isNumberKey(event)" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                </contenttemplate>
                            </asp:UpdatePanel>


                        </div>

                        <div class="modal-footer">
                            <button type="button" id="btnsaveAndnext" runat="server" class="btn btn-success" onserverclick="btnsaveAndnext_ServerClick">Submit</button>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>

    <script language="Javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>


</asp:Content>

