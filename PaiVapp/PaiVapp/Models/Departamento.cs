using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class Departamento
    {
        public int ID { get; set; }
        [Require]
        public int CodDepartamento { get; set; }
        [Require]
        public string NDepartamento { get; set; }
        [Require]
        public Boolean Estado { get; set; }

        public Pais Pais { get; set; }
        public ICollection<Distrito> Distrito { get; set; }
    }
}
