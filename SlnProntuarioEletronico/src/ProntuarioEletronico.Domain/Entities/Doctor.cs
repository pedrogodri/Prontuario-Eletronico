using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Domain.Entities
{
    public class Doctor : Person
    {
        public int Id { get; set; }
        public int CRM { get; set; }
        public string Especialidade { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Patient>? PatientsList { get; set; }
    }
}
