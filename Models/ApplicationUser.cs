using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculation.Models
{
    public class ApplicationUser :IdentityUser
    {

        public string Vorname { get; set; }
        public string Nachname { get; set; }


    }
}
