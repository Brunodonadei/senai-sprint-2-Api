using senai.sp.medical.group.webApi.Contexts;
using senai.sp.medical.group.webApi.Domains;
using senai.sp.medical.group.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.sp.medical.group.webApi.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        medicalContext ctx = new medicalContext();
        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
