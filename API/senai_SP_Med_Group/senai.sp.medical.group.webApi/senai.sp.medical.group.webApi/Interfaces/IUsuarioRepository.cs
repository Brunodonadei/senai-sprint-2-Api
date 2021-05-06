using senai.sp.medical.group.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.sp.medical.group.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
        List<Usuario> ListarTodos();
        Usuario BuscarPorid(int id);
        void Cadastrar(Usuario novoUsuario);
        void Deletar(int id);
        void Atualizar(int id, Usuario usuarioAtt);

    }
}
