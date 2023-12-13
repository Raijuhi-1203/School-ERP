<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin.master" CodeFile="manage-employee.aspx.cs" Inherits="admin_manage_employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="alert" id="alert_container"></div>

    <div id="accordion-container" style="margin-top: 10px">
        <div class="panel-group" id="accordion">


            <div class="panel panel-default">

                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsetwo" style="text-decoration: none">Manage Employee</a>
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
                                            <th>#</th>
                                            <th>Name</th>
                                            <th>Contact</th>
                                            <th>Address</th>
                                            <th>Experience</th>
                                            <th>Role</th>
                                            <th>Class</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                        </tr>
                                    </tfoot>
                                    <tbody id="tlist" runat="server">

                                        <asp:Repeater ID="rptbinddata" runat="server" OnItemCommand="rptbinddata_ItemCommand" OnItemDataBound="rptbinddata_ItemDataBound">
                                            <itemtemplate>

                                                <tr>
                                                    <td>
                                                        <%# Eval("employee_id") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("mobile_no") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("address") %>, <%# Eval("city") %>, <%# Eval("state") %>-<%# Eval("pincode") %>
                                                    </td>

                                                    <td>
                                                        <%# Eval("experience") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("employee_role") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("assign_class") %> (<%# Eval("assign_section") %>)
                                                    </td>

                                                    <td>

                                                        <a class="link-primary" href="edit-student.aspx?ref=<%# Eval("employee_id") %>" title="Edit Student"><i class="fas fa-edit"></i></a>
                                                        <a class="link-danger" href="#" data-toggle="modal" data-target="#Del<%#  Eval("employee_id") %>" title="Delete"><i class="fa fa-trash"></i></a>
                                                    </td>

                                                </tr>




                                                <%-- Delete Modal--%>

                                                <div class="modal fade" id="Del<%# Eval("employee_id") %>" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">

                                                    <div class="modal-dialog">
                                                        <div class="modal-content">
                                                            <div class="modal-header">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="myModalLabel2">Confirm Delete</h4>
                                                            </div>

                                                            <div class="panel-body">

                                                                <asp:Label ID="lbldeletestudent_id" hidden runat="server" Text='<%# Eval("employee_id") %>'></asp:Label>

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


                                            </itemtemplate>
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
                "ordering": false
            });
        });
        $(document).ready(function () {
            $('#example2').DataTable();
        });
    </script>



</asp:Content>
