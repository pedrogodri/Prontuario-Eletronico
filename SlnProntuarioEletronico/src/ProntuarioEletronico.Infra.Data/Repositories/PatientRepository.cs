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
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        private readonly SQLServerContext _context;

        public PatientRepository(SQLServerContext context)
            : base (context)
        {
            _context = context;
        }

        public async Task<int> SaveFile(int id, string fileName)
        {
            string sqlCommand = $"UPDATE [dbo].[Patients] SET Image = '{fileName}' WHERE Id = {id}";
            return await this.ExecuteCommand(sqlCommand);
        }
    }
}
