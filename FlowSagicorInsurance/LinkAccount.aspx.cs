using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Microsoft.AspNet.Identity;


namespace FlowSagicorInsurance
{
    public partial class LinkAccount : System.Web.UI.Page
    {
        protected async void btnLinkAccount_Click(object sender, EventArgs e)
        {
            localhost.AccountExist accountExist = new localhost.AccountExist();

            string accountID = txtAccountID.Text;
            string type = DropDownList1.SelectedValue.ToString();
            if (accountExist.IfAccountExist(accountID, type))
            {
                if(ifUserIsEmpty(accountID, type))
                {
                    updateAccount(accountID, type);
                }
                else
                {
                    Response.Write("<script>alert('Account Already Linked');</script>");
                }

            };

        }

        bool ifUserIsEmpty(string accountID, string type)
        {
            try
            {
                accountID = txtAccountID.Text;
                string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                if (type == "Flow")
                {
                    cmd = new SqlCommand("SELECT * FROM FlowAccount WHERE AccountID='" + accountID + "' AND AspNetUserID IS NULL;", con);
                }

                if (type == "Sagicor")
                {
                    cmd = new SqlCommand("SELECT * FROM SagicorAccount WHERE AccountID='" + accountID + "' AND AspNetUserID IS NULL;", con);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;

            }
            return true;
        }

        void updateAccount(string accountID, string type)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                if (type == "Flow")
                {
                    cmd = new SqlCommand("UPDATE FlowAccount SET AspNetUserID=@userID WHERE AccountID='" + accountID + "';", con);
                    cmd.Parameters.AddWithValue("@userID", User.Identity.GetUserId());
                }

                if (type == "Sagicor")
                {
                    cmd = new SqlCommand("UPDATE SagicorAccount SET AspNetUserID=@userID WHERE AccountID='" + accountID + "';", con);
                    cmd.Parameters.AddWithValue("@userID", User.Identity.GetUserId());
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
    }
}


