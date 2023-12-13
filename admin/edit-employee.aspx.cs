using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_edit_employee : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    DeliveryBoy bnc = new DeliveryBoy();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_State();
            Bind_Section();
            Bind_Class();

            SqlDataReader get_data = mst.Select_Operation("Select * from teacher where employee_id='" + Request.QueryString[0] + "' ");
            if (get_data.Read())
            {
                txt_name.Text = get_data["name"].ToString();
                txt_mobileno.Text = get_data["mobile_no"].ToString();
                txt_father.Text = get_data["father_name"].ToString();
                txt_mother.Text = get_data["mother_name"].ToString();
                txt_pincode.Text = get_data["pincode"].ToString();
                txt_experience.Text = get_data["experience"].ToString();
                txt_address_line_1.Text = get_data["address"].ToString();
                dbl_status.SelectedValue = get_data["status"].ToString();
                dbl_state.SelectedItem.Text = get_data["state"].ToString();
                dblclass.SelectedItem.Text = get_data["assign_class"].ToString();
                dblsection.SelectedItem.Text = get_data["assign_section"].ToString();
                dblrole.SelectedItem.Text = get_data["employee_role"].ToString();

                Bind_City();
                dbl_city.SelectedItem.Text = get_data["city"].ToString();

            }

            get_data.Close();
        }
    }

    private void Bind_State()
    {
        dbl_state.Items.Clear();
        dbl_state.Items.Add(new ListItem("Please Select", " "));
        dbl_state.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT * FROM state order by state_name asc";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dbl_state.DataSource = cmd.ExecuteReader();
            dbl_state.DataTextField = "state_name";
            dbl_state.DataValueField = "id";
            dbl_state.DataBind();
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

    private void Bind_City()
    {
        dbl_city.Items.Clear();
        dbl_city.Items.Add(new ListItem("Please Select", " "));
        dbl_city.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = "SELECT id,city_name FROM city where state_id='" + dbl_state.SelectedValue + "' order by city_name asc";
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dbl_city.DataSource = cmd.ExecuteReader();
            dbl_city.DataTextField = "city_name";
            dbl_city.DataValueField = "id";
            dbl_city.DataBind();
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

    protected void dbl_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dbl_state.SelectedItem.Text != "Please Select")
        {
            Bind_City();
        }
        else
        {
            ShowMessage("Please choose State.", MessageType.Error);
        }
    }

    protected void btnsaveAndnext_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txt_address_line_1.Text.Length > 0 && txt_mobileno.Text.Length > 0 && txt_name.Text.Length > 0 && txt_father.Text.Length > 0 && txt_mother.Text.Length > 0 && txt_pincode.Text.Length > 0 && dbl_state.SelectedItem.Text != "Please Select" && dbl_city.SelectedItem.Text != "Please Select")
            {
                int success = bnc.Edit_Employee(txt_name.Text, txt_mobileno.Text, txt_father.Text, txt_mother.Text, txt_experience.Text, txt_address_line_1.Text, dbl_state.SelectedItem.Text, dbl_city.SelectedItem.Text, txt_pincode.Text, dbl_status.SelectedValue, dblclass.SelectedItem.Text, dblsection.SelectedItem.Text, Request.QueryString[0],dblrole.SelectedValue);

                if (success > 0)
                {
                    ShowMessage("Data has been updated.", MessageType.Success);
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
}