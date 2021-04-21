using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogosRepository
    {
        List<JogosDomain> listarTodosJogos();
        JogosDomain buscarPorId(int id);
        void registrarJogo(JogosDomain novoJogo);
        void atualizarJogo(int id, JogosDomain jogoAtualizado);
        void deletarJogo(int id);

    }
}
