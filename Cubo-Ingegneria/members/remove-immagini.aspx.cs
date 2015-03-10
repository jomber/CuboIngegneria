using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Cubo_Ingegneria.members
{
    public partial class remove_immagini : System.Web.UI.Page
    {
        //retrieve the connection string from utility function
        private String connectionString = new Cubo_Ingegneria.utility.Utility().ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //retrieve both ids from url and check the validity
            String idImmagine = Request.QueryString["idImmagine"];
            String idProgetto = Request.QueryString["idProgetto"];

            int Num;
            bool isNum = int.TryParse(idImmagine, out Num);
            if (isNum)
            {
                deleteImmagine(idImmagine);
            }

            isNum = int.TryParse(idProgetto, out Num);

            if (isNum)
            {
                loadImmagini(idProgetto);
            }  
        }

        //load all immagini from all projects progetti
        private void loadImmagini(String idProgetto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //retrieve all details from immagini
                string query = "SELECT immagini.id, immagini.idprogetto, immagini.path, immagini.imgdefault " +
                                "FROM immagini " +
                                "WHERE immagini.idprogetto = '"+ idProgetto +"'";

                using (SqlCommand command = new SqlCommand(query, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    HtmlGenericControl ulProgetti = new HtmlGenericControl("ul");

                    while (reader.Read())
                    {
                        createHtmlprogetti(ulProgetti, reader, "remove-immagini.aspx?idProgetto=" + idProgetto + "&idImmagine=", "../images/delete.png");
                    }

                    progettiDelete.Controls.Add(ulProgetti);
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
            labelNomeProgetto.InnerText = reader.GetValue(0).ToString();
            divImgProgetto.Attributes.Add("class", "imgProgetto");
            divInfoProgetto.Attributes.Add("class", "infoProgetto");

            imgProgetto.Attributes.Add("class", "imgDeleteThumb");
            imgProgetto.Attributes.Add("alt", "alt");
            imgProgetto.Attributes.Add("src", "../" + reader.GetValue(2).ToString());

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

        //send a request to the database and delete the row specified
        private void deleteImmagine(String idImmagine)
        {
            String path = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT immagini.path FROM immagini WHERE immagini.id = '" + idImmagine + "' AND immagini.imgdefault = 'false'";

                SqlCommand commandImg  = new SqlCommand(query, con);
                SqlDataReader reader = commandImg.ExecuteReader();
                while (reader.Read())
                {
                    path = Server.MapPath("../" + reader.GetValue(0).ToString());
                }

                con.Close();
                con.Open();

                String sql = "DELETE FROM immagini WHERE immagini.id = @idImmagine AND immagini.imgdefault = 'false'";

                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.Add("@idImmagine", SqlDbType.VarChar, 250).Value = idImmagine;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                con.Close();
            }

            //remove the picture from server if exists
            if (File.Exists(@"" + path + ""))
            {
                File.Delete(@"" + path + "");
            }

        }

        protected void indietro_click(object sender, EventArgs e)
        {
            Response.Redirect("~/members/immagini-progetto.aspx");
        } 
    }
}