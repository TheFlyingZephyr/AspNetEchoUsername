using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetEchoUsername
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // First find if user is logged in
            if (Context.User.Identity.IsAuthenticated)
            {
                // Finds user name and says Hi
                lblWelcome.Text = "Hi " + Context.User.Identity.Name;
            }
            else
            {
                // It is anonymous user, say hi to guest
                lblWelcome.Text = "Hi guest";
            }
        }
    }
}