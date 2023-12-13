using System;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    Master mst = new Master();
   
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            
            lblcollection.Text = Convert.ToString(mst.Count_data("Select Count(DISTINCT id) from student_fee"));
            lblemployee.Text = Convert.ToString(mst.Count_data("SELECT COUNT(id) FROM teacher where status='Active'"));
            lblstudent.Text = Convert.ToString(mst.Count_data("SELECT Count(DISTINCT id) FROM student where status='Active'"));
          
        }
    }

    

}