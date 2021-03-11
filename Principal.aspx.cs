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
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbMes.Text += "\r\n Pagina a ajuns in server";
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            SqlParameter p1 = new SqlParameter("@Id", System.Data.SqlDbType.Int);
            SqlParameter p2 = new SqlParameter("@CodMedicament", System.Data.SqlDbType.NVarChar); p2.Value = tbCod.Text;
            SqlParameter p3 = new SqlParameter("@DenumireMedicament", System.Data.SqlDbType.NVarChar); p3.Value = tbDenumire.Text;
            SqlParameter p4 = new SqlParameter("@SubstantaActiva", System.Data.SqlDbType.NVarChar); p4.Value = tbSubstanta.Text;
            SqlParameter p5 = new SqlParameter("@Concentratie", System.Data.SqlDbType.NVarChar); p5.Value = tbConcentratie.Text;
            SqlParameter p6 = new SqlParameter("@PretMedicament", System.Data.SqlDbType.NVarChar); p6.Value = double.Parse(tbPretMedicament.Text);


            string insertString = "INSERT INTO [Medicamente] ([Id], [CodMedicament], [DenumireMedicament], [SubstantaActiva], [Concentratie], [PretMedicament]) " +
                                 "VALUES (@Id, @CodMedicament, @DenumireMedicament, @SubstantaActiva, @Concentratie, @PretMedicament)";


            int n = 0;
            string selString = "SELECT MAX(ID) FROM MEDICAMENTE";
            SqlConnection myCon = new SqlConnection("Data Source=DESKTOP-D250CKI;Initial Catalog=Cabinet_Medical;Integrated Security=True");
            myCon.Open();
            SqlCommand myCmd = new SqlCommand(selString, myCon);
            SqlDataReader dr = myCmd.ExecuteReader();
            dr.Read(); n = (int)dr[0]; tbMes.Text += "\r\n Max= " + n;
            p1.Value = n + 1;
            dr.Close();
            myCmd = new SqlCommand(insertString, myCon);
            myCmd.Parameters.Add(p1); myCmd.Parameters.Add(p2); myCmd.Parameters.Add(p3); myCmd.Parameters.Add(p4);
            myCmd.Parameters.Add(p5); myCmd.Parameters.Add(p6);
            n = myCmd.ExecuteNonQuery(); tbMes.Text += "\r\n" + tbDenumire.Text + " a fost inserat cu succes!";

            myCon.Close();
            dr.Close();

            GridView1.DataBind();


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSourceSelectArguments args = new DataSourceSelectArguments();
            DataView dv = (DataView)SqlDataSource1.Select(args);
            DataTable dt = dv.ToTable();
            DataSet ds = new DataSet(); ds.Tables.Add(dt);
            Cache["MedCache"] = ds;
            Response.Redirect("Grafice.aspx?tip=" + DropDownList1.SelectedItem.Text);
        }

        protected void btnProc_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proceduri.aspx");
        }

        protected void btnRetete_Click(object sender, EventArgs e)
        {
            Response.Redirect("Item_retete.aspx");
        }
    }
    
}