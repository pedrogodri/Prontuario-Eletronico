using ProntuarioEletronico.Domain.DTO;
using ProntuarioEletronico.Domain.IRepositories;
using ProntuarioEletronico.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Application.Service.SQLServerServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;

        public DoctorService(IDoctorRepository repository)
        {
            _repository = repository;
        }   

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }

        public List<DoctorDTO> FindAll()
        {
            return _repository.FindAll()
                .Select(d => new DoctorDTO()
                {
                    id = d.Id,
                    crm = d.CRM,
                    especialidade = d.Especialidade,
                    description = d.Description,
                    name = d.Name,
                    age = d.Age,
                    email = d.Email,
                    phone = d.Phone,
                    sex = d.Sex,
                    maritalStatus = d.MaritalStatus,
                    cpf = d.CPF,
                    rg = d.RG,
                    image = d.Image,
                    dataAtualizacao = d.DataAtualizacao,
                }).ToList();
        }

        public async Task<DoctorDTO> FindById(int id)
        {
            var dto = new DoctorDTO();
            return dto.mapToDTO(await _repository.FindById(id));
        }

        public Task<int> Save(DoctorDTO entity)
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
