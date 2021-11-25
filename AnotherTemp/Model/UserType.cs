using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataControl.Utils;

namespace DataControl.Model
{

    public class UserType
    {
        [Key]
        public int UserTypeId { get; set; }
        [Required]
        public string UserTypeDescription { get; set; }

    }
}
