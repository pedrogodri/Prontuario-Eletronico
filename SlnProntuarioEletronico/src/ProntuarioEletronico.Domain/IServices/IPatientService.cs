using ProntuarioEletronico.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Domain.IServices
{
    public interface IPatientService : IBaseService<PatientDTO>
    {
        Task<int> SaveFile(int id, string file);
    }
}
