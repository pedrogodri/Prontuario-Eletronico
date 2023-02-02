using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Domain.Entities
{
    public class MedicalPlan
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o convênio")]
        public string Plan { get; set; }
        public virtual ICollection<Patient>? PatientsList { get; set; }
    }
}
