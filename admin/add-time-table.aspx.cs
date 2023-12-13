using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class admin_add_time_table : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Subject();
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

    private void Bind_Subject()
    {
        dblsubject.Items.Clear();
        dblsubject.Items.Add(new ListItem("Please Select", " "));
        dblsubject.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT * FROM subject";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dblsubject.DataSource = cmd.ExecuteReader();
            dblsubject.DataTextField = "subject_name";
            dblsubject.DataValueField = "id";
            dblsubject.DataBind();
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
            if (dblsubject.SelectedItem.Text != "Please Select" && dblclass.SelectedItem.Text != "Please Select" && dblday.SelectedItem.Text != "Please Select" && dblsection.SelectedItem.Text != "Please Select")
            {

                string insert_query = "insert into timee_table(week_day,subject,section,class,create_date,create_time) values (@week_day,@subject,@section,@class,@create_date,@create_time) ";
                
                con.Open();
                SqlCommand insert_cmd = new SqlCommand(insert_query, con);

                insert_cmd.Parameters.AddWithValue("@section", dblsection.SelectedItem.Text);
                insert_cmd.Parameters.AddWithValue("@subject", dblsubject.SelectedItem.Text);
                insert_cmd.Parameters.AddWithValue("@class", dblclass.SelectedItem.Text);
                insert_cmd.Parameters.AddWithValue("@week_day", dblday.SelectedItem.Text);
                insert_cmd.Parameters.AddWithValue("@create_date", DateTime.Now.ToString("yyyy-MM-dd"));
                insert_cmd.Parameters.AddWithValue("@create_time", DateTime.Now.ToString("HH:mm:ss"));

                int success = insert_cmd.ExecuteNonQuery();

                if (success > 0)
                {
                    ShowMessage("Data has been saved.", MessageType.Success);
                    dblsection.SelectedIndex = 0;
                    dblsubject.SelectedIndex = 0;
                    dblclass.SelectedIndex = 0;
                    dblday.SelectedIndex = 0;
                }

            }
            else
            {
                ShowMessage("All * field are required.", MessageType.Error);
            }
        }
        catch (SqlException ex)
        {
            ShowMessage(ex.Message, MessageType.Error);
        }
    }


}