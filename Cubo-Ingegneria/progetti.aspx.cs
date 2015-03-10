using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Cubo_Ingegneria
{
    public partial class progetti : System.Web.UI.Page
    {
        private utility.Utility utility = new utility.Utility();

        protected void Page_Load(object sender, EventArgs e)
        {
            loadProgetti();
        }

        private void loadProgetti(){

            //retrieve the connection string from utility function
            String connectionString = utility.ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {   
                con.Open();

                //retrieve everything from progetti and immagini
                string query = "SELECT progetti.id, progetti.titolo, progetti.presentazione, progetti.committente, progetti.importo, progetti.stato, progetti.anno, immagini.id, immagini.idprogetto, immagini.path, immagini.imgdefault " +
                                "FROM progetti INNER JOIN immagini ON progetti.id=immagini.idprogetto " +
                                "WHERE immagini.imgdefault = '1'";

                using (SqlCommand command = new SqlCommand(query, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    HtmlGenericControl ulProgetti = new HtmlGenericControl("ul");
                   
                    while (reader.Read())
                    {
                        //create the html structure of progetti
                        createHtmlprogetti(ulProgetti, reader);
                    }

                    progettiContainer.Controls.Add(ulProgetti);
                }
                con.Close();
            }
        }

        //create the structure of progetti
        private void createHtmlprogetti(HtmlGenericControl ulProgetti, SqlDataReader reader) {
 
            HtmlGenericControl liProgetti = new HtmlGenericControl("li");
            HtmlGenericControl divNomeProgetto = new HtmlGenericControl("div");
            HtmlGenericControl labelNomeProgetto = new HtmlGenericControl("label");
            HtmlGenericControl divImgProgetto = new HtmlGenericControl("div");
            HtmlGenericControl divInfoProgetto = new HtmlGenericControl("div");
            HtmlGenericControl imgProgetto = new HtmlGenericControl("img");
            HtmlGenericControl a = new HtmlGenericControl("a");

            divNomeProgetto.Attributes.Add("class", "progettoNome");
            labelNomeProgetto.Attributes.Add("class", "progettoTitoloLabel");
            labelNomeProgetto.InnerText = reader.GetValue(1).ToString();
            divImgProgetto.Attributes.Add("class", "imgProgetto");
            divInfoProgetto.Attributes.Add("class", "infoProgetto");
            
            imgProgetto.Attributes.Add("class", "imgValues");
            imgProgetto.Attributes.Add("alt", "alt");
            imgProgetto.Attributes.Add("src", reader.GetValue(9).ToString());

            a.Attributes.Add("href", "dettaglio-progetto.aspx?idProgetto=" + reader.GetValue(0));

            divNomeProgetto.Controls.Add(labelNomeProgetto);
            divImgProgetto.Controls.Add(a);

            a.Controls.Add(imgProgetto);

            liProgetti.Controls.Add(divNomeProgetto);
            liProgetti.Controls.Add(divImgProgetto);
            liProgetti.Controls.Add(divInfoProgetto);

            ulProgetti.Controls.Add(liProgetti);
        }
    }
}