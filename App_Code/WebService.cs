using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.Script.Services;
using System.IO;
using System.Text;
using System.Security.Cryptography;


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class WebService : System.Web.Services.WebService
{
    string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    Encrypt enc = new Encrypt();
    public WebService()
    {
    }

    [WebMethod]
    public String login(string mobile_no, string student_id)
    {
        
        string output = string.Empty;
        try
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                #region SQl select command
                cmd.CommandText = @"SELECT * FROM  student where student_id = '" + student_id + "' and mobile_no = '" + mobile_no + "'";
                #endregion 
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);

                JavaScriptSerializer js = new JavaScriptSerializer();
                output = JsonConvert.SerializeObject(dt);
                con.Close();
            }

        }
        catch (Exception ex)
        {
            string text = "My text that I want to display";

        }
        return output;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_subject()
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT * FROM subject";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_notice()
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT *  FROM  notice";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_holiday()
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT *  FROM  holiday";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_attendance(string student_id, string month)
    {


        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT * from student_attendance where student_id='"+ student_id + "' and month(date)='"+ month +"'";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_fee(string classs)
    {

        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"SELECT * from class_fee where class='"+classs+"'";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;
        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_exam_result(string student_id)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"select * from exam_result where student_id='" + student_id + "'";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;

        }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String get_exam(string classs)
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand();
            #region SQl select command
            cmd.CommandText = @"select * from exam where class='" + classs + "'";
            #endregion
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = JsonConvert.SerializeObject(dt);

            return strJSON;

        }


    }

}
