using ProntuarioEletronico.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o email")]
        [EmailAddress(ErrorMessage = "Email cadastrado é inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Selecione o perfil")]
        public ProfileEnum? Profile { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string Password { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool PasswordValida(string password)
        {
            return Password == password;
        }
    }
}
