using ProntuarioEletronico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Domain.IRepositories
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Task<int> SaveFile(int id, string fileName);
    }
}
