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
    public class MedicalPlanRepository : BaseRepository<MedicalPlan>, IMedicalPlanRepository
    {
        private readonly SQLServerContext _context;

        public MedicalPlanRepository(SQLServerContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
