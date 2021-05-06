using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.sp.medical.group.webApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string Cnpj { get; set; }

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
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string RazaoSocial { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
