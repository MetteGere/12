using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace AA.Models
{
    public class Kategori
    {
        
        public int ID { get; set; }

        [Display(Name = "Category")]
        public string Name { get; set; }

    }
}