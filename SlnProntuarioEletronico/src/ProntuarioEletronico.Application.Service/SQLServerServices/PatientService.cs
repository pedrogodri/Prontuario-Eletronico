using ProntuarioEletronico.Domain.DTO;
using ProntuarioEletronico.Domain.Entities;
using ProntuarioEletronico.Domain.IRepositories;
using ProntuarioEletronico.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Application.Service.SQLServerServices
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }

        public List<PatientDTO> FindAll()
        {
            return _repository.FindAll()
                .Select(p => new PatientDTO()
                {
                    id = p.Id,
                    medicalPlanId = p.MedicalPlanId,
                    plan = p.Plan,
                    doctorId = p.DoctorId,
                    doctor = p.Doctor,
                    profession = p.Profession,
                    diagnosis = p.Diagnosis,
                    cep = p.CEP,
                    address = p.Address,
                    number = p.Number,
                    complement = p.Complement,

                    name = p.Name,
                    age = p.Age,
                    email = p.Email,
                    phone = p.Phone,
                    sex = p.Sex,
                    maritalStatus = p.MaritalStatus,
                    cpf = p.CPF,
                    rg = p.RG,
                    image = p.Image,
                    dataAtualizacao = p.DataAtualizacao,
                    dataCadastro = p.DataCadastro
                }).ToList();
        }

        public async Task<PatientDTO> FindById(int id)
        {
            var dto = new PatientDTO();
            return dto.mapToDTO(await _repository.FindById(id));
        }

        public Task<int> Save(PatientDTO entity)
        {
            if(entity.id > 0)
            {
                return _repository.Update(entity.mapToEntity());
            }
            else
            {
                return _repository.Save(entity.mapToEntity());
            }
        }

        public Task<int> SaveFile(int id, string file)
        {
            return _repository.SaveFile(id, file);
        }
    }
}
