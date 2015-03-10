using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cubo_Ingegneria.members
{
    public partial class upload_immagini : System.Web.UI.Page
    {
        private int idProgetto = -1;
        //retrieve the connection string from utility function
        private String connectionString = new Cubo_Ingegneria.utility.Utility().ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //retrieve the id from url and check the validity
            String id = Request.QueryString["idProgetto"];
            int Num;
            bool isNum = int.TryParse(id, out Num);
            if (isNum)
            {
                idProgetto = Num;
            }
        }

        //upload the picture in a specific folder into the server
        protected void Upload(object sender, EventArgs e)
        {
            uploadErrorLabel.Attributes["style"] = "display: block; color:green;";
            uploadErrorLabel.InnerText = "Progetto creato!";

            string nomeCartella = idProgetto.ToString();
            createFolderProgetto(nomeCartella);

            if (fileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(fileUpload1.PostedFile.FileName);
                fileUpload1.PostedFile.SaveAs(Server.MapPath("../imgProjects/" + nomeCartella + "/") + fileName);
                removeDefaultPicture();
                addImagesOnDb(fileName, true);
            }

            if (fileUpload2.HasFile)
            {
                string fileName = Path.GetFileName(fileUpload2.PostedFile.FileName);
                fileUpload2.PostedFile.SaveAs(Server.MapPath("../imgProjects/" + nomeCartella + "/") + fileName);
                addImagesOnDb(fileName, false);
            }

            if (fileUpload3.HasFile)
            {
                string fileName = Path.GetFileName(fileUpload3.PostedFile.FileName);
                fileUpload3.PostedFile.SaveAs(Server.MapPath("../imgProjects/" + nomeCartella + "/") + fileName);
                addImagesOnDb(fileName, false);
            }

            if (fileUpload4.HasFile)
            {
                string fileName = Path.GetFileName(fileUpload4.PostedFile.FileName);
                fileUpload4.PostedFile.SaveAs(Server.MapPath("../imgProjects/" + nomeCartella + "/") + fileName);
                addImagesOnDb(fileName, false);
            }

            if (fileUpload5.HasFile)
            {
                string fileName = Path.GetFileName(fileUpload5.PostedFile.FileName);
                fileUpload5.PostedFile.SaveAs(Server.MapPath("../imgProjects/" + nomeCartella + "/") + fileName);
                addImagesOnDb(fileName, false);
            }

            Response.Redirect(Request.Url.AbsoluteUri); 
        }

        //create a folder with the specific name into the server
        private void createFolderProgetto(string nameFolder)
        {
            var folder = Server.MapPath("../imgProjects/" + nameFolder);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        //connect to the database and create a new instance of immagini
        private void addImagesOnDb(String fileName, Boolean defaultPicture) {
           
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string sqlImmagine = "INSERT INTO immagini(immagini.idprogetto, immagini.path, immagini.imgdefault) VALUES(@idprogetto, @path, @default)";

                SqlCommand commandImg = new SqlCommand(sqlImmagine, con);
                commandImg.Parameters.Add("@idprogetto", SqlDbType.VarChar, 5).Value = idProgetto;
                commandImg.Parameters.Add("@path", SqlDbType.VarChar, 50).Value = "imgProjects/" + idProgetto + "/" + fileName;
                commandImg.Parameters.Add("@default", SqlDbType.Bit, 5).Value = defaultPicture;

                commandImg.CommandType = CommandType.Text;
                commandImg.ExecuteNonQuery();

                con.Close();
            }
        
        }

        //remove the instance of default picture from progetti
        private void removeDefaultPicture() {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string sqlImmagine = "DELETE FROM immagini WHERE immagini.idprogetto=@idprogetto AND immagini.imgdefault=@default";

                SqlCommand commandImg = new SqlCommand(sqlImmagine, con);
                commandImg.Parameters.Add("@idprogetto", SqlDbType.VarChar, 5).Value = idProgetto;
                commandImg.Parameters.Add("@default", SqlDbType.Bit, 5).Value = true;
                commandImg.CommandType = CommandType.Text;
                commandImg.ExecuteNonQuery();

                con.Close();
            }
        }

        //remove the picture from db
        private void removeImagesOnDb(String idImg)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string sqlImmagine = "DELETE FROM immagini WHERE immagini.id=@idimg";

                SqlCommand commandImg = new SqlCommand(sqlImmagine, con);
                commandImg.Parameters.Add("@idimg", SqlDbType.VarChar, 5).Value = idImg;
                commandImg.CommandType = CommandType.Text;
                commandImg.ExecuteNonQuery();

                con.Close();
            }

        }

        protected void indietro_click(object sender, EventArgs e)
        {
            Response.Redirect("~/members/immagini-progetto.aspx");
        }

    }
}