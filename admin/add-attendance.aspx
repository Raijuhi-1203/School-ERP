<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin.master" CodeFile="add-attendance.aspx.cs" Inherits="admin_add_attendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>
        .mycheckbox input[type="checkbox"] {
            margin-right: 5px;
            font-size: 15px;
        }

        .mycheckbox input {
            /*margin-bottom: 12px;*/
            margin-top: 5px;
            margin-left: 10px !important;
            font-size: 15px;
        }

        .mycheckbox label {
            margin-left: 5px !important;
            font-size: 15px;
        }

        td {
            padding-right: 30px;
            padding-top: 10px
        }
    </style>


    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" style="text-decoration: none">Add Student Attendance
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Date<span style="color: red">&nbsp;*</span> </label>
                                    <asp:TextBox ID="txtdate" TextMode="Date" runat="server" class="form-control" placeholder="Bhala Kirana"></asp:TextBox>
                                </div>
                            </div>

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

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Student<span style="color: red">&nbsp;*</span> </label>
                                    <div class="body-box table-responsive" style="overflow-y: auto; overflow-x: auto; height: auto">
                                        <asp:CheckBoxList ID="chkproduct" runat="server" RepeatLayout="Table" CssClass="mycheckbox" RepeatDirection="Horizontal" Font-Size="Larger" RepeatColumns="3" CellSpacing="10"></asp:CheckBoxList>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="modal-footer">
                            <button type="submit" id="btnsave" runat="server" class="btn btn-success" onserverclick="btnsave_ServerClick">Submit & Save</button>
                        </div>
                    </div>
                </div>
            </div>


           

        </div>
    </div>


    <br />

    <script>
        $(document).ready(function () {
            $('#example1').DataTable({

                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                "ordering": false


            });
        });
        $(document).ready(function () {
            $('#example2').DataTable();
        });

    </script>

</asp:Content>


