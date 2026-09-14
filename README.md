# API de Filmes

## Tema e objetivo

Esta é uma Minimal API de uma locadora de filmes, desenvolvida em ASP.NET Core e .NET 10.

O objetivo da API é permitir cadastrar, listar, consultar, atualizar e remover filmes.

O objeto principal da API é o filme, que possui um ID e um título.

## Requisito

- .NET SDK 10.0

## Como executar o projeto

No terminal, dentro da pasta do projeto, execute:

```bash
dotnet run
URL local utilizada nos testes
http://localhost:5181
Caso a porta seja diferente no seu computador, use a URL mostrada no terminal após executar dotnet run.

Endpoints
Método	Rota	Descrição
GET	/	Informa que a API está no ar.
GET	/api/filme	Lista todos os filmes cadastrados.
GET	/api/filme/{id}	Busca um filme pelo ID.
POST	/api/filme	Cadastra um novo filme.
PUT	/api/filme/{id}	Atualiza um filme pelo ID.
DELETE	/api/filme/{id}	Remove um filme pelo ID.


Exemplo de POST
Rota:
POST http://localhost:5181/api/filme
JSON enviado:
{
  "titulo": "Interestelar"
}
Exemplo de PUT
Rota:
PUT http://localhost:5181/api/filme/1
JSON enviado:
{
  "titulo": "Interestelar - Edição Especial"
}
Dados em memória
Os dados da API são armazenados em uma List<FilmeDto> na memória.
Por isso, todos os filmes cadastrados são perdidos quando a aplicação é parada ou reiniciada.
Collection de testes
A Collection utilizada nos testes está disponível na pasta bruno/ deste repositório.
Vídeo de demonstração
🟨 COLE AQUI O LINK PÚBLICO DO SEU VÍDEO:
🟨 CLIQUE AQUI PARA ASSISTIR AO VÍDEO
