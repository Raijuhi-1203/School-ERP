using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_add_user : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    DeliveryBoy bnc = new DeliveryBoy();
    Encrypt enc = new Encrypt();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_State();
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

    private void GenerateId()
    {
        SqlDataReader readiddr = mst.Select_Operation("SELECT Max(id) as id FROM teacher");
        if (readiddr.Read())
        {
            if (readiddr["id"] == DBNull.Value)
            {
                lbl_id.Text = "EMP-1";
            }
            else
            {
                lbl_id.Text = "EMP-" + Convert.ToString(Convert.ToInt32(readiddr["id"].ToString()) + 1);
            }
        }
        else
        {
            lbl_id.Text = "EMP-1";
        }

        readiddr.Close();
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
            if (txt_address_line_1.Text.Length > 0 && txt_mobileno.Text.Length > 0 && txt_name.Text.Length > 0 && txt_father.Text.Length > 0 && txt_mother.Text.Length > 0 && txt_experience.Text.Length > 0 && txt_pincode.Text.Length > 0 && dbl_state.SelectedItem.Text != "Please Select" && dbl_city.SelectedItem.Text != "Please Select")
            {
                GenerateId();

                int success = bnc.Add_Employee(lbl_id.Text, txt_name.Text, txt_mobileno.Text, txt_father.Text, txt_mother.Text, txt_experience.Text, txt_address_line_1.Text, dbl_state.SelectedItem.Text, dbl_city.SelectedItem.Text, txt_pincode.Text, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("hh:mm tt"), dbl_status.SelectedValue, dblclass.SelectedItem.Text, dblsection.SelectedItem.Text, dblrole.SelectedValue);

                if (success > 0)
                {
                    ShowMessage("Data has been saved.", MessageType.Success);

                    txt_name.Text = string.Empty;
                    txt_experience.Text = string.Empty;
                    txt_mobileno.Text = string.Empty;
                    txt_father.Text = string.Empty;
                    txt_mother.Text = string.Empty;
                    txt_pincode.Text = string.Empty;
                    txt_address_line_1.Text = string.Empty;

                    dbl_status.SelectedIndex = 0;
                    dbl_state.SelectedIndex = 0;
                    dblclass.SelectedIndex = 0;
                    dblsection.SelectedIndex = 0;
                    dbl_city.SelectedIndex = 0;
                    dblrole.SelectedIndex = 0;

                    Bind_State();
                    Bind_Section();
                    Bind_Class();

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