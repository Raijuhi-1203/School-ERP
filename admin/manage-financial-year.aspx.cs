using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_manage_financial_year : System.Web.UI.Page
{
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
            BindData();
            
        }
    }

    private void BindData()
    {
        rpt_data.DataSource = mst.GetData("SELECT * FROM fincial_year order by id asc");
        rpt_data.DataBind();
    }

    

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txtto.Text.Length > 0 && txtfrom.Text.Length > 0)
            {
                int check = mst.Count_data("Select Count(id) from fincial_year Where to_year='" + txtto.Text + "' AND from_year='" + txtfrom.Text + "' ");

                if (check > 0)
                {
                    ShowMessage("Already in database.", MessageType.Error);

                    txtto.Focus();
                    txtfrom.Focus();
                }
                else
                {
                    int success = bnc.Add_FY(txtto.Text, txtfrom.Text);

                    if (success > 0)
                    {
                        ShowMessage("Data has been saved.", MessageType.Success);

                        txtto.Text = string.Empty;
                        txtfrom.Text = string.Empty;
                        txtfrom.Focus();

                    }
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