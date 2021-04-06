using senai_Filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Filmes_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// </summary>
    interface IGeneroRepository
    {
        // TipoRetorno NomeMetodo(TipoParametro NomeParametro);

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        List<GeneroDomain> ListAll();

        /// <summary>
        /// Busca um gênero através do seu id
        /// </summary>
        /// <param name="id">id de um genero</param>
        /// <returns>Um objeto genero que foi buscado</returns>
        GeneroDomain SearchById(int id);

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto chamado novo genero com as informações que serão cadastradas</param>
        void Register(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um genero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informações</param>
        void UpdateBodyId(GeneroDomain genero);

        /// <summary>
        /// Atualiza um genero existente passando o id pela url da requisição
        /// </summary>
        /// <param name="id">id do genero que será atualizado</param>
        /// <param name="genero">objeto genero com as novas informações</param>
        void UpdateUrlId(int id, GeneroDomain genero);


        /// <summary>
        /// Deleta um genero existente
        /// </summary>
        /// <param name="id">id do genero que será deletado</param>
        void Delete(int id);
    }
}
