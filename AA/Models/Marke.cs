using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AA.Models
{
    public class Marke
    {
        
        public int ID { get; set; }
        [Display(Name = "Brand")]
        public string Name { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }

      


    }
}