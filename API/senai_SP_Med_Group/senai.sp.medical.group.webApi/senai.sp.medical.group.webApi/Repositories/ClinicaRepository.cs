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
    public class ClinicaRepository : IClinicaRepository
    {
        medicalContext ctx = new medicalContext();

        public void Atualizar(int id, Clinica clinicaAtt)
        {
            throw new NotImplementedException();
        }

        public Clinica BuscarPorId(int id)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == id);
        }

        public void Cadastrar(Clinica clinica)
        {
            ctx.Clinicas.Add(clinica);
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Clinica> ListarComMedico()
        {
            return ctx.Clinicas.Include(c => c.Medicos).ToList();
        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
