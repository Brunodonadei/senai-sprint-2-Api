using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_Filmes_webApi.Domains;
using senai_Filmes_webApi.Interfaces;
using senai_Filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsavel pelos endpoints referentes aos generos
/// </summary>
namespace senai_Filmes_webApi.Controllers
{
    //define que o tipo de resposta da API será no formato json
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/api/nomeController
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto_generoRepository irá receber todos os metodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// instancia o objeto _generoRepository para que haja a referencia aos metodos no repositorio
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Lista todos os generos
        /// </summary>
        /// <returns>Uma lista de generos e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Cria uma lista nomeada listaGeneros para receber os dados
            List<GeneroDomain> listaGeneros = _generoRepository.ListAll();

            //Retorna o status code 200(ok) com a lista de generos no formato json
            return Ok(listaGeneros);
        }

        /// <summary>
        /// Busca um genero através do seu id
        /// </summary>
        /// <param name="id">id do genero que será buscado</param>
        /// <returns>Um genero buscado ou NotFound caso nenhum genero seja encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Cria um objeto generoBuscado que irá receber o genero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.SearchById(id);

            //Verifica se nenhum genero foi encontrado
            if (generoBuscado == null)
            {
                //Caso nenhum genero seja encontrado, irá retornar o status code 404(Not Found) com uma mensagem personalizada
                return NotFound("Nenhum gênero encontrado.");
            }

            //Caso seja encontrado, retorna o genero encontrado com o status code 200 - ok
            return Ok(generoBuscado);        
        }

        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            _generoRepository.Register(novoGenero);

             return StatusCode(201);
        }


        /// <summary>
        /// Deleta um genero existente
        /// </summary>
        /// <param name="id">id do genero que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Fa a chamada para o método .Delete();
            _generoRepository.Delete(id);

            //Retorna o status code 204 - no content (sem conteúdo)
            return StatusCode(204);
        }
    }
}
