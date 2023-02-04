using ProntuarioEletronico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Domain.DTO
{
    public class PatientDTO : PersonDTO
    {
        public int id { get; set; }
        public int? medicalPlanId { get; set; }
        public virtual MedicalPlan? plan { get; set; }
        public int? doctorId { get; set; }
        public virtual Doctor? doctor { get; set; }
        public string profession { get; set; }
        public string diagnosis { get; set; }
        public int cep { get; set; }
        public string address { get; set; }
        public int number { get; set; }
        public string? complement { get; set; }

        public Patient mapToEntity()
        {
            return new Patient()
            {
                Id = id,
                MedicalPlanId = medicalPlanId,
                Plan = plan,
                DoctorId = doctorId,
                Doctor = doctor,
                Profession = profession,
                Diagnosis = diagnosis,
                CEP = cep,
                Address = address,
                Number = number,
                Complement = complement,
                
                Name = name,
                Age = age,
                Email = email,
                Phone = phone,
                Sex = sex,
                MaritalStatus = maritalStatus,
                CPF = cpf,
                RG = rg,
                Image = image,
                DataAtualizacao = dataAtualizacao,
                DataCadastro = dataCadastro,
            };
        }

        public PatientDTO mapToDTO(Patient patient)
        {
            return new PatientDTO()
            {
                id = patient.Id,
                medicalPlanId = patient.MedicalPlanId,
                plan = patient.Plan,
                doctorId= patient.DoctorId,
                doctor = patient.Doctor,
                profession = patient.Profession,
                diagnosis = patient.Diagnosis,
                cep = patient.CEP,
                address = patient.Address,
                number = patient.Number,
                complement = patient.Complement,
                name = patient.Name,
                age = patient.Age,
                email = patient.Email,
                phone = patient.Phone,
                sex = patient.Sex,
                maritalStatus = patient.MaritalStatus,
                cpf = patient.CPF,
                rg = patient.RG,
                image = patient.Image,
                dataAtualizacao = patient.DataAtualizacao,
                dataCadastro = patient.DataCadastro
            };
        }
    }
}
