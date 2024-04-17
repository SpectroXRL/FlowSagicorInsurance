using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNet.Identity;
using System.Data.SqlTypes;

namespace FlowSagicorInsurance
{
    public partial class AccountDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAccountDetailsGrid();
                BindLinkedAccountsGrid();
            }
        }
        private void BindAccountDetailsGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT AccountID, AccountType, Balance FROM BankAccount WHERE AspNetUserID = @AspNetUserID"))
                {
                    cmd.Parameters.AddWithValue("@AspNetUserID", Context.User.Identity.GetUserId());
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            AccountDetailsGrid.DataSource = dt;
                            AccountDetailsGrid.DataBind();
                        }
                    }
                }
            }
        }
        private void BindLinkedAccountsGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT AccountID, 'FLOW' as Service FROM FlowAccount WHERE AspNetUserID = @AspNetUserID UNION SELECT AccountID, 'SAGICOR LIFE' as Service FROM SagicorAccount WHERE AspNetUserID = @AspNetUserID"))
                {
                    cmd.Parameters.AddWithValue("@AspNetUserID", Context.User.Identity.GetUserId());
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            LinkedAccountsGrid.DataSource = dt;
                            LinkedAccountsGrid.DataBind();
                        }
                    }
                }
            }
        }
    }
}
