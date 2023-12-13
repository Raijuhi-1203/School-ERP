using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_edit_subject : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    Encrypt ob = new Encrypt();
    Master mst = new Master();
    public enum MessageType { Success, Error, Info, Qarning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlDataReader get_data = mst.Select_Operation("Select * from subject where id='" + Request.QueryString[0] + "' ");
            if (get_data.Read())
            {
               
                txtmsg.Text = get_data["subject_name"].ToString();

            }

            get_data.Close();
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        if (txtmsg.Text.Length > 0)
        {
            try
            {
                string insert_query = "update subject set subject_name=@subject_name where id=@id";
                con.Open();
                SqlCommand insert_cmd = new SqlCommand(insert_query, con);

                insert_cmd.Parameters.AddWithValue("@subject_name", txtmsg.Text);
                insert_cmd.Parameters.AddWithValue("@id", Request.QueryString[0]);

                int success = insert_cmd.ExecuteNonQuery();

                if (success > 0)
                {
                    ShowMessage("Data has been updated.", MessageType.Success);
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