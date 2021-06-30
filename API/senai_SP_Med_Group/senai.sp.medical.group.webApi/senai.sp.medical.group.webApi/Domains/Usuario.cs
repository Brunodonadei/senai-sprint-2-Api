using System;
using System.Collections.Generic;

#nullable disable

namespace senai.sp.medical.group.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Consulta = new HashSet<Consultum>();
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
