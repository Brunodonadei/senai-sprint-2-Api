using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "E-mail do usuário é necessário.")]
        public string email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Número de caracteres insuficiente, sua senha precisa ter no mínimo 3 caracteres.")]
        public string senha { get; set; }

        public int idTipoUsuario { get; set; }
    }
}



