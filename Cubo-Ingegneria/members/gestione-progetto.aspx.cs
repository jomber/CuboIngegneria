using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace Cubo_Ingegneria.members
{
    public partial class gestione_progetto : System.Web.UI.Page
    {
        //retrieve the connection string from utility function
        private String connectionString = new Cubo_Ingegneria.utility.Utility().ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //retrieve the id from url and check the validity
            String idProgetto = Request.QueryString["idProgetto"];
            int Num;
            bool isNum = int.TryParse(idProgetto, out Num);
            if (isNum && !IsPostBack)
            {
                loadProgetto(idProgetto);
            }
        }

        //load the project progetto from the database with the id passed
        private void loadProgetto(String idProgetto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //retrieve all information about a specific project
                string query = "SELECT progetti.id, progetti.titolo, progetti.presentazione, progetti.committente, progetti.importo, progetti.stato, progetti.anno, immagini.id, immagini.idprogetto, immagini.path, immagini.imgdefault " +
                                "FROM progetti INNER JOIN immagini ON progetti.id=immagini.idprogetto " +
                                "WHERE immagini.imgdefault = '1' AND progetti.id = '"+ idProgetto +"'";

                using (SqlCommand command = new SqlCommand(query, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        uploadNomeProgetto.Text = reader.GetValue(1).ToString();
                        uploadDescrizioneProgetto.Text = reader.GetValue(2).ToString();
                        uploadCommittente.Text = reader.GetValue(3).ToString();
                        uploadStato.Text = reader.GetValue(5).ToString();
                        uploadAnno.Text = reader.GetValue(6).ToString();
                    }

                }
                con.Close();
            }
        }

        //edit details of project and send the request to database
        private void editProgetto(String idProgetto, String titolo, String presentazione, String committente, String importo, String stato, String anno) {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string sql = "UPDATE progetti SET progetti.titolo = @titolo, progetti.presentazione = @presentazione, progetti.committente = @committente, progetti.importo = @importo, progetti.stato = @stato, progetti.anno = @anno WHERE progetti.id = @idProgetto";
                
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.Add("@idProgetto", SqlDbType.VarChar, 50).Value = idProgetto; 
                command.Parameters.Add("@titolo", SqlDbType.VarChar, 250).Value = titolo;  
                command.Parameters.Add("@presentazione", SqlDbType.VarChar, 250).Value = presentazione;
                command.Parameters.Add("@committente", SqlDbType.VarChar, 1000).Value = committente;
                command.Parameters.Add("@importo", SqlDbType.VarChar, 150).Value = importo;
                command.Parameters.Add("@stato", SqlDbType.VarChar, 150).Value = stato;
                command.Parameters.Add("@anno", SqlDbType.VarChar, 50).Value = anno;
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();

                con.Close();
            }
        }

        //validate all field before to send the request to the database
        protected void Edit(object sender, EventArgs e)
        {
            bool validation = false;
            
            if (uploadNomeProgetto.Text == "") { nomeProgettoLabel.Attributes["style"] = "color:red;"; validation = true; }
            if (uploadDescrizioneProgetto.Text == "") { descrizioneProgettoLabel.Attributes["style"] = "color:red;"; validation = true; }
            if (uploadCommittente.Text == "") { committenteLabel.Attributes["style"] = "color:red;"; validation = true; }
            if (uploadAnno.Text == "") { annoLabel.Attributes["style"] = "color:red;"; validation = true; }
            if (uploadStato.Text == "") { statoLabel.Attributes["style"] = "color:red;"; validation = true; }

            if (validation)
            {
                uploadErrorLabel.Attributes["style"] = "display: block; color:red;";
                uploadErrorLabel.InnerText = "Inserire tutti i campi!";

            }
            else
            {
                uploadErrorLabel.Attributes["style"] = "display: block; color:green;";
                uploadErrorLabel.InnerText = "Modifica progetto eseguita!";
                descrizioneProgettoLabel.Attributes["style"] = "color:white;";
                nomeProgettoLabel.Attributes["style"] = "color:white;";
                committenteLabel.Attributes["style"] = "color:white;";
                annoLabel.Attributes["style"] = "color:white;";
                statoLabel.Attributes["style"] = "color:white;";

                String idProgetto = Request.QueryString["idProgetto"];
                int Num;
                bool isNum = int.TryParse(idProgetto, out Num);
                if (isNum)
                {
                    //send the request to the database
                    editProgetto(idProgetto, uploadNomeProgetto.Text, uploadDescrizioneProgetto.Text, uploadCommittente.Text, "0", uploadStato.Text, uploadAnno.Text);

                }

                uploadDescrizioneProgetto.Text = "";
                uploadNomeProgetto.Text = "";
                uploadAnno.Text = "";
                uploadCommittente.Text = "";
                uploadStato.Text = "";

                Response.Redirect("~/members/creazione-progetto.aspx");
            }
        }

        protected void modifica_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/members/modifica-progetto.aspx");
        }

        protected void cancella_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/members/cancella-progetto.aspx");
        }

        protected void immagini_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/members/immagini-progetto.aspx");
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/home.aspx");
        }
    }
}