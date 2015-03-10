using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Cubo_Ingegneria
{
    public partial class progettoDettaglio : System.Web.UI.Page
    {
        private utility.Utility utility = new utility.Utility();

        protected void Page_Load(object sender, EventArgs e)
        {
            //retrieve the id from url and check the validity
            String idProgetto = Request.QueryString["idProgetto"];
            int Num;
            bool isNum = int.TryParse(idProgetto, out Num);
            if (isNum)
            {
                loadProgettoDettaglio(idProgetto);
                loadImmaginiSlide(idProgetto);
            }
            
            
        }

        //connect to the database and retrieve all information about immagini and progetti
        private void loadImmaginiSlide(string idProgetto)
        {
            //retrieve the connection string from utility function
            String connectionString = utility.ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //retrieve id and path from immagini
                string query = "SELECT immagini.idprogetto, immagini.path FROM progetti INNER JOIN immagini ON progetti.id=immagini.idprogetto WHERE progetti.id='"+ idProgetto +"'";
                int count = 1;

                using (SqlCommand command = new SqlCommand(query, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //create the html structure from the query output
                        createHTMLImmaginiSlide(slidewrapper, reader, count);
                        count++;
                    }
                }
                con.Close();
            }
        }

        //create the html structure
        private void createHTMLImmaginiSlide(HtmlGenericControl slidewrapper, SqlDataReader reader, int count)
        {
            HtmlGenericControl slideshowContent = new HtmlGenericControl("div");
            HtmlGenericControl slide = new HtmlGenericControl("img");

            slideshowContent.Attributes.Add("class", "slideshow-content");
            slide.Attributes.Add("class", "slide");
            slide.Attributes.Add("id", "imgSlide-" + count);
            slide.Attributes.Add("src", reader.GetValue(1).ToString());

            slideshowContent.Controls.Add(slide);
            slidewrapper.Controls.Add(slideshowContent);
        }


        private void loadProgettoDettaglio(string idProgetto)
        {

            //retrieve the connection string from utility function
            String connectionString = utility.ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //retrieve everything from progetti where the id is the one passed
                string query = "SELECT progetti.id, progetti.titolo, progetti.presentazione, progetti.committente, progetti.importo, progetti.stato, progetti.anno FROM progetti WHERE progetti.id='"+ idProgetto +"'";
                
                using (SqlCommand command = new SqlCommand(query, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       titoloProgettoDettaglio.InnerText = reader.GetValue(1).ToString();
                       createHTMLProgetto(dettaglioWrapper, reader);
                    }
                }
                con.Close();
            }
        }

        //create the html structure of progetto
        private void createHTMLProgetto(HtmlGenericControl dettaglioWrapper, SqlDataReader reader)
        { 
            HtmlGenericControl projectDescription = new HtmlGenericControl("div");

            HtmlGenericControl p_presentazioneProgetto = new HtmlGenericControl("p");
            HtmlGenericControl fascia = new HtmlGenericControl("img");
            HtmlGenericControl p_descrizioneProgetto = new HtmlGenericControl("p");

            HtmlGenericControl p_dettaglioProgetto = new HtmlGenericControl("p");
            HtmlGenericControl fascia2 = new HtmlGenericControl("img");
            HtmlGenericControl p_committenteProgetto = new HtmlGenericControl("p");
            HtmlGenericControl p_importoProgetto = new HtmlGenericControl("p");
            HtmlGenericControl p_statoProgetto = new HtmlGenericControl("p");

            projectDescription.Attributes.Add("id", "projectDescription");
            p_presentazioneProgetto.Attributes.Add("id", "presentazioneProgetto");
            fascia.Attributes.Add("class", "fasciaDescrizioneProgetto");
            fascia.Attributes.Add("src", "images/fascia.png");
            p_descrizioneProgetto.Attributes.Add("id", "descrizioneProgetto");
            p_dettaglioProgetto.Attributes.Add("id", "dettaglioProgetto");
            fascia2.Attributes.Add("class", "fasciaDescrizioneProgetto");
            fascia2.Attributes.Add("src", "images/fascia.png");
            p_committenteProgetto.Attributes.Add("id", "committenteProgetto");
            p_importoProgetto.Attributes.Add("id", "importoProgetto");
            p_statoProgetto.Attributes.Add("id", "statoProgetto");

            p_presentazioneProgetto.InnerText = "Descrizione";
            p_descrizioneProgetto.InnerText = reader.GetValue(2).ToString();
            p_dettaglioProgetto.InnerText = "Dettagli";
            p_committenteProgetto.InnerText = "Committente: " + reader.GetValue(3).ToString();
            p_importoProgetto.InnerText = "Importo dei lavori: " + reader.GetValue(4).ToString();
            p_statoProgetto.InnerText = "Stato dei lavori: " + reader.GetValue(5).ToString();

            projectDescription.Controls.Add(p_presentazioneProgetto);
            projectDescription.Controls.Add(fascia);
            projectDescription.Controls.Add(p_descrizioneProgetto);
            projectDescription.Controls.Add(p_dettaglioProgetto);
            projectDescription.Controls.Add(fascia2);
            projectDescription.Controls.Add(p_committenteProgetto);
            //projectDescription.Controls.Add(p_importoProgetto);
            projectDescription.Controls.Add(p_statoProgetto);

            dettaglioWrapper.Controls.Add(projectDescription);
        }
    }
}