﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class Dosis
    {
        public int DosisID { get; set; }
        [Require]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Ejemplo '1er Dosis' o '1er Refuerzo'")]
        [Display(Name = "Dosis")]
        public string NDosis { get; set; }
        [Require]
        public Boolean Estado { get; set; }

        public ICollection<DosisBiologico> DosisBiologico { get; set; }
    }
}
