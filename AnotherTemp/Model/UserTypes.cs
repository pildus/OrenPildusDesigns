using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace DataControl.Model
{
    public class UserType
    {
        public int UserTypeID { get; set; }
        public string UserTypeName { get; set; }

        List<UserPermission> UserTypePermissions { get; set; } = new List<UserPermission>() { 
            new UserPermission(){ UserPermissionName="IsAdmin" },
            new UserPermission(){ UserPermissionName="IsModerator" },
            new UserPermission(){ UserPermissionName="IsCustomer" }

            };
    }
}