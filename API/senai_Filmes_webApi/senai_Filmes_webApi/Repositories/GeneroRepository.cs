using senai_Filmes_webApi.Domains;
using senai_Filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Filmes_webApi.Repositories
{
    /// <summary>
    /// Classe responsavel pelo repositorio dos generos
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// string de conexão com o banco de dados que recebe os parametros
        /// Data Source = nome do servidor
        /// initial catalog = nome do banco de dados
        /// user id and pwd = faz a autenticação com o usuario do sql server
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-L8175GI; initial catalog=Filmes; user Id=sa; pwd=Tacrolimusdc360";
        
        /// <summary>
        /// Deleta um genero através do seu id
        /// </summary>
        /// <param name="id">id do genero que vai ser deletado</param>
        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada passando o parametro
                string queryDelete = "DELETE FROM Generos WHERE idGenero = @ID";

                //Declara o SqlCommand cmd passando a query que será executada e a conexão como parametros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os generos
        /// </summary>
        /// <returns>lista de generos</returns>
        public List<GeneroDomain> ListAll()
        {
            //cria uma lista onde serão armaenados os dados
            List<GeneroDomain> genreList = new List<GeneroDomain>();

            // declara a sqlconnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT idGenero, Nome FROM Generos";

                //Abre a conexao com o banco de dados
                con.Open();

                //Declara o sqldatareader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o sqlcommand cmd passando a query q sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui à porpriedade idgenero o valor da primeira coluna da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr[0]),

                            //Atribui à propriedade nome o valor da segunda coluna da tabela do banco de dados
                            nome = rdr[1].ToString()
                        };

                        genreList.Add(genero);
                    }
                }
            }
            return genreList;
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">objeto chamado novogenero com as informações que serão cadastradas</param>
        public void Register(GeneroDomain novoGenero)
        {
            // declara a conexão con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será utilizada
                string queryInsert = "INSERT INTO Generos(Nome) VALUES (@Nome)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa o valor para o parametro @nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.nome);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }

            }

        }


        /// <summary>
        /// Busca um genero através do id
        /// </summary>
        /// <param name="id">id do genero que será buscado</param>
        /// <returns>Um genero buscado ou null caso nao seja encontrado</returns>
        public GeneroDomain SearchById(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser utilizada
                string querySelectById = "SELECT idGenero, Nome FROM Generos WHERE idGenero = @ID";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader rdr para receber os valores
                SqlDataReader rdr;

                //Declara o sqlCommand cmd passando a query que será executada e a conexão como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    //Passa o valor para o parametro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    //Executa a query e armazena os dados no rdr
                    if (rdr.Read())
                    {
                        //Se sim, instancia um novo objeto generoBuscado do tipo GeneroDomain
                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            //Atribui à propriedade idGenero o valor da coluna "idGenero" da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr["idGenero"]),

                            //Atribui à propriedade nome o valor da coluna "nome" da tabela do banco de dados
                            nome = rdr["Nome"].ToString()
                        };

                        //Retorna o generoBuscado com os dados obtidos
                        return generoBuscado;
                    }

                    // Se não, retorna nulo
                    return null;


                    

                }
            }
        }

        public void UpdateBodyId(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void UpdateUrlId(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }
    }
}
