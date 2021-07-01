using senai_peoples_webApi.Contexts;
using senai_peoples_webApi.Domains;
using senai_peoples_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        peoplesContext ctx = new peoplesContext();
        public void Atualizar(int id, Funcionario funcionarioAtt)
        {
            Funcionario funBuscado = ctx.Funcionarios.Find(id);

            if (funcionarioAtt.Nome != null)
            {
                funBuscado.Nome = funcionarioAtt.Nome;
            }

            if (funcionarioAtt.Sobrenome != null)
            {
                funBuscado.Sobrenome = funcionarioAtt.Sobrenome;
            }

            ctx.Funcionarios.Update(funBuscado);

            ctx.SaveChanges();
        }

        public Funcionario BuscarPorId(int id)
        {
            return ctx.Funcionarios.FirstOrDefault(f => f.IdFuncionario == id);
        }

        public void Cadastrar(Funcionario funcionario)
        {
            ctx.Funcionarios.Add(funcionario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Funcionarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Funcionario> ListarTodos()
        {
            return ctx.Funcionarios.ToList();
        }
    }
}
