using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class Pais
    {
        public int ID { get; set; }
        [Require]
        public string NPais { get; set; }
        [Require]
        public Boolean Estado { get; set; }

        public ICollection<Departamento> Departamento { get; set; }
    }
}
