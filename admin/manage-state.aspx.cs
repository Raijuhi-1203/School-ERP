using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_manage_state : System.Web.UI.Page
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
        if(!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        rpt_data.DataSource = mst.GetData("SELECT * FROM state order by state_name asc");
        rpt_data.DataBind();
    }

    protected void rpt_data_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lbl_state_name = (Label)rpt_data.Items[e.Item.ItemIndex].FindControl("lbl_state_name");
            Label lbl_state_id = (Label)rpt_data.Items[e.Item.ItemIndex].FindControl("lbl_state_id");

            SqlDataReader delete_state = mst.Delete_Operation("delete from state where id='" + lbl_state_id.Text + "'");
            delete_state.Close();

            SqlDataReader delete_city = mst.Delete_Operation("delete from city where state_id='" + lbl_state_id.Text + "'");
            delete_city.Close();

            ShowMessage("Data has been deleted.",MessageType.Success);

            BindData();
        }
    }

    protected void btnsave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (txtstate.Text.Length > 0)
            {
                int check = mst.Count_data("Select Count(id) from state Where state_name='" + txtstate.Text + "'");

                if (check > 0)
                {
                    ShowMessage("State already in database.", MessageType.Error);

                    txtstate.Focus();
                }
                else
                {
                    int success = bnc.Add_State(txtstate.Text);

                    if (success > 0)
                    {
                        ShowMessage("State has been saved.", MessageType.Success);

                        txtstate.Text = string.Empty;
                        txtstate.Focus();
                        BindData();
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