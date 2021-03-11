using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Cabinet_medical
{
    public partial class Item_retete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_click(object sender, EventArgs e)
        {
           SqlConnection myCon = new SqlConnection(
                @"Data Source=DESKTOP-D250CKI;Initial Catalog=Cabinet_Medical;Integrated Security=True"
                );
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myCon;
                cmd.CommandText = "SearchItRetete";
                cmd.CommandType = CommandType.StoredProcedure;

                if(inputId.Value.Trim() !="")
                {
                    SqlParameter param = new SqlParameter("@Id", inputId.Value);
                    cmd.Parameters.Add(param);
                }

                if (inputIdReteta.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter("@Id_reteta", inputIdReteta.Value);
                    cmd.Parameters.Add(param);
                }

                if (inputIdMedicament.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter("@Id_medicament", inputIdMedicament.Value);
                    cmd.Parameters.Add(param);
                }

                if (inputDozaj.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter("@Dozaj", inputDozaj.Value);
                    cmd.Parameters.Add(param);
                }

                if (inputCantitate.Value.Trim() != "")
                {
                    SqlParameter param = new SqlParameter("@Cantitate", inputCantitate.Value);
                    cmd.Parameters.Add(param);
                }

                myCon.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                gvSearchResults.DataSource = rdr;
                gvSearchResults.DataBind();

               
            }
        }
    }
}