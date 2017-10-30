using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class Edad
    {
        public int ID { get; set; }
        [Require]
        public string NEdad { get; set; }

        public int Semanas { get; set; }
        [Require]
        public Boolean Estado { get; set; }

        public ICollection<DosisBiologico> DosisBiologico { get; set; }
    }
}
