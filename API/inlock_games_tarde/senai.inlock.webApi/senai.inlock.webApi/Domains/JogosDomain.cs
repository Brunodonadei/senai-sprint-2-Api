using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class JogosDomain
    {
        public int idJogo { get; set; }

        [Required(ErrorMessage = "O nome do jogo é obrigatório.")]
        public string nomeJogo { get; set; }
        public string descricao { get; set; }

        [Required(ErrorMessage = "A data de lançamento é obrigatória.")]
        public DateTime dataLancamento { get; set; }

        [Required(ErrorMessage = "O valor do jogo é obrigatório.")]
        public decimal valor { get; set; }

        [Required(ErrorMessage = "É necessário informar a identificação do estúdio.")]
        public int idEstudio { get; set; }

    }
}
