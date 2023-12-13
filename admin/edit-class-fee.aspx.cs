using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_edit_class_fee : System.Web.UI.Page
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
            BindSection();

            SqlDataReader dr_data = mst.Select_Operation("select * from class_fee where id='" + Request.QueryString[0] + "' ");
            if (dr_data.Read())
            {
                txtution.Text = dr_data["tution_fee"].ToString();
                txtlibrary.Text = dr_data["library_fee"].ToString();
                txtotal.Text = dr_data["total_fee"].ToString();
                txtlab.Text = dr_data["lab_fee"].ToString();
                dblclass.SelectedValue = dr_data["class"].ToString();

            }

            dr_data.Close();
        }
    }

    private void BindSection()
    {
        dblclass.Items.Clear();
        dblclass.Items.Add(new ListItem("Please Select", ""));
        dblclass.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "select max(class_name) as class_name from class group by class_name";
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
            dblclass.DataValueField = "class_name";
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

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txtution.Text.Length > 0 && txtlab.Text.Length > 0 && txtlibrary.Text.Length > 0 && txtotal.Text.Length > 0)
            {
                con.Open();

                string insert_category = "update class_fee set tution_fee=@tution_fee,class=@class,lab_fee=@lab_fee,library_fee=@library_fee,total_fee=@total_fee where id=@id";
                SqlCommand cmd_category = new SqlCommand(insert_category, con);

                cmd_category.Parameters.AddWithValue("@tution_fee", txtution.Text);
                cmd_category.Parameters.AddWithValue("@class", dblclass.SelectedValue);
                cmd_category.Parameters.AddWithValue("@library_fee", txtlibrary.Text);
                cmd_category.Parameters.AddWithValue("@total_fee", txtotal.Text);
                cmd_category.Parameters.AddWithValue("@lab_fee", txtlab.Text);
                cmd_category.Parameters.AddWithValue("@id", Request.QueryString[0]);

                int success = cmd_category.ExecuteNonQuery();
                if (success > 0)
                {
                    ShowMessage("Data has been updated.", MessageType.Success);

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