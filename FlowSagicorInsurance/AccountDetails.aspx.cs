using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNet.Identity;
using System.Web.UI.WebControls;

namespace FlowSagicorInsurance
{

    public partial class AccountDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAccountDetails();
            }
        }
        private void LoadAccountDetails()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT AccountNumber, AccountType, Balance FROM AccountDetails WHERE UserId = @UserId"))
                {
                    cmd.Parameters.AddWithValue("@UserId", Context.User.Identity.GetUserId());
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        AccountDetailsGrid.DataSource = dt;
                        AccountDetailsGrid.DataBind();
                    }
                    con.Close();
                }
            }
        }
    }
}