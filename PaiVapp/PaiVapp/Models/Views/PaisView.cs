using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models.Views
{
    public class PaisView
    {
        [Display(Name = "Cod")]
        public int PaisID { get; set; }
   
        [Display(Name = "Pais")]
        public string NPais { get; set; }
     
        [Display(Name = "Nacionalidad")]
        public string Nacionalidad { get; set; }

        [Display(Name = "Estado")]
        public Boolean Estado { get; set; }
    }
}
