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
    public class UserPermission
    {
        public int UserPermissionID { get; set; }
        public string UserPermissionName { get; set; }

        public bool  Enable { get; set; }
    }
}