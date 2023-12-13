using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_add_attendance : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Class();
            Bind_Section();
            
        }
    }

    private void Bind_Class()
    {
        dblclass.Items.Clear();
        dblclass.Items.Add(new ListItem("Please Select", " "));
        dblclass.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT max(id) as id,max(class_name) as class_name FROM class group by class_name";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dblclass.DataSource = cmd.ExecuteReader();
            dblclass.DataTextField = "class_name";
            dblclass.DataValueField = "id";
            dblclass.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    private void Bind_Section()
    {
        dblsection.Items.Clear();
        dblsection.Items.Add(new ListItem("Please Select", " "));
        dblsection.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT * FROM section";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dblsection.DataSource = cmd.ExecuteReader();
            dblsection.DataTextField = "section_name";
            dblsection.DataValueField = "id";
            dblsection.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            
            int totalChecked = chkproduct.Items.Cast<ListItem>().Count(li => li.Selected);

            if (totalChecked > 0)
            {
                for (int i = 0; i < chkproduct.Items.Count; i++)
                {

                    if (chkproduct.Items[i].Selected == true)
                    {
                        int checkItemForShop = mst.Count_data("Select Count(id) from student_attendance Where student_id='" + chkproduct.Items[i].Value + "' AND date='" + txtdate.Text + "' ");

                        if (checkItemForShop < 1)
                        {
                            con.Open();

                            string insert_category = "insert into student_attendance(create_date,create_time,student_name,student_id,date,class,section,status) values (@create_date,@create_time,@student_name,@student_id,@date,@class,@section,@status)";
                            SqlCommand cmd_category = new SqlCommand(insert_category, con);

                            cmd_category.Parameters.AddWithValue("@student_name", chkproduct.Items[i].Text);
                            cmd_category.Parameters.AddWithValue("@date", txtdate.Text);
                            cmd_category.Parameters.AddWithValue("@class", dblclass.SelectedItem.Text);
                            cmd_category.Parameters.AddWithValue("@student_id", chkproduct.Items[i].Value);
                            cmd_category.Parameters.AddWithValue("@section", dblsection.SelectedItem.Text);
                            cmd_category.Parameters.AddWithValue("@status", "Present");
                            cmd_category.Parameters.AddWithValue("@create_date", DateTime.Now.ToString("yyyy-MM-dd"));
                            cmd_category.Parameters.AddWithValue("@create_time", DateTime.Now.ToString("HH:mm:ss"));

                            int success = cmd_category.ExecuteNonQuery();
                            if (success > 0)
                            {
                                //ShowMessage("Data has been saved.", MessageType.Success);
                                mst.PopulateCheckbox(chkproduct, "student_id", "name", "Select student_id,name from student Where assign_class='" + dblclass.SelectedItem.Text + "'");
                                //txtdate.Text = string.Empty;
                                //dblclass.SelectedIndex = 0;
                                //dblsection.SelectedIndex = 0;

                            }
                            else
                            {
                                ShowMessage("Something went wrong.", MessageType.Warning);
                            }
                            con.Close();
                        }

                    }

                    if(chkproduct.Items[i].Selected == false)
                    {
                        con.Open();

                        string insert_category = "insert into student_attendance(create_date,create_time,student_name,student_id,date,class,section,status) values (@create_date,@create_time,@student_name,@student_id,@date,@class,@section,@status)";
                        SqlCommand cmd_category = new SqlCommand(insert_category, con);

                        cmd_category.Parameters.AddWithValue("@student_name", chkproduct.Items[i].Text);
                        cmd_category.Parameters.AddWithValue("@date", txtdate.Text);
                        cmd_category.Parameters.AddWithValue("@class", dblclass.SelectedItem.Text);
                        cmd_category.Parameters.AddWithValue("@student_id", chkproduct.Items[i].Value);
                        cmd_category.Parameters.AddWithValue("@section", dblsection.SelectedItem.Text);
                        cmd_category.Parameters.AddWithValue("@status", "Absent");
                        cmd_category.Parameters.AddWithValue("@create_date", DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd_category.Parameters.AddWithValue("@create_time", DateTime.Now.ToString("HH:mm:ss"));

                        int success = cmd_category.ExecuteNonQuery();
                        if (success > 0)
                        {
                            ShowMessage("Data has been saved.", MessageType.Success);
                            mst.PopulateCheckbox(chkproduct, "student_id", "name", "Select student_id,name from student Where assign_class='" + dblclass.SelectedItem.Text + "'");
                            //txtdate.Text = string.Empty;
                            //dblclass.SelectedIndex = 0;
                            //dblsection.SelectedIndex = 0;

                        }
                        else
                        {
                            ShowMessage("Something went wrong.", MessageType.Warning);
                        }
                        con.Close();
                    }

                }
            }
            else
            {
                ShowMessage("All field are required.", MessageType.Error);
            }

        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message, MessageType.Error);
        }
    }

    protected void dblclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        mst.PopulateCheckbox(chkproduct, "student_id", "name", "Select student_id,name from student Where assign_class='" + dblclass.SelectedItem.Text + "'");
    }

}