using ProntuarioEletronico.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Domain.DTO
{
    public class PersonDTO
    {
        public string name { get; set; }
        public DateTime age { get; set; }
        public string email { get; set; }
        public int phone { get; set; }
        public SexEnum? sex { get; set; }
        public MaritalStatus? maritalStatus { get; set; }
        public int cpf { get; set; }
        public int rg { get; set; }
        public string? image { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime? dataAtualizacao { get; set; }
    }
}
