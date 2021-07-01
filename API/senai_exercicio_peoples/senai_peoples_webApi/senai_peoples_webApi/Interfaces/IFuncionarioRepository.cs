using senai_peoples_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<Funcionario> ListarTodos();
        Funcionario BuscarPorId(int id);
        void Deletar(int id);
        void Atualizar(int id, Funcionario funcionarioAtt);
        void Cadastrar(Funcionario funcionario);

    }
}
