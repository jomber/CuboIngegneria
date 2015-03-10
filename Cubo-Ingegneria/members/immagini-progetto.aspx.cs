using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Cubo_Ingegneria.members
{
    public partial class immagini_progetto : System.Web.UI.Page
    {
        //retrieve the connection string from utility function
        private String connectionString = new Cubo_Ingegneria.utility.Utility().ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadProgetti();
        }

        //retrieve all progetti from the database
        private void loadProgetti()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT progetti.id, progetti.titolo, progetti.presentazione, progetti.committente, progetti.importo, progetti.stato, progetti.anno, immagini.id, immagini.idprogetto, immagini.path, immagini.imgdefault " +
                                "FROM progetti INNER JOIN immagini ON progetti.id=immagini.idprogetto " +
                                "WHERE immagini.imgdefault = '1'";

                using (SqlCommand command = new SqlCommand(query, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    HtmlGenericControl ulProgetti = new HtmlGenericControl("ul");
                    HtmlGenericControl ulProgettiRemove = new HtmlGenericControl("ul");

                    while (reader.Read())
                    {
                        createHtmlprogetti(ulProgetti, reader, "upload-immagini.aspx?idProgetto=", "../images/upload.png");
                        createHtmlprogetti(ulProgettiRemove, reader, "remove-immagini.aspx?idProgetto=", "../images/uploadRemove.png");
                    }

                    progettiUpload.Controls.Add(ulProgetti);
                    progettiUploadRemove.Controls.Add(ulProgettiRemove);
                }
                con.Close();
            }
        }

        //create the html structure of progetti
        private void createHtmlprogetti(HtmlGenericControl ulProgetti, SqlDataReader reader, String pageLink, String imgPath)
        {

            HtmlGenericControl liProgetti = new HtmlGenericControl("li");
            HtmlGenericControl divNomeProgetto = new HtmlGenericControl("div");
            HtmlGenericControl labelNomeProgetto = new HtmlGenericControl("label");
            HtmlGenericControl divImgProgetto = new HtmlGenericControl("div");
            HtmlGenericControl divInfoProgetto = new HtmlGenericControl("div");
            HtmlGenericControl imgProgetto = new HtmlGenericControl("img");
            HtmlGenericControl imgDelete = new HtmlGenericControl("img");

            HtmlGenericControl a = new HtmlGenericControl("a");

            divNomeProgetto.Attributes.Add("class", "progettoNome");
            labelNomeProgetto.Attributes.Add("class", "progettoTitoloLabel");
            labelNomeProgetto.InnerText = reader.GetValue(1).ToString();
            divImgProgetto.Attributes.Add("class", "imgProgetto");
            divInfoProgetto.Attributes.Add("class", "infoProgetto");

            imgProgetto.Attributes.Add("class", "imgDeleteThumb");
            imgProgetto.Attributes.Add("alt", "alt");
            imgProgetto.Attributes.Add("src", "../" + reader.GetValue(9).ToString());

            imgDelete.Attributes.Add("class", "imgDeleteThumbHover");
            imgDelete.Attributes.Add("alt", "alt");
            imgDelete.Attributes.Add("src", imgPath);

            a.Attributes.Add("href", pageLink + reader.GetValue(0));

            divNomeProgetto.Controls.Add(labelNomeProgetto);
            divImgProgetto.Controls.Add(a);

            a.Controls.Add(imgProgetto);
            a.Controls.Add(imgDelete);

            liProgetti.Controls.Add(divNomeProgetto);
            liProgetti.Controls.Add(divImgProgetto);
            liProgetti.Controls.Add(divInfoProgetto);

            ulProgetti.Controls.Add(liProgetti);
        }

        protected void indietro_click(object sender, EventArgs e)
        {
            Response.Redirect("~/members/creazione-progetto.aspx");
        }

    }
}