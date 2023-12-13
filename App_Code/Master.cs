using Razorpay.Api;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Master
/// </summary>
public class Master
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public Master()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public void PopulateCheckbox(CheckBoxList chk, string value_field, string text_field, string query)
    {
        DataSet ds = new DataSet();
        string cmdstr = query;
        SqlDataAdapter adp = new SqlDataAdapter(cmdstr, con);
        adp.Fill(ds);
        chk.DataSource = ds;
        chk.DataTextField = text_field;
        chk.DataValueField = value_field;
        chk.DataBind();
        con.Close();
    }


    public String Get_Shipping_charge()
    {
       
        String shipping = "";
        try
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT shipping_charge from ecommerce_shipping ";
            cmd.CommandType = CommandType.Text;
            
            shipping = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return (shipping);
    }

  //  Shipping Charge End


    // Discount

    public SqlDataReader Get_Coupon_Info(String coupan_code)
    {
       
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * from ecommerce_coupan where coupan_code=@coupan_code";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@coupan_code", coupan_code);
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }


    public DataTable GetData(string query)
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
                    cmd.Dispose();
                }
            }
            con.Close();
            return dt;

           
        }
    }



    // Delete Operation

    public SqlDataReader Delete_Operation(string query)
    {
        
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    // Delete Operation End

        // Count Data

    public int Count_data(string query)
    {
        con.Close();
        con.Open();
        int data = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            data = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (data);
    }


    //  Select Query

    public SqlDataReader Select_Operation(string query)
    {
       
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }

    public void BindDropDown(DropDownList dbl_list, string valueField, string textField, string query)
    {
        dbl_list.Items.Clear();
        dbl_list.Items.Add(new ListItem("Please Select", ""));
        dbl_list.AppendDataBoundItems = true;

        String strConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        String strQuery = query;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;

        try
        {
            con.Open();

            dbl_list.DataSource = cmd.ExecuteReader();
            dbl_list.DataTextField = textField;
            dbl_list.DataValueField = valueField;
            dbl_list.DataBind();
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

    public void PopulateGridview(string query, GridView grd_list)
    {
        DataTable dtbl = new DataTable();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = query;
        cmd.Connection = con;
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
        //  cmd.Parameters.AddWithValue("@search", txt_search.Text.Trim());
        sqlDa.Fill(dtbl);
        if (dtbl.Rows.Count > 0)
        {
            grd_list.DataSource = dtbl;
            grd_list.DataBind();
        }
        else
        {
            dtbl.Rows.Add(dtbl.NewRow());
            grd_list.DataSource = dtbl;
            grd_list.DataBind();

            grd_list.Rows[0].Cells.Clear();
            grd_list.Rows[0].Cells.Add(new TableCell());
            grd_list.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
            grd_list.Rows[0].Cells[0].Text = "No Data Found ..!";
            grd_list.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        }

        con.Close();

    }

    public void Bind_Checkbox(CheckBoxList chklist,string valueField, string textField,string query)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(query, con);
        adp.Fill(ds);
        chklist.DataSource = ds;
        chklist.DataTextField = textField;
        chklist.DataValueField = valueField;
        chklist.DataBind();
        con.Close();
    }


    // Enquiry

    public int Insert_Enquiry(string name,string mobileno,string email,string message,string date)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into ecommerce_enquiry(enquiry_name,enquiry_email,enquiry_contact,enquiry_message,enquiry_create_date) values (@enquiry_name,@enquiry_email,@enquiry_contact,@enquiry_message,@enquiry_create_date) ";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@enquiry_name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.AddWithValue("@enquiry_email", email);
            cmd.Parameters.AddWithValue("@enquiry_contact", mobileno);
            cmd.Parameters.AddWithValue("@enquiry_message", SqlDbType.NVarChar).Value = message;
            cmd.Parameters.AddWithValue("@enquiry_create_date", date);

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    // Wallet Credit/Debit

    public int Add_Wallet_Credit_Debit(string customer_id, string transaction_id, string transaction_amount, string transaction_date, string transaction_time, string transaction_type, string transaction_payment_mode, string transaction_status,string transaction_by)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into customer_wallet_transaction(customer_id,transaction_id,transaction_amount,transaction_date,transaction_time,transaction_type,transaction_payment_mode,transaction_status,transaction_by) values (@customer_id,@transaction_id,@transaction_amount,@transaction_date,@transaction_time,@transaction_type,@transaction_payment_mode,@transaction_status,@transaction_by)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;
            cmd.Parameters.AddWithValue("@transaction_id", SqlDbType.NVarChar).Value = transaction_id;
            cmd.Parameters.AddWithValue("@transaction_amount", SqlDbType.NVarChar).Value = transaction_amount;
            cmd.Parameters.AddWithValue("@transaction_date", SqlDbType.NVarChar).Value = transaction_date;
            cmd.Parameters.AddWithValue("@transaction_time", SqlDbType.NVarChar).Value = transaction_time;
            cmd.Parameters.AddWithValue("@transaction_type", SqlDbType.NVarChar).Value = transaction_type;
            cmd.Parameters.AddWithValue("@transaction_payment_mode", SqlDbType.NVarChar).Value = transaction_payment_mode;
            cmd.Parameters.AddWithValue("@transaction_status", SqlDbType.NVarChar).Value = transaction_status;
            cmd.Parameters.AddWithValue("@transaction_by", SqlDbType.NVarChar).Value = transaction_by;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public int Add_Referal_Point(string customer_id, string transaction_id, string transaction_amount, string transaction_date, string transaction_time, string transaction_type, string transaction_payment_mode, string transaction_status, string transaction_by,string delivery_date)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into customer_wallet_transaction(customer_id,transaction_id,transaction_amount,transaction_date,transaction_time,transaction_type,transaction_payment_mode,transaction_status,transaction_by,delivery_date) values (@customer_id,@transaction_id,@transaction_amount,@transaction_date,@transaction_time,@transaction_type,@transaction_payment_mode,@transaction_status,@transaction_by,@delivery_date)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customer_id;
            cmd.Parameters.AddWithValue("@transaction_id", SqlDbType.NVarChar).Value = transaction_id;
            cmd.Parameters.AddWithValue("@transaction_amount", SqlDbType.NVarChar).Value = transaction_amount;
            cmd.Parameters.AddWithValue("@transaction_date", SqlDbType.NVarChar).Value = transaction_date;
            cmd.Parameters.AddWithValue("@transaction_time", SqlDbType.NVarChar).Value = transaction_time;
            cmd.Parameters.AddWithValue("@transaction_type", SqlDbType.NVarChar).Value = transaction_type;
            cmd.Parameters.AddWithValue("@transaction_payment_mode", SqlDbType.NVarChar).Value = transaction_payment_mode;
            cmd.Parameters.AddWithValue("@transaction_status", SqlDbType.NVarChar).Value = transaction_status;
            cmd.Parameters.AddWithValue("@transaction_by", SqlDbType.NVarChar).Value = transaction_by;
            cmd.Parameters.AddWithValue("@delivery_date", SqlDbType.NVarChar).Value = delivery_date;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (RowsAffected);
    }

    public SqlDataReader GetTotalAmount(string order_date)
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader = null;
        try
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
           // cmd.CommandText = "SELECT sum(a.total_amount_of_product) as total_order_amount FROM [gro_shop].[ecommerce_order] a where a.order_section='Restaurant' AND a.order_date = '" + order_date + "' and a.order_status!='Cancelled' group by a.order_id";
            cmd.CommandText = "SELECT (sum(a.total_amount_of_product)-sum(a.product_discount_price)) as total_order_amount,sum(b.original_price) as original_price FROM [gro_shop].[ecommerce_order] a left join ecommerce_product_price as b on b.id=a.product_price_id where a.order_section='Restaurant' AND a.order_date = '" + order_date + "' and a.order_status!='Cancelled'";
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return (reader);
    }
}