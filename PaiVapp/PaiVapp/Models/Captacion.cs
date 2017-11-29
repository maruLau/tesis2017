using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PaiVapp.Models
{
    public class Captacion
    {
        public int CaptacionID { get; set; }
        //datos del menor
        public int CI { get; set; }
        public int CICod { get; set; }
        public Boolean RegNacimiento { get; set; }
        public string PNombre { get; set; }
        public string SNombre { get; set; }
        public string TNombre { get; set; }
        public string PApellido { get; set; }
        public string SApellido { get; set; }
        public DateTime FNacimiento { get; set; }
        public int Sexo { get; set; }
        public int? PaisID { get; set; }
        //datos de los padres
        public int CIMadre { get; set; }
        public string NomApMadre { get; set; }
        public string EmailMadre { get; set; }
        public int CIPadreT { get; set; }
        public string NomApPadre { get; set; }
        public string EmailPT { get; set; }
        //datos localizacion
        public int? DepartamentoID { get; set; }
        public int? DistritoID { get; set; }
        public string Barrio { get; set; }
        public string Direccion { get; set; }
        public string ReferenciaDir { get; set; }
        public string Telefono { get; set; }
        public int Localidad { get; set; }
        public int ComIndigena { get; set; }
        public string TComIndigena { get; set; }
        //datos anexos
        public int AlergiaSN { get; set; }
        public string AlergVacuna { get; set; }
        public string AlerMedic { get; set; }
        public int AlergOtros { get; set; }
        public string DescOtros { get; set; }
        public int EstadoNut { get; set; }
        public int Pani { get; set; }
        public int LacMaterna { get; set; }
        public int SegMedico { get; set; }
        public int TSeguro { get; set; }
        public string DSeguro { get; set; }

        public Boolean Estado { get; set; }

        public Pais Pais { get; set; }
        public Departamento Departamento { get; set;}
        public Distrito Distrito { get; set;}
    }
}
