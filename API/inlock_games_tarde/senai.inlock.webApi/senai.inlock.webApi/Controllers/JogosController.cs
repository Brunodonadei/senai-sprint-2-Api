using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogosRepository { get; set; }

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }
        /// <summary>
        /// Requisição para mostrar todos os jogos (pode ser requisitado por usuários comuns e administradores)
        /// </summary>
        /// <returns>Todos os jogos cadastrados</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogosDomain> jogos = _jogosRepository.listarTodosJogos();

            return Ok(jogos);
        }

        /// <summary>
        /// Requisição para cadastrar um jogo (pode ser feito somente por administradores)
        /// </summary>
        /// <param name="novoJogo">Objeto novo que será cadastrado</param>
        /// <returns>StatusCode 201 (Created), dizendo que foi criado</returns>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(JogosDomain novoJogo)
        {
            _jogosRepository.registrarJogo(novoJogo);

            return StatusCode(201);
        }

        /// <summary>
        /// Requisição para buscar um jogo pelo seu id (pode ser requisitado por usuários comuns e administradores)
        /// </summary>
        /// <param name="id">id do jogo que será buscado</param>
        /// <returns>Um jogo procurado, se não achar, retorna nulo</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            JogosDomain jogoBuscado = _jogosRepository.buscarPorId(id);

            if (jogoBuscado == null)
            {
                return NotFound("Nenhum jogo encontrado!");
            }

            return Ok(jogoBuscado);
        }

        /// <summary>
        /// Requisição para excluir um jogo pelo seu id (pode ser feito somente por administradores)
        /// </summary>
        /// <param name="id">id do jogo que será deletado</param>
        /// <returns>Retorna um status code 204(NoContent) ou seja, foi excluido, não possui conteúdo</returns>
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _jogosRepository.deletarJogo(id);

            return StatusCode(204);
        }
    }
}
