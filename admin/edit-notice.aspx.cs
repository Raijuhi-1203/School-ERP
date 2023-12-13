using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_edit_notice : System.Web.UI.Page
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
            SqlDataReader get_data = mst.Select_Operation("Select * from notice where id='" + Request.QueryString[0] + "' ");
            if (get_data.Read())
            {
                txtdate.Text = get_data["notice_date"].ToString();
                txtmsg.Text = get_data["description"].ToString();

            }

            get_data.Close();
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        if (txtdate.Text.Length > 0 && txtmsg.Text.Length > 0)
        {
            try
            {
                string insert_query = "update notice set notice_date=@notice_date,description=@description where id=@id";
                con.Open();
                SqlCommand insert_cmd = new SqlCommand(insert_query, con);

                insert_cmd.Parameters.AddWithValue("@notice_date", txtdate.Text);
                insert_cmd.Parameters.AddWithValue("@description", txtmsg.Text);
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