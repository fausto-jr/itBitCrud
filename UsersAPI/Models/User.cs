using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersAPI.Models
{
    public class User
    {
        public int UsuarioId {get; set;}

        public string Nome { get; set;}

        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public int Ativo { get; set; }
        
        public int SexoId { get; set; }

    }
}