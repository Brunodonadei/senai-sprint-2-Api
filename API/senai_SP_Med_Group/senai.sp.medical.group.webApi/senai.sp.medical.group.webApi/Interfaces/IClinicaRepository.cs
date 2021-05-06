using senai.sp.medical.group.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.sp.medical.group.webApi.Interfaces
{
    interface IClinicaRepository
    {
        List<Clinica> ListarTodos();
        Clinica BuscarPorId(int id);
        void Cadastrar(Clinica clinica);
        void Atualizar(int id, Clinica clinicaAtt);
        void Deletar(int id);
        List<Clinica> ListarComMedico();


    }
}
