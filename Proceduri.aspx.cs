using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cabinet_medical
{
    public partial class Proceduri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string dropString = "Drop procedure PreturiIntreMinMax";
            SqlConnection myCon = new SqlConnection(
                @"Data Source=DESKTOP-D250CKI;Initial Catalog=Cabinet_Medical;Integrated Security=True"
                );
            SqlCommand myCmd = new SqlCommand(dropString, myCon);
            try
            {
                myCon.Open(); myCmd.ExecuteNonQuery();
                tbMes.Text += "\r\n Open si execute reusite";
            }
            catch (Exception ex)
            {
                tbMes.Text += "\r\n Open / execute nereusite" + ex.Message;
            }
            string creareString = "Create procedure PreturiIntreMinMax" +
                "( @minPret Float, @maxPret Float, @cateMedicamente Int Output) as " +
                "select * from Medicamente where PretMedicament >= @minPret and PretMedicament <= @maxPret;" +
                "select @cateMedicamente = count (*) from Medicamente where PretMedicament >= @minPret and PretMedicament <= @maxPret;" +
                "return 0";
            myCmd = new SqlCommand(creareString, myCon);
            try
            {
                myCmd.ExecuteNonQuery();
                tbMes.Text += "\r\n Creare reusita";
            }
            catch (Exception ex)
            {
                tbMes.Text += "\r\n Creare nereusita" + ex.Message;
            }
            finally { myCon.Close(); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(
                @"Data Source=DESKTOP-D250CKI;Initial Catalog=Cabinet_Medical;Integrated Security=True"
                );
            SqlCommand myCmd = new SqlCommand("PreturiIntreMinMax", myCon);
            myCmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@minPret", SqlDbType.Float);
            p1.Value = double.Parse(tbMinPret.Text);
            SqlParameter p2 = new SqlParameter("@maxPret", SqlDbType.Float);
            p2.Value = double.Parse(tbMaxPret.Text);
            SqlParameter p3 = new SqlParameter("@cateMedicamente", SqlDbType.Int);
            p3.Direction = ParameterDirection.Output; p3.Value = 0;
            myCmd.Parameters.Add(p1); myCmd.Parameters.Add(p2); myCmd.Parameters.Add(p3);

            SqlDataReader dr = null;
            myCon.Open();
            try
            {

                dr = myCmd.ExecuteReader();
                tbMes.Text += "\r\n Apel reusit";
                GridView1.DataSource = dr; GridView1.DataBind();
            }
            catch (Exception ex)
            {
                tbMes.Text += "\r\n Apel nereusit" + ex.Message;
            }
            finally
            {
                myCon.Close(); dr.Close();
                tbNrMedicamente.Text = p3.Value.ToString();
            }

        }
    }
}