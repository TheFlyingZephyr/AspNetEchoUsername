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
        private const string _DomainGroupName = "MSIAllUsers";

        //*********************************************************************
        ///
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        //*********************************************************************

        protected void Page_Load(object sender, EventArgs e)
        {
            // First find if user is logged in
            if (Context.User.Identity.IsAuthenticated)
            {
                lblWelcome.Text = "Hi " + Context.User.Identity.Name;

                //TheOldWay();
                TheNewWay();
            }
            else
            {
                // It is anonymous user, say hi to guest
                lblWelcome.Text = "Hi guest";
            }
        }

        //*********************************************************************
        ///
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        //*********************************************************************

        private void TheNewWay()
        {
            var nameParts = Context.User.Identity.Name.Split(new char[] { '\\' });

            var prinContext = new System.DirectoryServices.AccountManagement.PrincipalContext(
                System.DirectoryServices.AccountManagement.ContextType.Domain, nameParts[0]);

            var user =
                System.DirectoryServices.AccountManagement.UserPrincipal.FindByIdentity(prinContext, Context.User.Identity.Name);

            var groupy =
                System.DirectoryServices.AccountManagement.GroupPrincipal.FindByIdentity(prinContext, _DomainGroupName);

            lblGroups.Text = "You are a member of these groups: ";

            foreach (var group in GetGroupNamesNew(user))
                lblGroups.Text += group as string + "; ";

            if (user.IsMemberOf(groupy))
                lblGroupMembership.Text = "You are a member of '" + _DomainGroupName + "'";
            else
                lblGroupMembership.Text = "You are a not member of '" + _DomainGroupName + "'";
        }

        //*********************************************************************
        ///
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userPrin"></param>
        /// <returns></returns>
        /// 
        //*********************************************************************

        public ArrayList GetGroupNamesNew(System.DirectoryServices.AccountManagement.UserPrincipal userPrin)
        {
            ArrayList groups = new ArrayList();
            foreach (var group in userPrin.GetGroups())
                groups.Add(group.Name);

            return groups;
        }

        //*********************************************************************
        ///
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        //*********************************************************************

        private void TheOldWay()
        {
            lblGroups.Text = "You are a member of these groups: ";

            foreach (var group in GetGroupNamesOld())
                lblGroups.Text += group as string + "; ";

            var isInLocalGroup = Context.User.IsInRole("LOCAL");    //*** works because server local

            if (Context.User.IsInRole(_DomainGroupName))            //*** doesn't work because domain
                lblGroupMembership.Text = "You are a member of '" + _DomainGroupName + "'";
            else
                lblGroupMembership.Text = "You are a not member of '" + _DomainGroupName + "'";

        }

        //*********************************************************************
        ///
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        //*********************************************************************

        public ArrayList GetGroupNamesOld()
        {
            ArrayList groups = new ArrayList();
            foreach (var group in
                System.Web.HttpContext.Current.Request.LogonUserIdentity.Groups)
            {
                groups.Add(group.Translate(typeof
                    (System.Security.Principal.NTAccount)).ToString());
            }
            return groups;
        }

    }
}