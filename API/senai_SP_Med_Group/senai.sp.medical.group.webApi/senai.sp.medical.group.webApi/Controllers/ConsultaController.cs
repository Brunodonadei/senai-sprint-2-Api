using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.sp.medical.group.webApi.Domains;
using senai.sp.medical.group.webApi.Interfaces;
using senai.sp.medical.group.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace senai.sp.medical.group.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_consultaRepository.ListarTodas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "2")]
        [HttpGet("minhas")]
        public IActionResult ListarMinhasPaciente()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ListarMinhas(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "É preciso estar logado para verificar suas consultas.",
                    ex
                });
            }
        }

        [Authorize(Roles = "3")]
        [HttpGet("minhas/medico")]
        public IActionResult ListarMinhasMedico()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ListarMinhasMedico(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "É preciso estar logado para verificar suas consultas.",
                    ex
                });
            }
        }





        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult MarcarConsulta(Consultum novaConsulta)
        {
            try
            {
                _consultaRepository.Marcar(novaConsulta);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "É preciso estar logado como administrador para marcar uma consulta.",
                    ex
                });
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Att(int id, Consultum consultaAtt)
        {
            try
            {
                _consultaRepository.Atualizar(id, consultaAtt);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Cancelar(int id)
        {
            try
            {
                _consultaRepository.Cancelar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Situacao consultaSituacao)
        {
            try
            {
                _consultaRepository.AgendadaCancelada(id, consultaSituacao.Situacao1);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Apenas o administrador pode alterar a situação da consulta.",
                    ex
                });
            }
        }

        [Authorize(Roles = "3")]
        [HttpPatch("descricao/{id}")]
        public IActionResult attDescricao(int id, Consultum Descricao)
        {
            try
            {
                _consultaRepository.Prontuario(id, Descricao);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Apenas o médico pode alterar a descrição do caso.",
                    ex
                });
            }
        }

    }
}
