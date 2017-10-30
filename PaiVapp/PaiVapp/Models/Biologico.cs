using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class Biologico
    {
        public int ID { get; set; }
        [Require]
        public string NBiologico { get; set; }

        public string Descripcion { get; set; }
        [Require]
        public Boolean Estado { get; set; }

        public ICollection<DosisBiologico> DosisBiologico { get; set; }
    }
}
