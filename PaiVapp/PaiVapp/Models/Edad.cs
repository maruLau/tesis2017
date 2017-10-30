﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class Edad
    {
        public int ID { get; set; }
        [Require]
        [StringLength(15, MinimumLength=5, ErrorMessage ="Ejemplo 'Menor 1 año' o '5 Años'")]
        public string NEdad { get; set; }
        [Require]
        [Range(0, 521)]
        public int Semanas { get; set; }
        [Require]
        public Boolean Estado { get; set; }

        public ICollection<DosisBiologico> DosisBiologico { get; set; }
    }
}
