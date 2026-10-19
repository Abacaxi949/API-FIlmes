# API de Filmes — AP2

Evolução da API da AP1 para uma locadora de filmes. O backend é uma Minimal API em ASP.NET Core/.NET 10, com Entity Framework Core e SQLite. A interface em `wwwroot` é servida pela mesma origem da API e usa os endpoints reais.

## Requisitos e execução

- .NET SDK 10.0
- Bruno (opcional, para executar a Collection)

Na pasta do projeto:

```bash
dotnet restore
dotnet run
```

Na inicialização, as migrations criam/atualizam `filmes.db` na pasta do projeto. O banco local é ignorado pelo Git. Acesse no navegador a URL exibida pelo `dotnet run` para abrir a interface. Ela permite cadastrar, listar, editar e excluir filmes.

## Organização

- `Models/Filme.cs`: entidade com `Id` e `Titulo`.
- `Data/FilmesDbContext.cs`: contexto e conjunto EF Core.
- `Migrations/`: migration inicial do SQLite.
- `wwwroot/`: interface web.
- `Bruno/`: Collection das chamadas da API.

## Rotas

| Método | Rota | Resultado |
|---|---|---|
| GET | `/api/filme` | 200 e coleção |
| GET | `/api/filme/{id}` | 200 ou 404 |
| POST | `/api/filme` | 201 |
| PUT | `/api/filme/{id}` | 200 ou 404 |
| DELETE | `/api/filme/{id}` | 204 ou 404 |

POST e PUT recebem, por exemplo, `{"titulo":"Interestelar"}`. O ID é gerado pelo banco.

## Collection Bruno

Abra `Bruno/` no Bruno. A Collection usa `http://localhost:5181`; ajuste a URL para a porta mostrada no terminal, se necessário. Em um banco recém-criado, execute POST, GET coleção, GET por ID, PUT, DELETE e por último `Consultar filme excluído (404)`, que consulta o ID 1 criado pelo POST.

## Vídeo de demonstração — AP2

Link público do vídeo: **pendente de gravação/publicação**. Atualize esta seção com o link público da demonstração AP2 e verifique o acesso em janela anônima.
