using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PaiVapp.Models
{
    public class Captacion
    {
        public int CaptacionID { get; set; }
        //datos del menor
        public int TCI { get; set; }    //verifica si tiene o no CI: 1 si 2 no 99 desconoce
        public int? CI { get; set; }    //numero de CI del menor
        public string CICod { get; set; } //codigo de CI alternativo "NNAAddmmaa"
        public int RegNacimiento { get; set; } //1 si 2 no 99 desconocido
        public string PNombre { get; set; } //primer nombre
        public string SNombre { get; set; } //segundo nombre
        public string TNombre { get; set; } //tercer nombre
        public string PApellido { get; set; }   //primera apellido
        public string SApellido { get; set; }   //segundo apellido

        [DisplayName("Fecha Nacimiento"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FNacimiento { get; set; } //fecha de nacimiento del menor
        public int Sexo { get; set; }   //0 femenino 1 masculino
        public int? PaisID { get; set; }    //pais nacionalidad
        //datos de los padres
        public int CIMadre { get; set; }    //ci de madre
        public string NomApMadre { get; set; }  //nombre y apellido de la madre
        public string EmailMadre { get; set; }  //email de la madre
        public int CIPadreT { get; set; }   //ci del padre o tutor
        public string NomApPadre { get; set; }  //nombre y apellido del padre
        public string EmailPT { get; set; } //email padre o tutor
        //datos localizacion
        public int? DepartamentoID { get; set; }    //departamento de domicilio
        public int? DistritoID { get; set; }    //distrito de municipio
        public string Barrio { get; set; }  //barrio o compañia
        public string Direccion { get; set; } //direccion general
        public string ReferenciaDir { get; set; } //referencia de direccion
        public string Telefono1 { get; set; }   //telefono 1
        public string Telefono { get; set; }    //telefono 2
        public int Localidad { get; set; }      //1 urbano 2 rural 
        public int ComIndigena { get; set; }    //1 si 2 no
        public string Etnia { get; set; }   //etnia  comunidad indigena
        //datos anexos
        //alergias a vacunas y medicamentos
        public int AlergiaSN { get; set; }  //1 si 2 no 99 desconocido
        public int AlergVacuna { get; set; } //1 si 2 no  99 desconocido
        public string DescVacuna { get; set; } //descripcion alergia vacuna
        public int AlergMedic { get; set; } //1 si 2 no  99 desconocido
        public string DescMedic { get; set; } //descripcion alergia medicamento
        public int AlergOtros { get; set; } //1 si 2 no 99 desconocido
        public string DescOtros { get; set; } //descripcion alergia otros
        //estado nutricional
        public int EstadoNut { get; set; }  //1 adecuado 2 en riesgo 3 desnutrido 4 desconocido 5 no aplica
        public int Pani { get; set; } //1 si 2 no 3 desconocido 4 no aplica 
        //lactanci materna
        public int LacMaterna { get; set; } //1 exclusiva 2 complemento 3 no aplica 4 sin lactancia 
        //seguro medico
        public int SegMedico { get; set; } //1 si 2 no 99 desconocido 
        public int TSeguro { get; set; }    //1 ips 2 privado 3 otro
        public string DSeguro { get; set; } //descripcion de seguro

        public Boolean Estado { get; set; }

        public Pais Pais { get; set; }
        public Departamento Departamento { get; set;}
        public Distrito Distrito { get; set;}

        public ICollection<Registro> Registros { get; set; }
    }
}
