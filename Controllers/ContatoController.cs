using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; // +
using ModuloAPI.Context; // +
using ModuloAPI.Entities; // +

namespace ModuloAPI.Controllers
{
    [ApiController] // +
    [Route("[controller]")] // +
    public class ContatoController : ControllerBase // Realiza a herança com ControllerBase
    {
        // Adicionando endpoints que queremos que nossa API tenha
        // O objetivo é implementar um CRUD na tabela de contato

        // Atributo do tipo privado somente de leitura
        // Propriedade _context da AgendaContext.cs
        private readonly AgendaContext _context;

        // Vamos receber via construtor o AgendaContext.cs, contexto que nos permite acessar o banco de dados
        public ContatoController(AgendaContext context)
        {
            // Recebe o context do construtor e passamos para a propriedade _context
            _context = context;

        }

        // Como estamos enviando uma informação o método mais adequado é o HttpPost
        [HttpPost] 

        // Método de criação:
        public IActionResult Create(Contato contato)
        // contato será passado via JSON
        {
            _context.Add(contato);
            _context.SaveChanges();
            // Retorna o caminho pro registro que acabou de ser criado e a informaçção do contaro
            return CreatedAtAction(nameof(ObterPorId), new {id = contato.Id}, contato);
        }

        [HttpGet("{id}")]
        // O endpoint vai ficar /contato/id
        // o id vai ser o id da tabela do banco de dados
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contatos.Find(id);
            // Relembrando que contatos se trata do Context Dbset
            // A variável contato recebe o ID retornado na requisição

            if (contato == null) // Caso o contato for nulo retorna NotFound(), se não retorna a informação do contato que ele armazenou
                return NotFound();
            return Ok(contato);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult obterPorNome(string nome)
        {
            // Procura na tabela onde o nome passado no parâmetro
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
            return Ok(contatos);
        }

        [HttpPut("id")]
        public IActionResult Atualizar(int id, Contato contato)
        // id: Contato que será atualziado
        // contato: JSON para poder atualizar as informações
        {
            var contatoBanco = _context.Contatos.Find(id);
            // O contato vem do banco e não da requisição

            if(contatoBanco == null)
                return NotFound();

            contatoBanco.Nome = contato.Nome;
            // O nome do contato no banco de dados é igual ao nome do contato que estamos recebendo na requisição
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            // Atualiza e salva as informações do contato no banco
            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            // Retorna o banco atualizado com as informações
            return Ok(contatoBanco);
        }

        [HttpDelete("{id}")]
           public IActionResult Deletar(int id)
        {
            var contatoBanco = _context.Contatos.Find(id);
            // O contato vem do banco e não da requisição

            if(contatoBanco == null)
                return NotFound();
            
            // Remove o contato passado pelo ID
            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();

            // Retorna 'sem contéudo'
            return NoContent();
        }
    }
}