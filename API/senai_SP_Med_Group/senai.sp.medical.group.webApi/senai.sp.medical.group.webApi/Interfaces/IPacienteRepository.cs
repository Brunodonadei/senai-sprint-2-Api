using senai.sp.medical.group.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.sp.medical.group.webApi.Interfaces
{
    interface IPacienteRepository
    {
        List<Paciente> ListarTodos();
    }
}
