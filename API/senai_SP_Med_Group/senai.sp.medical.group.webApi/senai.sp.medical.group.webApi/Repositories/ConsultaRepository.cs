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
    public class ConsultaRepository : IConsultaRepository
    {
        medicalContext ctx = new medicalContext();

        public void AgendadaCancelada(int id, string status)
        {
                Consultum consultaBuscada = ctx.Consulta

                    .Include(p => p.IdMedicoNavigation)

                    .Include(p => p.IdPacienteNavigation)

                    .Include(p => p.IdSituacaoNavigation)

                    .FirstOrDefault(p => p.IdConsulta == id);

                switch (status)
                {
                    case "1":
                        consultaBuscada.IdSituacao = 1;
                        break;

                    case "2":
                        consultaBuscada.IdSituacao = 2;
                        break;

                    case "3":
                        consultaBuscada.IdSituacao = 3;
                        break;

                    default:
                        consultaBuscada.IdSituacao = consultaBuscada.IdSituacao;
                        break;
                }

                ctx.Consulta.Update(consultaBuscada);

                ctx.SaveChanges();
        }

        public void Atualizar(int id, Consultum consultaAtt)
        {
            Consultum consultaBuscada = ctx.Consulta.Find(id);

            if (consultaAtt.IdMedico != null)
            {
                consultaBuscada.IdMedico = consultaAtt.IdMedico;
            }

            if (consultaAtt.IdPaciente != null)
            {
                consultaBuscada.IdPaciente = consultaAtt.IdPaciente;
            }

            if (consultaAtt.IdSituacao != null)
            {
                consultaBuscada.IdSituacao = consultaAtt.IdSituacao;
            }

            if (consultaAtt.DataConsulta > DateTime.Now)
            {
                consultaBuscada.DataConsulta = consultaAtt.DataConsulta;
            }

            if (consultaAtt.Descricao != null)
            {
                consultaBuscada.Descricao = consultaAtt.Descricao;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public void Cancelar(int id)
        {
            Consultum consultaBuscada = ctx.Consulta.FirstOrDefault(co => co.IdConsulta == id);

            ctx.Consulta.Remove(consultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consultum> ListarMinhas(int id)
        {
            return ctx.Consulta

                .Include(p => p.IdMedicoNavigation)

                .Include(p => p.IdPacienteNavigation)

                .Include(p => p.IdSituacaoNavigation)

                .Where(p => p.IdConsulta == id)

                .ToList();
        }

        public List<Consultum> ListarTodas()
        {
            return ctx.Consulta.ToList();
        }

        public void Marcar(Consultum inscricao)
        {
            ctx.Consulta.Add(inscricao);

            ctx.SaveChanges();
        }

        public void Prontuario(int id, Consultum novaDescricao)
        {
            Consultum consultaBuscada = ctx.Consulta.Find(id);

            if (novaDescricao.Descricao != null)
            {
                consultaBuscada.Descricao = novaDescricao.Descricao;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }
    }
}
