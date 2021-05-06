using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.sp.medical.group.webApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string NomePaciente { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string Cep { get; set; }


        public string Complemento { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string Telefone { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
