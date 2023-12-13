using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_add_enquiry : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    Encrypt ob = new Encrypt();
    public enum MessageType { Success, Error, Info, Qarning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    
    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        if (txtname.Text.Length > 0 && txtdetails.Text.Length > 0 && txtmobileno.Text.Length > 0)
        {
            try
            {
                string insert_query = "insert into enquiry(name,mobileno,enq_details,create_date,create_time) values (@name,@mobileno,@enq_details,@create_date,@create_time) ";
                con.Open();
                SqlCommand insert_cmd = new SqlCommand(insert_query, con);

                insert_cmd.Parameters.AddWithValue("@name", txtname.Text);
                insert_cmd.Parameters.AddWithValue("@enq_details", txtdetails.Text);
                insert_cmd.Parameters.AddWithValue("@mobileno", txtmobileno.Text);
                insert_cmd.Parameters.AddWithValue("@create_date", DateTime.Now.ToString("yyyy-MM-dd"));
                insert_cmd.Parameters.AddWithValue("@create_time", DateTime.Now.ToString("HH:mm:ss"));


                int success = insert_cmd.ExecuteNonQuery();
                if (success > 0)
                {
                    ShowMessage("User has been saved.", MessageType.Success);
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