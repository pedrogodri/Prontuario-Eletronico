using ProntuarioEletronico.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Domain.IServices
{
    public interface IDoctorService : IBaseService<DoctorDTO>
    {
        Task<int> SaveFile(int id, string file);
    }
}
