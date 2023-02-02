using ProntuarioEletronico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Domain.DTO
{
    public class MedicalPlanDTO
    {
        [DisplayName("Id")]
        public int id { get; set; }
        public string plan { get; set; }
        public virtual ICollection<Patient>? patientsList { get; set; }   
        
        public MedicalPlan mapToEntity()
        {
            return new MedicalPlan
            {
                Id = this.id,
                Plan = this.plan
            };
        }

        public MedicalPlanDTO mapToDTO(MedicalPlan medicalPlan) 
        {
            return new MedicalPlanDTO
            {
                id= medicalPlan.Id,
                plan = medicalPlan.Plan
            };
        }
    }
}
