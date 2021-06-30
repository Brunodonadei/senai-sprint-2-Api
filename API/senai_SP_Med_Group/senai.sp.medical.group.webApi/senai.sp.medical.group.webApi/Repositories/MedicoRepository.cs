using Microsoft.EntityFrameworkCore;
using senai.sp.medical.group.webApi.Contexts;
using senai.sp.medical.group.webApi.Domains;
using senai.sp.medical.group.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.sp.medical.group.webApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        medicalContext ctx = new medicalContext();
        public void Atualizar(int id, Medico medicoAtt)
        {
            throw new NotImplementedException();
        }

        public Medico BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Medico medico)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Medico> ListarComEspecialidade()
        {
            return ctx.Medicos

                .Include(m => m.IdEspecialidadeNavigation).ToList();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos.ToList();
        }
    }
}
