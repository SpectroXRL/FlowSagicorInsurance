using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.Ajax.Utilities;
using System.EnterpriseServices;

namespace FlowSagicorInsurance
{
    /// <summary>
    /// Summary description for MakePayment1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MakePayment1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string initiatePayment(string altAccountID, string type, string payment, string userID)
        {
            try
            {
                string accountID = getAccountID(userID);
                updateBankAccount(accountID, payment);
                updateAltAccount(altAccountID, type, payment);
                string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                if (type == "Flow")
                {
                   cmd = new SqlCommand("INSERT INTO [dbo].[Transaction](AccountID, AspNetUserID, Payment, FlowID)" +
                    " VALUES (@account_id, @aspnetuser_id, @payment, @flow_id)",
                    con);
                    cmd.Parameters.AddWithValue("@flow_id", altAccountID);
                }

                if (type == "Sagicor")
                {
                    cmd = new SqlCommand("INSERT INTO [dbo].[Transaction](AccountID, AspNetUserID, Payment, SagicorID)" +
                     " VALUES (@account_id, @aspnetuser_id, @payment, @sagicor_id)",
                     con);
                    cmd.Parameters.AddWithValue("@sagicor_id", altAccountID);
                }

                cmd.Parameters.AddWithValue("@account_id", accountID);
                cmd.Parameters.AddWithValue("@aspnetuser_id", userID);
                cmd.Parameters.AddWithValue("@payment", payment);

                cmd.ExecuteNonQuery();
                con.Close();
                return "Payment Made";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Payment Failed, Try Again";
            }
            
        }

        string getAccountID(string userID)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                string accountID = "";
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM BankAccount WHERE AspNetUserID='" + userID + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    accountID = dt.Rows[0]["AccountID"].ToString();
                    return accountID;
                }
                else
                {
                    return "no result";
                }
            }
            catch (Exception ex)
            {
                return "no result";
            }
            
        }

        void updateBankAccount(string accountID, string payment)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                double currentBal = getBankCurrentBal(accountID);
                double dPayment = Double.Parse(payment);
                double newBal = currentBal - dPayment;

                SqlCommand cmd = new SqlCommand("UPDATE BankAccount SET Balance=@balance WHERE AccountID='" + accountID + "';", con);
                cmd.Parameters.AddWithValue("@balance", newBal);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        void updateAltAccount(string altAccountID, string type, string payment)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                double currentBal = getAltCurrentBal(altAccountID, type);
                double dPayment = Double.Parse(payment);
                double newBal = currentBal + dPayment;

                if (type == "Flow")
                {
                    cmd = new SqlCommand("UPDATE FlowAccount SET Balance=@balance WHERE AccountID='" + altAccountID + "';", con);
                    cmd.Parameters.AddWithValue("@balance", newBal);
                }

                if (type == "Sagicor")
                {
                    cmd = new SqlCommand("UPDATE SagicorAccount SET Balance=@balance WHERE AccountID='" + altAccountID + "';", con);
                    cmd.Parameters.AddWithValue("@balance", newBal);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        double getBankCurrentBal(string accountID)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                double balance = 0.0;
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM BankAccount WHERE AccountID='" + accountID + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    balance = Double.Parse(dt.Rows[0]["Balance"].ToString());
                    return balance;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            return 0;
        }

        double getAltCurrentBal(string altAccountID, string type)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                double balance = 0.0;
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                if(type == "Flow")
                {
                    cmd = new SqlCommand("SELECT * FROM FlowAccount WHERE AccountID='" + altAccountID + "';", con);
                }

                if(type == "Sagicor")
                {
                    cmd = new SqlCommand("SELECT * FROM SagicorAccount WHERE AccountID='" + altAccountID + "';", con);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    balance = Double.Parse(dt.Rows[0]["Balance"].ToString());
                    return balance;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            
        }
    }
}
