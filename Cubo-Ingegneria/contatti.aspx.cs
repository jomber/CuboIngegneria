using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;

namespace Cubo_Ingegneria
{
    public partial class contatti : System.Web.UI.Page
    {
        utility.Utility utility = new utility.Utility();
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        //validate all fields and insert 'richiesta' into the database
        protected void SendEmail(object sender, EventArgs e)
        {
            bool validation = false;
            if (mailingNome.Text == "") { mailingNomeLabel.Attributes["style"] = "color:red;"; validation = true; }
            if (mailingCognome.Text == "") { mailingCognomeLabel.Attributes["style"] = "color:red;"; validation = true; }
            if (mailingEmail.Text == "") { mailingEmailLabel.Attributes["style"] = "color:red;"; validation = true; }
            if (mailingTelefono.Text == "") { mailingTelefonoLabel.Attributes["style"] = "color:red;"; validation = true; }
            if (mailingOggetto.Text == "") { mailingOggettoLabel.Attributes["style"] = "color:red;"; validation = true; }
            if (mailingTesto.Text == "") { mailingTestoLabel.Attributes["style"] = "color:red;"; validation = true; }
            if (contact_privacy.Checked == false) { privacyLabel.Attributes["style"] = "color:red;"; validation = true; }
            
            if (validation) {
                validitaCampi.Attributes["style"] = "display: block; color:red;";
                validitaCampi.InnerText = "CAMPI NON VALIDI!";
                
            }
            else {
                validitaCampi.Attributes["style"] = "display: block; color:green;";
               
                validitaCampi.InnerText = "RICHIESTA INVIATA!";
                
                mailingNomeLabel.Attributes["style"] = "color:white;";
                mailingCognomeLabel.Attributes["style"] = "color:white;";
                mailingEmailLabel.Attributes["style"] = "color:white;";
                mailingTelefonoLabel.Attributes["style"] = "color:white;";
                mailingOggettoLabel.Attributes["style"] = "color:white;";
                mailingTestoLabel.Attributes["style"] = "color:white;";
                privacyLabel.Attributes["style"] = "color:white;";

                //insert 'richiesta' into the database
                insertRichieste(mailingNome.Text, mailingCognome.Text, mailingEmail.Text, mailingIndirizzo.Text, mailingCitta.Text,  mailingTelefono.Text, mailingOggetto.Text, mailingTesto.Text);

                mailingNome.Text = "";
                mailingCognome.Text = "";
                mailingEmail.Text = "";
                mailingTelefono.Text = "";
                mailingOggetto.Text = "";
                mailingTesto.Text = "";
                mailingCitta.Text = "";
                mailingIndirizzo.Text = "";
                contact_privacy.Checked = false;
                
            }
        }

        //connect to the database and add a new field
        private void insertRichieste(string nome, string cognome, string email, string indirizzo, string citta, string telefono, string oggetto, string testo) {

            //retrieve the connection string from utility function
            String connectionString = utility.ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);
            
            string sql = "INSERT INTO richieste(nome, cognome, email, indirizzo, citta, telefono, oggetto, testo) VALUES(@nome, @cognome, @email, @indirizzo, @citta, @telefono, @oggetto, @testo)";

            try
            {
                conn.Open();
                
                SqlCommand cmd;
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@cognome", cognome);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@indirizzo", indirizzo);
                cmd.Parameters.AddWithValue("@citta", citta);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@oggetto", oggetto);
                cmd.Parameters.AddWithValue("@testo", testo);
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}