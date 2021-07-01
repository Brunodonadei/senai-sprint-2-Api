using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_peoples_webApi.Domains;
using senai_peoples_webApi.Interfaces;
using senai_peoples_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionarioController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_funcionarioRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Funcionario novoFuncionario)
        {
            try
            {
                _funcionarioRepository.Cadastrar(novoFuncionario);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Funcionario funcionarioAtt)
        {
            try
            {
                _funcionarioRepository.Atualizar(id, funcionarioAtt);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _funcionarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                _funcionarioRepository.BuscarPorId(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
