using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-L8175GI; initial catalog=inlock_games_tarde; user Id=sa; pwd=Tacrolimusdc360";

        public List<EstudioDomain> listarTodos()
        {
            List<EstudioDomain> estudios = new List<EstudioDomain>();

            using (SqlConnection conn = new SqlConnection(stringConexao))
            {
                string querySelecionaTudo = "SELECT * FROM estudios";

                conn.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelecionaTudo, conn))
                {
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain
                        {
                            idEstudio = Convert.ToInt32(reader["idEstudio"]),

                            nomeEstudio = reader["nomeEstudio"].ToString(),
                        };

                        estudios.Add(estudio);
                    }

                    return estudios;
                }
            }
        }
    }
}
