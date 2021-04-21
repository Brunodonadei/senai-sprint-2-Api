using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-L8175GI; initial catalog=inlock_games_tarde; user Id=sa; pwd=Tacrolimusdc360";
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelecionar = "SELECT * FROM usuarios WHERE email = @email AND senha = @senha";

                using (SqlCommand cmd = new SqlCommand(querySelecionar, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"])
                            , email = rdr["email"].ToString()
                            , senha = rdr["senha"].ToString()
                            , idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"])
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }
    }
}
