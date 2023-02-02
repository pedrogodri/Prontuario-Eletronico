using ProntuarioEletronico.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Age { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public SexEnum? Sex { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }
        public int CPF { get; set; }
        public int RG { get; set; }
        public string? Image { get; set; }
    }
}
