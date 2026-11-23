# API de filmes para uma locadora — Avaliação Semestral

Projeto acadêmico de uma locadora de filmes. A API permite cadastrar, consultar, atualizar e excluir filmes. O backend usa Minimal API no ASP.NET Core/.NET 10, Entity Framework Core e SQLite. A interface anterior da AP2 permanece em `wwwroot/`.

## Requisitos

- .NET SDK 10.0
- Bruno, para executar a Collection salva em `bruno/`

## Preparação e execução

Clone o repositório e, no diretório que contém `ApiSeuTema.csproj`, execute:

```bash
dotnet restore
dotnet run
```

O perfil HTTP está configurado em `http://localhost:5181`. A raiz abre a interface em `wwwroot/index.html`; os endpoints da API ficam em `/api/filme`.

O banco SQLite é o arquivo `filmes.db`, criado na pasta do projeto. A aplicação aplica automaticamente as migrations existentes por meio de `Database.Migrate()` durante a inicialização. Assim, na primeira execução o banco é criado e, nas seguintes, as migrations pendentes são aplicadas. O arquivo do banco local não é versionado; a pasta `Migrations/` contém o procedimento reproduzível de criação/atualização do esquema.

## Organização dos arquivos

```text
ApiSeuTema.csproj
Program.cs
Models/
  Filme.cs
Dtos/
  FilmeEntradaDto.cs
Data/
  FilmesDbContext.cs
Migrations/
  20261019000100_InitialCreate.cs
  FilmesDbContextModelSnapshot.cs
wwwroot/
  index.html
  app.js
  styles.css
bruno/
  opencollection.yml
  environments/Local.bru
  *.bru
```

- `Models/Filme.cs`: entidade persistida, com identificador e título.
- `Dtos/FilmeEntradaDto.cs`: dados de entrada enviados em POST e PUT.
- `Data/FilmesDbContext.cs`: contexto do EF Core e acesso à tabela de filmes.
- `Migrations/`: histórico do esquema SQLite aplicado na inicialização.
- `Program.cs`: inicialização, registro do contexto, middleware e endpoints da Minimal API.
- `wwwroot/`: interface web já existente.
- `bruno/`: Collection e ambiente local para testar a API.

Os tipos ficam em arquivos separados segundo sua responsabilidade. O `Program.cs` importa os namespaces `ApiSeuTema.Data`, `ApiSeuTema.Dtos` e `ApiSeuTema.Models` para configurar o contexto e mapear as rotas usando os tipos definidos nesses arquivos.

## Rotas

| Método | Rota | Resposta |
|---|---|---|
| GET | `/api/filme` | `200 OK` com a lista de filmes |
| GET | `/api/filme/{id}` | `200 OK` com o filme ou `404 Not Found` |
| POST | `/api/filme` | `201 Created` com o filme criado e seu ID |
| PUT | `/api/filme/{id}` | `200 OK` com o filme atualizado, ou `404 Not Found` |
| DELETE | `/api/filme/{id}` | `204 No Content`, ou `404 Not Found` |

POST e PUT recebem um JSON como este:

```json
{
  "titulo": "Interestelar"
}
```

Uma consulta bem-sucedida retorna, por exemplo:

```json
{
  "id": 1,
  "titulo": "Interestelar"
}
```

O valor de `id` é gerado pelo banco e pode variar.

## Testes no Bruno

Abra a pasta `bruno/` como Collection e selecione o ambiente `Local`. Ele usa `http://localhost:5181`; se a aplicação estiver em outra porta, altere `baseUrl` no ambiente.

A Collection cobre listagem, criação, consulta pelo ID retornado no POST, atualização, nova consulta, exclusão e confirmação do `404`. O script do POST armazena o ID recebido na variável `filmeId`, sem presumir que seja `1`.

Para demonstrar a persistência, execute **Criar filme para teste de persistência**, pare e inicie novamente a API e então execute **Consultar filme após reiniciar a API**. O POST atualiza `filmeId` para o identificador do segundo registro.

## Vídeo de demonstração — AS

**Link público:** pendente de gravação e publicação do vídeo específico da Avaliação Semestral. Após publicar, substitua esta linha pelo link que abra sem solicitar permissão.

