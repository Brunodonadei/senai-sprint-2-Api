﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.sp.medical.group.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public int? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
