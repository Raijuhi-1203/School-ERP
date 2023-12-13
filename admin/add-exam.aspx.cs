using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class admin_add_exam : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    
    public enum MessageType { Success, Error, Info, Qarning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    
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
        if (txtexam.Text.Length > 0 && txtsdate.Text.Length > 0 && txtedate.Text.Length > 0)
        {
            try
            {
                string insert_query = "insert into exam(class,section,exam_name,start_time,end_time,create_date,create_time) values (@class,@section,@exam_name,@start_time,@end_time,@create_date,@create_time) ";
                con.Open();
                SqlCommand insert_cmd = new SqlCommand(insert_query, con);

                insert_cmd.Parameters.AddWithValue("@exam_name", txtexam.Text);
                insert_cmd.Parameters.AddWithValue("@start_time", txtsdate.Text);
                insert_cmd.Parameters.AddWithValue("@end_time", txtedate.Text);
                insert_cmd.Parameters.AddWithValue("@class", dblclass.SelectedItem.Text);
                insert_cmd.Parameters.AddWithValue("@section", dblsection.SelectedItem.Text);
                insert_cmd.Parameters.AddWithValue("@create_date", DateTime.Now.ToString("yyyy-MM-dd"));
                insert_cmd.Parameters.AddWithValue("@create_time", DateTime.Now.ToString("HH:mm:ss"));

                int success = insert_cmd.ExecuteNonQuery();
                if (success > 0)
                {
                    ShowMessage("Data has been saved.", MessageType.Success);

                    txtexam.Text = string.Empty;
                    txtsdate.Text = string.Empty;
                    txtedate.Text = string.Empty;
                    dblclass.SelectedIndex = 0;
                    dblsection.SelectedIndex = 0;

                }
            }
            catch (SqlException ex)
            {
                ShowMessage(ex.Message, MessageType.Error);
            }
            finally
            {
                con.Close();
            }
        }
        else
        {
            ShowMessage("All field is required.", MessageType.Success);
        }
    }

}