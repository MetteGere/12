using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AA.Models
{
    public class Bil
    {
        public int ID { get; set; }
        public string Model { get; set; }

        [Display(Name = "Year")]
        public int Argang { get; set; }

        [Display(Name = "Brand")]
        public Marke Marke { get; set;  }
        
        [Display(Name = "Mærke")]
        public int MarkeID { get; set; }

        
        public Kategori Kategori { get; set; }
        
        [Display(Name = "Category")]
        public int KategoriID { get; set; }

    

    }
}
