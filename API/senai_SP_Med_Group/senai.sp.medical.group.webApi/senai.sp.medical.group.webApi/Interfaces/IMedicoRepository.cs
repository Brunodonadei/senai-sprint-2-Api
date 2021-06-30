using senai.sp.medical.group.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.sp.medical.group.webApi.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> ListarTodos();
        Medico BuscarPorId(int id);
        void Cadastrar(Medico medico);
        void Atualizar(int id, Medico medicoAtt);
        void Deletar(int id);
        List<Medico> ListarComEspecialidade();
    }
}
