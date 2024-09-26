using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Importa pelo DbContext
using ModuloAPI.Entities; // Importa pelo <Contato>

namespace ModuloAPI.Context
{   
    // Adiciona heraça DbContext que contém as operações necessárias para trabalharmos com banco de dados
    // A classe AgendaContext é a classe que vai acessar/conectar o banco de dados , por isso tem que herdar de DbContext
    public class AgendaContext : DbContext

    {
        // Criando construtor que vai se conectar com o banco de dados
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        // Recebemos a conexão/configuração do banco e passamos para o base ou seja, para o DBContext, para em seguida representarmos uma tabela através do DbSet.
        // Podemos ver o valor desses parâmetros sendo passados no Program.cs onde passamos as configurações para conexão com o banco.
        {

        }

        // Precisamos colocar uma propriedade que refere a nossa entidade (Contato.cs)
        public DbSet<Contato> Contatos {get; set;}
        // <Contato>: está dentro de um DbSet porque é representado por uma classe/objeto e também por uma tabela no banco de dados, isso é chamado de entidade

        // Contatos: nome que damos ao objeto/tabela
    }
}