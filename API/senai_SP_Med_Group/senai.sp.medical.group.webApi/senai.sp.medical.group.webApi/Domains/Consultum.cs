using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.sp.medical.group.webApi.Domains
{
    public partial class Consultum
    {
        public int IdConsulta { get; set; }

        public int? IdMedico { get; set; }

        public int? IdPaciente { get; set; }

        public int? IdSituacao { get; set; }

        [Required(ErrorMessage = "É necessário informar um quando a consulta irá ocorrer.")]
        public DateTime DataConsulta { get; set; }

        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
