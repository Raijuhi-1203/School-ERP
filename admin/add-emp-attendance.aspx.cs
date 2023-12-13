using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_add_emp_attendance : System.Web.UI.Page
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
            mst.PopulateCheckbox(chkproduct, "employee_id", "name", "Select employee_id,name from teacher Where status='Active'");

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
                        int checkItemForShop = mst.Count_data("Select Count(id) from employee_attendance Where employee_id='" + chkproduct.Items[i].Value + "' AND date='" + txtdate.Text + "' ");

                        if (checkItemForShop < 1)
                        {
                            con.Open();

                            string insert_category = "insert into employee_attendance(create_date,create_time,employee_name,employee_id,date,status) values (@create_date,@create_time,@employee_name,@employee_id,@date,@status)";
                            SqlCommand cmd_category = new SqlCommand(insert_category, con);

                            cmd_category.Parameters.AddWithValue("@employee_name", chkproduct.Items[i].Text);
                            cmd_category.Parameters.AddWithValue("@date", txtdate.Text);
                            cmd_category.Parameters.AddWithValue("@employee_id", chkproduct.Items[i].Value);
                            cmd_category.Parameters.AddWithValue("@status", "Present");
                            cmd_category.Parameters.AddWithValue("@create_date", DateTime.Now.ToString("yyyy-MM-dd"));
                            cmd_category.Parameters.AddWithValue("@create_time", DateTime.Now.ToString("HH:mm:ss"));

                            int success = cmd_category.ExecuteNonQuery();
                            if (success > 0)
                            {
                                ShowMessage("Data has been saved.", MessageType.Success);
                                mst.PopulateCheckbox(chkproduct, "employee_id", "name", "Select employee_id,name from teacher Where status='Active'");

                            }
                            else
                            {
                                ShowMessage("Something went wrong.", MessageType.Warning);
                            }
                            con.Close();
                        }

                    }

                    if (chkproduct.Items[i].Selected == false)
                    {
                        con.Open();

                        string insert_category = "insert into employee_attendance(create_date,create_time,employee_name,employee_id,date,status) values (@create_date,@create_time,@employee_name,@employee_id,@date,@status)";
                        SqlCommand cmd_category = new SqlCommand(insert_category, con);

                        cmd_category.Parameters.AddWithValue("@employee_name", chkproduct.Items[i].Text);
                        cmd_category.Parameters.AddWithValue("@date", txtdate.Text);
                        cmd_category.Parameters.AddWithValue("@employee_id", chkproduct.Items[i].Value);
                        cmd_category.Parameters.AddWithValue("@status", "Absent");
                        cmd_category.Parameters.AddWithValue("@create_date", DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd_category.Parameters.AddWithValue("@create_time", DateTime.Now.ToString("HH:mm:ss"));

                        int success = cmd_category.ExecuteNonQuery();
                        if (success > 0)
                        {
                            ShowMessage("Data has been saved.", MessageType.Success);
                            mst.PopulateCheckbox(chkproduct, "employee_id", "name", "Select employee_id,name from teacher Where status='Active'");

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

    
}