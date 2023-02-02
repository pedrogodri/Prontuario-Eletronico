using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Domain.Entities
{
    public class Patient : Person
    {
        public int Id { get; set; }
        public int MedicalPlanId { get; set; }
        public virtual MedicalPlan? Plan { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public string Profession { get; set; }
        public string Diagnosis { get; set; }
        public int CEP { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
    }
}
