using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Domain.Entities
{
    public class Doctor : Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o seu CRM")]
        public int CRM { get; set; }
        [Required(ErrorMessage = "Digite a sua especialidade")]
        public string Especialidade { get; set; }
        [Required(ErrorMessage = "Digite a sua descrição")]
        public string Description { get; set; }
        public virtual ICollection<Patient>? PatientsList { get; set; }
    }
}
