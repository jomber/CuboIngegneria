using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Cubo_Ingegneria.utility;

namespace Cubo_Ingegneria.members
{
    public partial class cancella_progetto : System.Web.UI.Page
    {
        //retrieve the connection string from utility function
        private String connectionString = new Cubo_Ingegneria.utility.Utility().ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //retrieve the id from url and check the validity
            String idProgetto = Request.QueryString["idProgetto"];
            int Num;
            bool isNum = int.TryParse(idProgetto, out Num);
            if (isNum)
            {
                //delete the project progetto with the id passed
                deleteProgetto(idProgetto);
            }
            //reload all the project without the deleted one
            loadProgetti();
        }

        //load all projects from the database
        private void loadProgetti()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                con.Open();

                //retrieve all details of progetti and immagini
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

                    progettiDelete.Controls.Add(ulProgetti);
                }
                con.Close();
            }
        }

        //create the html structure of progetti
        private void createHtmlprogetti(HtmlGenericControl ulProgetti, SqlDataReader reader)
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
            imgDelete.Attributes.Add("src", "../images/delete.png");

            a.Attributes.Add("href", "cancella-progetto.aspx?idProgetto=" + reader.GetValue(0));

            divNomeProgetto.Controls.Add(labelNomeProgetto);
            divImgProgetto.Controls.Add(a);

            a.Controls.Add(imgProgetto);
            a.Controls.Add(imgDelete);      

            liProgetti.Controls.Add(divNomeProgetto);
            liProgetti.Controls.Add(divImgProgetto);
            liProgetti.Controls.Add(divInfoProgetto);

            ulProgetti.Controls.Add(liProgetti);
        }

        //connect to database and delete the row in progetti with the id passed
        private void deleteProgetto(String idProgetto){

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string sql = "DELETE FROM progetti WHERE progetti.id = @idProgetto";
                string sqlImg = "DELETE FROM immagini WHERE immagini.idprogetto = @idProgetto";
                
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.Add("@idProgetto", SqlDbType.VarChar, 250).Value = idProgetto;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                SqlCommand commandImg = new SqlCommand(sqlImg, con);
                commandImg.Parameters.Add("@idProgetto", SqlDbType.VarChar, 250).Value = idProgetto;
                commandImg.CommandType = CommandType.Text;
                commandImg.ExecuteNonQuery();

                con.Close();
            }
        }

        protected void indietro_click(object sender, EventArgs e)
        {
            Response.Redirect("~/members/creazione-progetto.aspx");
        } 

    }
}