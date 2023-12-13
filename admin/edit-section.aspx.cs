using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_edit_section : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public enum MessageType { Success, Error, Info, Warning };

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    Master mst = new Master();
    Backend bnc = new Backend();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            

            SqlDataReader dr_data = mst.Select_Operation("select * from section where id='" + Request.QueryString[0] + "' ");
            if (dr_data.Read())
            {
                txtclass.Text = dr_data["section_name"].ToString();

            }

            dr_data.Close();
        }
    }

    

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txtclass.Text.Length > 0)
            {
                int success = bnc.Edit_Section(txtclass.Text, Request.QueryString[0]);

                if (success > 0)
                {
                    ShowMessage("Data data has been updated.", MessageType.Success);
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