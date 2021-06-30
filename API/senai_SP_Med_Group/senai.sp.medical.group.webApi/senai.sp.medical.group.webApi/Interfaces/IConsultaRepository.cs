using senai.sp.medical.group.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.sp.medical.group.webApi.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Lista todas as consultas de um determinado paciente/médico
        /// </summary>
        /// <param name="id">ID do paciente/médico que faz uma consulta</param>
        /// <returns>Uma lista de consultas com os dados da consulta</returns>
        List<Consultum> ListarMinhas(int id);

        List<Consultum> ListarMinhasMedico(int id);

        /// <summary>
        /// Marca uma nova consulta
        /// </summary>
        /// <param name="inscricao">Objeto com as informações da consulta</param>
        void Marcar(Consultum inscricao);

        /// <summary>
        /// Altera o status de uma consulta
        /// </summary>
        /// <param name="id">ID da consulta que terá a situação alterada</param>
        /// <param name="status">Parâmetro que atualiza a situação da presença para 0 - Cancelada, 1 - Agendada, 2 - </param>
        void AgendadaCancelada(int id, string status);

        List<Consultum> ListarTodas();

        void Atualizar(int id, Consultum consultaAtt);

        void Cancelar(int id);

        void Prontuario(int id, Consultum novaDescricao);



    }
}
