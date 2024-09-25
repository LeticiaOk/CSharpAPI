<h1>
    <a href="https://www.dio.me/">
     <img width="40px" src="https://hermes.digitalinnovation.one/assets/diome/logo-minimized.png"></a>
    <span> Curso oeferecido pela DIO XP Inc. - Full Stack Developer</span>
</h1>

> ## 📕 O repositório tem como objetivo armazenar resumos e o conteúdo passado em aula sobre APIs com C#.

# ⭐ Construindo APIs com C#
## 🚀 ``Introdução a APIs com C#``
### 1️⃣ IIntrodução a APIs
#### 📍 Introdução:

* Aprender e desenvolver uma API, utilizando o Entity Framework para persistência de dados, juntamente com seus princiapis conceitos e funcionalidades.

#### 📍 O que é uma API:

* Uma API (Application Progrgamming Interface) é uma forma de comunicação entre computadores ou programas de computadores.

* Em outras palavras, é uma software que fornece informações para outros softwareS.
<!-- 
#### 📍 API de feriados:
* Acessar o site: [date.nager.a](https://date.nager.at/api/v3/PublicHolidays/2024/BR)
* Clilcar em Holiday API -> Clicar no link da API -> Mudar o código do páis na URL

#### 📍 Usando o Dog API:
* Acessar o site: [Dog API](https://dog.ceo/dog-api)
* Gera imagem aleatória de cachorros -->

#### 📍 Criando nossa API:

* Comando parar criar API em .NET: ``dotnet new webapi``
* Comando para assistir as mudanças em tempo real sem precisar para o servidor (abre a documentação): ``dotnet watch run``
> Apenas a minha máquina pode rodar o endereço localhost
* Clicar em Weatherforecast no endereço que abrir -> Try it out -> Execute
* Podemos documentar e testar nossa API no Swagger 

#### 📍 Criando a controller:
* Uma controller é uma classe que vai agrupar as nossas requisições HTTP e vai disponibilizar os os endpoints.

* Criar pasta Controller -> Adicionar arquivo UsuarioController.cs

~~~~C#
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
    }
}
~~~~

> Retomar dotnet eatch run -> a API vai aparecer lá e é só executar

* Cada controller é uma sessão no Swagger
* Montar caminho: AqrquivoController +  ``[HttpGet("ObterDataHoraAtual")]``
> Ignora o controller
* Após isso ele retorna o método

#### 📍 Endpoint com parâmetro:

~~~~C#
namespace ModuloAPI.Controllers
{
    [ApiController] // Adicionado
    [Route("api/[controller]")] // Adicionado
    public class UsuarioController : ControllerBase // Adicionado 
    {   
        ...

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
~~~~

## 🚀 ``Trabalhando com Entity Framewol com C#``
### 1️⃣ Entity Framework e CRUD

#### 📍 Introdução:

* o EF é um framework ORM (Object-Relational Mapping) criado para facilitar a integração com o banco de dados, mapeando tabelas e gerando comandos SQL de forma automática.

#### 📍 Entendendo o CRUD:
* C - CREATE (Insert) R - READ (Select) U - UPDATE (Update) D - DELETE (Delete)

#### 📍Instalando pacotes:
``dotnet tool install --global ditnet-ef``: ferramenta para executar comandos do Entity Framwork diretamente pelo console.
> Só precisa executar 1 vez.

``dotnet add package Microsoft.EntityFrameWorkCore.Design``: pacote do Entity FrameWork Core
> Precisa executar em todo projeto

``dotnet add package Microsoft.EntityFrameWorkCore.SqlServer``: Pacote do SQL Server
> Precisa executar em todo projeto

#### 📍Criando a classe entidade:
