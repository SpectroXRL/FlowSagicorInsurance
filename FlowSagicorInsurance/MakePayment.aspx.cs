using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlowSagicorInsurance
{
    public partial class MakePayment : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            fillAccountID();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            fillAccountID();
        }

        void fillAccountID()
        {
            string type = DropDownList1.SelectedValue.ToString();
            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            if (type == "Flow")
            {
                cmd = new SqlCommand("SELECT AccountID FROM FlowAccount WHERE AspNetUserID=@userID;", con);
                cmd.Parameters.AddWithValue("@userID", User.Identity.GetUserId());
            }

            if (type == "Sagicor")
            {
                cmd = new SqlCommand("SELECT AccountID FROM SagicorAccount WHERE AspNetUserID=@userID;", con);
                cmd.Parameters.AddWithValue("@userID", User.Identity.GetUserId());
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataValueField = "AccountID";
            DropDownList2.DataBind();
        }

        protected void btnPaymentAccount_Click(object sender, EventArgs e)
        {
            localhost1.MakePayment1 makePayment = new localhost1.MakePayment1();
            string altAccountID = DropDownList2.SelectedValue.ToString();
            string type = DropDownList1.SelectedValue.ToString();
            string payment = txtPayment.Text;
            lblResult.Text = User.Identity.GetUserId();
            makePayment.initiatePayment(altAccountID, type, payment, User.Identity.GetUserId());
        }
    }
}