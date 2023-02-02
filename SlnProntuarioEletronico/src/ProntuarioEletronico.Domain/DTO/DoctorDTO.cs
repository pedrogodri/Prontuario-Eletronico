using ProntuarioEletronico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Domain.DTO
{
    public class DoctorDTO : PersonDTO
    {
        public int id { get; set; }
        public int crm { get; set; }
        public string especialidade { get; set; }
        public string description { get; set; }
        public virtual ICollection<Patient>? patientsList { get; set; }

        public Doctor mapToEntity()
        {
            return new Doctor()
            {
                Id = id,
                CRM = crm,
                Especialidade = especialidade,
                Description = description,
                Name = name,
                Age = age,
                Email = email,
                Phone = phone,
                Sex = sex,
                MaritalStatus = maritalStatus,
                CPF = cpf,
                RG = rg,
                Image = image,
                DataAtualizacao= dataAtualizacao,
                DataCadastro= dataCadastro,
            };
        }

        public DoctorDTO mapToDTO(Doctor doctor)
        {
            return new DoctorDTO()
            {
                id = doctor.Id,
                crm = doctor.CRM,
                especialidade = doctor.Especialidade,
                description = doctor.Description,
                name = doctor.Name,
                age = doctor.Age,
                email = doctor.Email,
                phone = doctor.Phone,
                sex = doctor.Sex,
                maritalStatus = doctor.MaritalStatus,
                cpf = doctor.CPF,
                rg = doctor.RG,
                image = doctor.Image,
                dataAtualizacao = doctor.DataAtualizacao,
                dataCadastro = doctor.DataCadastro
            };
        }
    }
}
