using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cubo_Ingegneria.members
{
    public partial class creazione_progetto : System.Web.UI.Page
    {
        //retrieve the connection string from utility function
        private String connectionString = new Cubo_Ingegneria.utility.Utility().ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //validate all field for creating the project progetto and send the request to the database
        protected void Create(object sender, EventArgs e)
        {
            bool validation = false;
            if (createDescrizioneProgetto.Text == "") { descrizioneProgettoLabel.Attributes["style"] = "color:red;"; validation = true; }
            if (createNomeProgetto.Text == "") { nomeProgettoLabel.Attributes["style"] = "color:red;"; validation = true; }
            if (createCommittente.Text == "") { committenteLabel.Attributes["style"] = "color:red;"; validation = true; }
            if (createAnno.Text == "") { annoLabel.Attributes["style"] = "color:red;"; validation = true; }
            if (createStato.Text == "") { statoLabel.Attributes["style"] = "color:red;"; validation = true; }

            if (validation)
            {
                createErrorLabel.Attributes["style"] = "display: block; color:red;";
                createErrorLabel.InnerText = "Inserire tutti i campi!";
            }
            else
            {
                createErrorLabel.Attributes["style"] = "display: block; color:green;";
                createErrorLabel.InnerText = "Progetto creato!";
                descrizioneProgettoLabel.Attributes["style"] = "color:white;";
                nomeProgettoLabel.Attributes["style"] = "color:white;";
                committenteLabel.Attributes["style"] = "color:white;";
                annoLabel.Attributes["style"] = "color:white;";
                statoLabel.Attributes["style"] = "color:white;";

                //send the request to the database to create a new progetto
                createProgetto(createNomeProgetto.Text, createDescrizioneProgetto.Text, createCommittente.Text, "0", createStato.Text, createAnno.Text);

                createDescrizioneProgetto.Text = "";
                createNomeProgetto.Text = "";
                createAnno.Text = "";
                createCommittente.Text = "";
                createStato.Text = "";

            }
        }

        //create a new instance of progetti with the details passed from form
        private void createProgetto(String titolo, String presentazione, String committente, String importo, String stato, String anno)
        {
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string sqlProgetto = "INSERT INTO progetti(progetti.titolo, progetti.presentazione, progetti.committente, progetti.importo, progetti.stato, progetti.anno) OUTPUT INSERTED.ID VALUES(@titolo, @presentazione, @committente, @importo, @stato, @anno)";
                string sqlImmagine = "INSERT INTO immagini(immagini.idprogetto, immagini.path, immagini.imgdefault) VALUES(@idprogetto, @path, @default)";

                SqlCommand command = new SqlCommand(sqlProgetto, con);
                command.Parameters.Add("@titolo", SqlDbType.VarChar, 250).Value = titolo;
                command.Parameters.Add("@presentazione", SqlDbType.VarChar, 250).Value = presentazione;
                command.Parameters.Add("@committente", SqlDbType.VarChar, 1000).Value = committente;
                command.Parameters.Add("@importo", SqlDbType.VarChar, 150).Value = importo;
                command.Parameters.Add("@stato", SqlDbType.VarChar, 150).Value = stato;
                command.Parameters.Add("@anno", SqlDbType.VarChar, 50).Value = anno;
                command.CommandType = CommandType.Text;

                String newId = command.ExecuteScalar().ToString();

                //new connection and query Immagini
                SqlCommand commandImg = new SqlCommand(sqlImmagine, con);
                commandImg.Parameters.Add("@idprogetto", SqlDbType.VarChar, 5).Value = newId;
                commandImg.Parameters.Add("@path", SqlDbType.VarChar, 50).Value = "imgProjects/projectDefault.png";
                commandImg.Parameters.Add("@default", SqlDbType.Bit, 5).Value = true;

                commandImg.CommandType = CommandType.Text;
                commandImg.ExecuteNonQuery();
                
                con.Close();
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