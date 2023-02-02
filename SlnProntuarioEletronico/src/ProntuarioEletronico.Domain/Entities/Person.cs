using ProntuarioEletronico.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o seu nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite a sua idade")]
        public DateTime Age { get; set; }
        [Required(ErrorMessage = "Digite o seu email")]
        [EmailAddress(ErrorMessage = "Email cadastrado é inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o seu telefone")]
        [Phone(ErrorMessage = "Celular cadastrado é inválido")]
        public int Phone { get; set; }
        [Required(ErrorMessage = "Selecione o seu sexo")]
        public SexEnum? Sex { get; set; }
        [Required(ErrorMessage = "Selecione o seu estado civil")]
        public MaritalStatus? MaritalStatus { get; set; }
        [Required(ErrorMessage = "Digite o seu CPF")]
        [MinLength(11, ErrorMessage = "CPF são 11 dígitos")]
        [MaxLength(11, ErrorMessage = "CPF são 11 dígitos")]
        public int CPF { get; set; }
        [Required(ErrorMessage = "Digite o seu RG")]
        [MinLength(7, ErrorMessage = "RG são 7 dígitos")]
        [MaxLength(7, ErrorMessage = "RG são 7 dígitos")]
        public int RG { get; set; }
        [Required(ErrorMessage = "Selecione uma foto sua")]
        public string? Image { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
