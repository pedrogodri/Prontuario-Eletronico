using ProntuarioEletronico.Domain.Entities;
using ProntuarioEletronico.Domain.IRepositories;
using ProntuarioEletronico.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Infra.Data.Repositories
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        private readonly SQLServerContext _context;

        public DoctorRepository(SQLServerContext context) 
            : base(context)
        {
            _context = context;
        }

        public async Task<int> SaveFile(int id, string fileName)
        {
            string sqlCommand = $"UPDATE [dbo].[Doctors] SET Image = '{fileName}' WHERE Id = {id}";
            return await this.ExecuteCommand(sqlCommand);
        }
    }
}
