using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cubo_Ingegneria
{
    public partial class Admin : System.Web.UI.Page
    {
        //retrieve utility function
        private utility.Utility utility = new utility.Utility();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //method for authentication, Login and Password retrieved from utility function
        protected void loginForm_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if ((loginForm.UserName == utility.Username) && (loginForm.Password == utility.Password))
            {
                e.Authenticated = true;
            }
        }
    }
}