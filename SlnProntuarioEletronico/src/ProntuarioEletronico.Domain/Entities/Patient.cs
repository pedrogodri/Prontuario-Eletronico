using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Domain.Entities
{
    public class Patient : Person
    {
        public int Id { get; set; }
        public int? MedicalPlanId { get; set; }
        public virtual MedicalPlan? Plan { get; set; }
        public int? DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }
        [Required(ErrorMessage = "Digite a sua profissão")]
        public string Profession { get; set; }
        [Required(ErrorMessage = "Digite o(s) seu(s) diagnóstico(s)")]
        public string Diagnosis { get; set; }
        [Required(ErrorMessage = "Digite o seu CEP")]
        public int CEP { get; set; }
        [Required(ErrorMessage = "Digite o seu endereço")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Digite o número da residência")]
        public int Number { get; set; }
        public string? Complement { get; set; }
    }
}
