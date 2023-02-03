using ProntuarioEletronico.Domain.DTO;
using ProntuarioEletronico.Domain.IRepositories;
using ProntuarioEletronico.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Application.Service.SQLServerServices
{
    public class MedicalPlanService : IMedicalPlanService
    {
        private readonly IMedicalPlanRepository _repository;

        public MedicalPlanService(IMedicalPlanRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }

        public List<MedicalPlanDTO> FindAll()
        {
            return _repository
                .FindAll()
                .Select(m => new MedicalPlanDTO()
                {
                    id = m.Id,
                    plan = m.Plan,
                }).ToList();
        }

        public async Task<MedicalPlanDTO> FindById(int id)
        {
            var dto = new MedicalPlanDTO();
            return dto.mapToDTO(await _repository.FindById(id));
        }

        public Task<int> Save(MedicalPlanDTO entity)
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
    }
}
