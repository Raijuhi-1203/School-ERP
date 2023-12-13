<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin.master" CodeFile="add-time-table.aspx.cs" Inherits="admin_add_time_table" %>

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
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Add Time-table
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
                                        WeekDay<span style="color: red">&nbsp;*</span>
                                    </label>
                                    <asp:DropDownList ID="dblday" class="form-control" runat="server">
                                        <asp:ListItem>Monday</asp:ListItem>
                                        <asp:ListItem>Tuesday</asp:ListItem>
                                        <asp:ListItem>Wednesday</asp:ListItem>
                                        <asp:ListItem>Thrusday</asp:ListItem>
                                        <asp:ListItem>Friday</asp:ListItem>
                                        <asp:ListItem>Saturday</asp:ListItem>
                                    </asp:DropDownList>
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


