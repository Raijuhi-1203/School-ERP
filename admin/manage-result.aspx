<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin.master" CodeFile="manage-result.aspx.cs" Inherits="admin_manage_result" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="alert" id="alert_container"></div>

    <div id="accordion-container">
        <div class="panel-group" id="accordion">

            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Manage Holiday</a>
                    </h4>
                </div>

                <div id="collapsetwo" class="panel-collapse collapse in">
                    <div class="panel panel-white">
                        <div class="panel-body">
                            <br />
                            <div class="body-box table-responsive">
                                <table id="example1" class="table table-bordered table-striped">
                                    <thead>
                                        <tr>
                                            <th>Class</th>
                                            <th>Exam</th>
                                            <th>Student</th>
                                            <th>Subject</th>
                                            <th>Grade</th>
                                            <th>Percentage</th>
                                            <th>Max Mark</th>
                                            <th>Min Mark</th>
                                            <th>Obtain Mark</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                        </tr>
                                    </tfoot>
                                    <tbody id="tlist" runat="server">

                                        <asp:Repeater ID="rpt_data" runat="server">
                                            <ItemTemplate>

                                                <tr>
                                                    <td>
                                                        <%# Eval("class") %> (<%# Eval("section") %>)
                                                    </td>
                                                    <td>
                                                        <%# Eval("exam_name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("student_name") %> (<%# Eval("student_id") %>)
                                                    </td>
                                                    <td>
                                                        <%# Eval("subject") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("grade") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("percentage") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("max_mark") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("min_mark") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("obtain_mark") %>
                                                    </td>
                                                    <td>
                                                        <a class="link-primary" href="edit-result.aspx?ref=<%#  Eval("id") %>" title="Edit"><i class="fa fa-edit"></i></a>
                                                        <a class="link-danger" href="#" data-toggle="modal" data-target="#Del<%#  Eval("id") %>" title="Delete"><i class="fa fa-trash"></i></a>
                                                    </td>
                                                </tr>

                                                <%-- Delete Modal--%>


                                                <div class="modal fade" id="Del<%# Eval("id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Confirm Delete</h4>
                                                            </div>

                                                            <div class="panel-body">
                                                                <asp:Label ID="lblrowdeleteid" hidden runat="server" Text='<%# Eval("id") %>'></asp:Label>

                                                                <div class="col-md-12">
                                                                    <div class="form-group">
                                                                        <center>
                                                                            <label style="font-size: 25px;">Are you sure you want to delete?</label>
                                                                        </center>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="modal-footer">
                                                                <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                                                                <asp:LinkButton ID="lnkdelete" CommandName="btndelete" runat="server" class="btn btn-danger" Text="Yes"></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>


                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>


    <script>
        $(document).ready(function () {
            $('#example1').DataTable({
                dom: 'lBfrtip',
                buttons: [
                    'excel', 'pdf', 'print',
                ],
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                "ordering": false,

            });
        });
        $(document).ready(function () {
            $('#example2').DataTable();
        });

    </script>

</asp:Content>


