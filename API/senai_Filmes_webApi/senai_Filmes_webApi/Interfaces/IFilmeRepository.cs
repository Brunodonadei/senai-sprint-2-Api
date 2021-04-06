using senai_Filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Filmes_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FilmeRepository
    /// </summary>
    interface IFilmeRepository
    {
        /// <summary>
        /// Método que lista todos os filmes
        /// </summary>
        /// <returns></returns>
        List<FilmeDomain> ListAll();

        /// <summary>
        /// Busca um filme pelo seu id
        /// </summary>
        /// <param name="id">id de um filme</param>
        /// <returns></returns>
        FilmeDomain SearchByid(int id);

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">objeto chamado novoFilme com as informações que serão cadastradas</param>
        void Register(FilmeDomain novoFilme);

        /// <summary>
        /// Atualiza um filme existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="filme">Objeto filme com as novas informações</param>
        void UpdateBodyId(FilmeDomain filme);

        /// <summary>
        /// Atualiza um filme existente passando o id pela url da requisição
        /// </summary>
        /// <param name="id">id do filme que será atualizado</param>
        /// <param name="filme">objeto filme com as novas informações</param>
        void UpdateUrlId(int id, FilmeDomain filme);

        /// <summary>
        /// Deleta um filme existente
        /// </summary>
        /// <param name="id">id do filme que será deletado</param>
        void Delete(int id)
        

    }
}
