using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;  // Adicionado 

namespace ModuloAPI.Controllers
{
    [ApiController] // Adicionado
    [Route("api/[controller]")] // Adicionado
    public class UsuarioController : ControllerBase // Adicionado 
    {   
        // Como vamos dar nome para como vamos chamar o método na API
        [HttpGet("ObterDataHoraAtual")]

        // Método que retorna a data e a hora
        public IActionResult ObterDataHora()
        {
            // Cria objeto anônimo que retorna a data e depois a propriedade DataHora
            var obj = new
            {
                // Retorna a data e a hors
                Data = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToLongTimeString()
            };

            // Retorna requisição/objeto HTTP
            return Ok(obj); //Método que retorna um objeto
        }

        // Adiciona um parâmetro na URL onde vamos colocar um nome
        [HttpGet("Apresentar/{nome}")]

        // Passa parâmetro para o método
        public IActionResult Apresentar(string nome)
        {
            var mensagem = $"Olá {nome}, seja bem vindo!";// lê o parâmetro passado e adiciona o nome na mensagem
            return Ok(new{mensagem}); // Retorna var mensagem
        }
    }
}