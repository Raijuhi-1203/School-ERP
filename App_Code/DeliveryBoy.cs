using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DeliveryBoy
/// </summary>
public class DeliveryBoy
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    public DeliveryBoy()
    {
        
    }

    public int Update_photo(string delivery_boy_photo, string delivery_boy_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update ecommerce_delivery_boy Set delivery_boy_photo=@delivery_boy_photo where delivery_boy_id=@delivery_boy_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@delivery_boy_photo", SqlDbType.NVarChar).Value = delivery_boy_photo;
            cmd.Parameters.AddWithValue("@delivery_boy_id", SqlDbType.NVarChar).Value = delivery_boy_id;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return (RowsAffected);
    }

   
    public int Add_Student(string student_id, string name, string mobile_no, string father_name, string mother_name, string address, string state, string city, string pincode, string create_date, string create_time, string status, string assign_class, string assign_section)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into student(student_id,name,mobile_no,father_name,mother_name,address,city,state,pincode,create_date,create_time,status,assign_class,assign_section) values (@student_id,@name,@mobile_no,@father_name,@mother_name,@address,@city,@state,@pincode,@create_date,@create_time,@status,@assign_class,@assign_section)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@assign_class", SqlDbType.NVarChar).Value = assign_class;
            cmd.Parameters.AddWithValue("@assign_section", SqlDbType.NVarChar).Value = assign_section;
            cmd.Parameters.AddWithValue("@student_id", SqlDbType.NVarChar).Value = student_id;
            cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.AddWithValue("@mobile_no", SqlDbType.NVarChar).Value = mobile_no;

            cmd.Parameters.AddWithValue("@father_name", SqlDbType.NVarChar).Value = father_name;
            cmd.Parameters.AddWithValue("@mother_name", SqlDbType.NVarChar).Value = mother_name;
            cmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = address;
            cmd.Parameters.AddWithValue("@city", SqlDbType.NVarChar).Value = city;
            cmd.Parameters.AddWithValue("@state", SqlDbType.NVarChar).Value = state;
            cmd.Parameters.AddWithValue("@pincode", SqlDbType.NVarChar).Value = pincode;
            cmd.Parameters.AddWithValue("@create_date", SqlDbType.NVarChar).Value = create_date;
            cmd.Parameters.AddWithValue("@create_time", SqlDbType.NVarChar).Value = create_time;
            cmd.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = status;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return (RowsAffected);
    }

    public int Edit_Student(string name, string mobile_no, string father_name, string mother_name, string address, string state, string city, string pincode, string status, string assign_class, string assign_section, string student_id)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update student set name=@name,mobile_no=@mobile_no,father_name=@father_name,mother_name=@mother_name,address=@address,city=@city,state=@state,pincode=@pincode,status=@status,assign_class=@assign_class,assign_section=@assign_section where student_id=@student_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@assign_class", SqlDbType.NVarChar).Value = assign_class;
            cmd.Parameters.AddWithValue("@assign_section", SqlDbType.NVarChar).Value = assign_section;
            cmd.Parameters.AddWithValue("@student_id", SqlDbType.NVarChar).Value = student_id;
            cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.AddWithValue("@mobile_no", SqlDbType.NVarChar).Value = mobile_no;

            cmd.Parameters.AddWithValue("@father_name", SqlDbType.NVarChar).Value = father_name;
            cmd.Parameters.AddWithValue("@mother_name", SqlDbType.NVarChar).Value = mother_name;
            cmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = address;
            cmd.Parameters.AddWithValue("@city", SqlDbType.NVarChar).Value = city;
            cmd.Parameters.AddWithValue("@state", SqlDbType.NVarChar).Value = state;
            cmd.Parameters.AddWithValue("@pincode", SqlDbType.NVarChar).Value = pincode;
            cmd.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = status;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return (RowsAffected);
    }

    public int Add_Employee(string employee_id, string name, string mobile_no, string father_name, string mother_name, string experience, string address, string state, string city, string pincode, string create_date, string create_time, string status, string assign_class, string assign_section, string employee_role)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into teacher(employee_role,experience,employee_id,name,mobile_no,father_name,mother_name,address,city,state,pincode,create_date,create_time,status,assign_class,assign_section) values (@employee_role,@experience,@employee_id,@name,@mobile_no,@father_name,@mother_name,@address,@city,@state,@pincode,@create_date,@create_time,@status,@assign_class,@assign_section)";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@assign_class", SqlDbType.NVarChar).Value = assign_class;
            cmd.Parameters.AddWithValue("@assign_section", SqlDbType.NVarChar).Value = assign_section;
            cmd.Parameters.AddWithValue("@employee_id", SqlDbType.NVarChar).Value = employee_id;
            cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.AddWithValue("@mobile_no", SqlDbType.NVarChar).Value = mobile_no;
            cmd.Parameters.AddWithValue("@experience", SqlDbType.NVarChar).Value = experience;

            cmd.Parameters.AddWithValue("@father_name", SqlDbType.NVarChar).Value = father_name;
            cmd.Parameters.AddWithValue("@mother_name", SqlDbType.NVarChar).Value = mother_name;
            cmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = address;
            cmd.Parameters.AddWithValue("@city", SqlDbType.NVarChar).Value = city;
            cmd.Parameters.AddWithValue("@state", SqlDbType.NVarChar).Value = state;
            cmd.Parameters.AddWithValue("@pincode", SqlDbType.NVarChar).Value = pincode;
            cmd.Parameters.AddWithValue("@create_date", SqlDbType.NVarChar).Value = create_date;
            cmd.Parameters.AddWithValue("@create_time", SqlDbType.NVarChar).Value = create_time;
            cmd.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = status;
            cmd.Parameters.AddWithValue("@employee_role", SqlDbType.NVarChar).Value = employee_role;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return (RowsAffected);
    }

    public int Edit_Employee(string name, string mobile_no, string father_name, string mother_name, string experience, string address, string state, string city, string pincode, string status, string assign_class, string assign_section, string employee_id, string employee_role)
    {
        con.Close();
        con.Open();
        int RowsAffected = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update teacher set employee_role=@employee_role,experience=@experience,name=@name,mobile_no=@mobile_no,father_name=@father_name,mother_name=@mother_name,address=@address,city=@city,state=@state,pincode=@pincode,status=@status,assign_class=@assign_class,assign_section=@assign_section where employee_id=@employee_id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@employee_role", SqlDbType.NVarChar).Value = employee_role;
            cmd.Parameters.AddWithValue("@assign_class", SqlDbType.NVarChar).Value = assign_class;
            cmd.Parameters.AddWithValue("@assign_section", SqlDbType.NVarChar).Value = assign_section;
            cmd.Parameters.AddWithValue("@employee_id", SqlDbType.NVarChar).Value = employee_id;
            cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.AddWithValue("@mobile_no", SqlDbType.NVarChar).Value = mobile_no;

            cmd.Parameters.AddWithValue("@father_name", SqlDbType.NVarChar).Value = father_name;
            cmd.Parameters.AddWithValue("@mother_name", SqlDbType.NVarChar).Value = mother_name;
            cmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = address;
            cmd.Parameters.AddWithValue("@city", SqlDbType.NVarChar).Value = city;
            cmd.Parameters.AddWithValue("@state", SqlDbType.NVarChar).Value = state;
            cmd.Parameters.AddWithValue("@pincode", SqlDbType.NVarChar).Value = pincode;
            cmd.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = status;
            cmd.Parameters.AddWithValue("@experience", SqlDbType.NVarChar).Value = experience;

            RowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return (RowsAffected);
    }


}