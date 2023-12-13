using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_manage_section : System.Web.UI.Page
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
            BindData();
        }
    }


    private void BindData()
    {
        rptbinddata.DataSource = GetData("SELECT * FROM section");
        rptbinddata.DataBind();
    }

    private DataTable GetData(string query)
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }

    protected void rptbinddata_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName.Equals("btndelete"))
        {
            Label lbldeletecategoryid = (Label)rptbinddata.Items[e.Item.ItemIndex].FindControl("lbldeletecategoryid");

            con.Open();

            string query_delete_service = "delete from section where id='" + lbldeletecategoryid.Text + "'";
            SqlCommand cmd_delete_service = new SqlCommand(query_delete_service, con);
            SqlDataReader dr_delete_service = cmd_delete_service.ExecuteReader();

            dr_delete_service.Close();

            con.Close();
            ShowMessage("Delete operation success.", MessageType.Success);

            BindData();
        }
    }
}