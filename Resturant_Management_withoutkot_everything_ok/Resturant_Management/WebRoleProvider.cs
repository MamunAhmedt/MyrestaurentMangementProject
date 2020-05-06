using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Resturant_Management.Models;

namespace Resturant_Management
{
    public class WebRoleProvider:RoleProvider
    {

        public ApplicationDbContext Context;
        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            Context=new ApplicationDbContext();
            var id = Convert.ToInt32(roleName);
            var role = Context.ServiceMans.Single(s => s.ServiceManId == id);
            string[]result=new string[1];
            result[0] = role.Designation;
            return result;

            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}