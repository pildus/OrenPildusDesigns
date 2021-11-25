using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataControl.Model;
using DataControl.Utils;
using DataControl.DataAccess;
using System.Net.Mail;

namespace DataControl
{
    class Program
    {
        static void Main(string[] args)
        {
           PopulateDB.PopulateAll();
        }
    }
}