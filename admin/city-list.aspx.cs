﻿using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_city_list : System.Web.UI.Page
{
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
            BindData();
        }
    }

    private void BindData()
    {
        rpt_data.DataSource = mst.GetData("SELECT  * FROM city where state_id='" + Request.QueryString[0]+ "' order by city_name asc");
        rpt_data.DataBind();
    }

    protected void rpt_data_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("btndelete"))
        {
            Label lbl_district_id = (Label)rpt_data.Items[e.Item.ItemIndex].FindControl("lbl_id");
            Label lbl_district_name = (Label)rpt_data.Items[e.Item.ItemIndex].FindControl("lbl_city_name");


            SqlDataReader delete_city = mst.Delete_Operation("delete from city where id='" + lbl_district_id.Text + "'");
            delete_city.Close();

            

            ShowMessage("Data has been deleted.", MessageType.Error);

            BindData();
        }
    }

}