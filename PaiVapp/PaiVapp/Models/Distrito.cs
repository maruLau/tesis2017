using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class Distrito
    {
        public int ID { get; set; }
        [Require]
        public int CodDistrito { get; set; }
        [Require]
        public string NDistrito { get; set; }
        [Require]
        public Boolean Estado { get; set; }

        public  Departamento Departamento {get;set;}
    }
}
