using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_edit_exam : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    public enum MessageType { Success, Error, Info, Qarning };

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

            SqlDataReader dr_data = mst.Select_Operation("select * from exam where id='" + Request.QueryString[0] + "' ");
            if (dr_data.Read())
            {
                txtexam.Text = dr_data["exam_name"].ToString();
                txtsdate.Text = dr_data["start_time"].ToString();
                txtedate.Text = dr_data["end_time"].ToString();
                dblsection.SelectedItem.Text = dr_data["section"].ToString();
                dblclass.SelectedItem.Text = dr_data["class"].ToString();

            }

            dr_data.Close();

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
                string insert_query = "update exam set class=@class,section=@section,exam_name=@exam_name,start_time=@start_time,end_time=@end_time where id=@id";
                con.Open();
                SqlCommand insert_cmd = new SqlCommand(insert_query, con);

                insert_cmd.Parameters.AddWithValue("@exam_name", txtexam.Text);
                insert_cmd.Parameters.AddWithValue("@start_time", txtsdate.Text);
                insert_cmd.Parameters.AddWithValue("@end_time", txtedate.Text);
                insert_cmd.Parameters.AddWithValue("@class", dblclass.SelectedItem.Text);
                insert_cmd.Parameters.AddWithValue("@section", dblsection.SelectedItem.Text);
                insert_cmd.Parameters.AddWithValue("@id", Request.QueryString[0]);

                int success = insert_cmd.ExecuteNonQuery();
                if (success > 0)
                {
                    ShowMessage("Data has been update.", MessageType.Success);

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