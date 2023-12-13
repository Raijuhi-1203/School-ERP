<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin.master" CodeFile="add-result.aspx.cs" Inherits="admin_add_result" %>

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
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Add Result
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />


                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">
                                        Class<span style="color: red">&nbsp;*</span>
                                    </label>
                                    <asp:DropDownList ID="dblclass" AutoPostBack="true" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server" OnSelectedIndexChanged="dblclass_SelectedIndexChanged">
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
                                    <label for="singin-password-2">
                                        Subject<span style="color: red">&nbsp;*</span>
                                    </label>
                                    <asp:DropDownList ID="dblsubject" AutoPostBack="true" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">
                                        Exam<span style="color: red">&nbsp;*</span>
                                    </label>
                                    <asp:DropDownList ID="dblexam" AutoPostBack="true" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">
                                        Student<span style="color: red">&nbsp;*</span>
                                    </label>
                                    <asp:DropDownList ID="dblstudent" AutoPostBack="true" AppendDataBoundItems="True" class="form-control" data-live-search="true" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">
                                        Grade<span style="color: red">&nbsp;*</span>
                                    </label>
                                    <asp:TextBox ID="txtgrade" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">
                                        Precentage<span style="color: red">&nbsp;*</span>
                                    </label>
                                    <asp:TextBox ID="txtpercentage" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">
                                        Max Mark<span style="color: red">&nbsp;*</span>
                                    </label>
                                    <asp:TextBox ID="txtmax" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">
                                        Min Mark<span style="color: red">&nbsp;*</span>
                                    </label>
                                    <asp:TextBox ID="txtmin" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-4 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <label for="singin-password-2">
                                        Obtain Mark<span style="color: red">&nbsp;*</span>
                                    </label>
                                    <asp:TextBox ID="txtobtain" runat="server" class="form-control" placeholder=""></asp:TextBox>
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

    <script language="Javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>


</asp:Content>



