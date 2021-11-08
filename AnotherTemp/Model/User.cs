﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataControl.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string  Password { get; set; }
        
        [Required]
        public string EmailAddress { get; set; }

        public bool? IsAdmin { get; set; } = false;



        public virtual List<Order> ShoppingCart { get; set; } = new List<Order>();


    }
}