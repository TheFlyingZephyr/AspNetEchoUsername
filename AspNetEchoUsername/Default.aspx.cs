using System;
using System.Collections;
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

                var bb = Context.User.IsInRole("LOCAL");
                var cc = Context.User.IsInRole("TheBobs");

                lblGroups.Text = "You are a member of these groups: ";

                foreach (var group in GetGroups())
                {
                    //    lbGroups.Items.Add(group as string);
                    lblGroups.Text += group as string + "; ";
                }
            }
            else
            {
                // It is anonymous user, say hi to guest
                lblWelcome.Text = "Hi guest";
            }
        }

        public ArrayList GetGroups()
        {
            ArrayList groups = new ArrayList();
            foreach (System.Security.Principal.IdentityReference group in
                System.Web.HttpContext.Current.Request.LogonUserIdentity.Groups)
            {
                groups.Add(group.Translate(typeof
                    (System.Security.Principal.NTAccount)).ToString());
            }
            return groups;
        }

    }
}