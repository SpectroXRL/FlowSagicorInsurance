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
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTransactionHistoryGrid();
            }
        }

        private void BindTransactionHistoryGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT AccountID, Payment, FlowID, SagicorID FROM [dbo].[Transaction] WHERE AspNetUserID = @AspNetUserID"))
                {
                    cmd.Parameters.AddWithValue("@AspNetUserID", Context.User.Identity.GetUserId());
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            TransactionHistoryGrid.DataSource = dt;
                            TransactionHistoryGrid.DataBind();
                        }
                    }
                }
            }
        }
    }
}