using senai.sp.medical.group.webApi.Contexts;
using senai.sp.medical.group.webApi.Domains;
using senai.sp.medical.group.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.sp.medical.group.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        medicalContext ctx = new medicalContext();
        public void Atualizar(int id, Usuario usuarioAtt)
        {
            Usuario usuarioBuscado = BuscarPorid(id);

            if (usuarioAtt.Email != null)
            {
                usuarioBuscado.Email = usuarioAtt.Email;
            }

            if (usuarioAtt.Senha != null)
            {
                usuarioBuscado.Senha = usuarioAtt.Senha;
            }

            if (usuarioAtt.IdTipoUsuario != null)
            {
                usuarioBuscado.IdTipoUsuario = usuarioAtt.IdTipoUsuario;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorid(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorid(id));

            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
