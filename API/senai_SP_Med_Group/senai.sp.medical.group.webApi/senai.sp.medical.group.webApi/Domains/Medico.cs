using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.sp.medical.group.webApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdMedico { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public int? IdEspecialidade { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public int? IdClinica { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public int Crm { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        public string NomeMedico { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
