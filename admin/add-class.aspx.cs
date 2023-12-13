using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_add_service : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindSection();
        }
    }

    private void BindSection()
    {
        dblsection.Items.Clear();
        dblsection.Items.Add(new ListItem("Please Select", ""));
        dblsection.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "select section_name from section Order by section_name asc";
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
            dblsection.DataValueField = "section_name";
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
            if (txtclass.Text.Length > 0)
            {
                con.Open();

                string insert_category = "insert into class(class_name,section_name) values (@class_name,@section_name)";
                SqlCommand cmd_category = new SqlCommand(insert_category, con);


                cmd_category.Parameters.AddWithValue("@class_name", txtclass.Text);
                cmd_category.Parameters.AddWithValue("@section_name", dblsection.SelectedValue);


                int success = cmd_category.ExecuteNonQuery();
                if (success > 0)
                {
                    ShowMessage("Data has been saved.", MessageType.Success);

                    txtclass.Text = string.Empty;
                }
                else
                {
                    ShowMessage("Something went wrong.", MessageType.Warning);
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