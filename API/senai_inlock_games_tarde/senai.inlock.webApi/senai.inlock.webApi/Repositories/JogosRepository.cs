using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        private string stringConexao = "Data Source=DESKTOP-L8175GI; initial catalog=inlock_games_tarde; user Id=sa; pwd=Tacrolimusdc360";
        public void atualizarJogo(int id, JogosDomain jogoAtualizado)
        {
            throw new NotImplementedException();
        }

        public JogosDomain buscarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string querySelecionarId = "SELECT * FROM jogos WHERE idJogo = @ID";

                connection.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelecionarId, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogosDomain jogoBuscado = new JogosDomain
                        {
                            idJogo          = Convert.ToInt32(rdr["idJogo"])
                            ,nomeJogo       = rdr["nomeJogo"].ToString()
                            ,descricao      = rdr["descricao"].ToString()
                            ,dataLancamento = Convert.ToDateTime(rdr["dataLancamento"])
                            ,valor          = Convert.ToInt32(rdr["valor"])
                            ,idEstudio      = Convert.ToInt32(rdr["idEstudio"])
                        };

                        return jogoBuscado;
                    }

                    return null;
                }
               
            }
        }
        

        public void deletarJogo(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string queryDeletar = "DELETE FROM jogos WHERE idJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDeletar, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    connection.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> listarTodosJogos()
        {
            List<JogosDomain> jogos = new List<JogosDomain>();

            using (SqlConnection conn = new SqlConnection(stringConexao))
            {
                string querySelecionaTudo = "SELECT * FROM jogos";

                conn.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelecionaTudo, conn))
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        JogosDomain jogo = new JogosDomain
                        {
                            idJogo          = Convert.ToInt32(reader["idJogo"])
                            ,nomeJogo       = reader["nomeJogo"].ToString()
                            ,descricao      = reader["descricao"].ToString()
                            ,dataLancamento = Convert.ToDateTime(reader["dataLancamento"])
                            ,valor          = Convert.ToInt32(reader["valor"])
                            ,idEstudio      = Convert.ToInt32(reader["idEstudio"])
                        };

                        jogos.Add(jogo);
                    }

                    return jogos;
                }
            }
        }

        public void registrarJogo(JogosDomain novoJogo)
        {
            using (SqlConnection conne = new SqlConnection(stringConexao))
            {
                string queryInserir = "INSERT INTO jogos (nomeJogo, descricao, dataLancamento, valor, idEstudio) VALUES (@nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio)";

                using (SqlCommand com = new SqlCommand(queryInserir, conne))
                {
                    com.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    com.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    com.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);
                    com.Parameters.AddWithValue("@valor", novoJogo.valor);
                    com.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio);

                    conne.Open();

                    com.ExecuteNonQuery();
                }
            }
        }
    }
}
