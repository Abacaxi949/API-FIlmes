using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var filmes = new List<FilmeDto>
{
    new FilmeDto(1, "O Poderoso Chefão"),
    new FilmeDto(2, "De Volta para o Futuro")
};

app.MapGet("/", () => "Locadora de filmes: atendimento até 21h30.");

app.MapGet("/api/filme", () => Results.Ok(filmes));

app.MapGet("/api/filme/{id:int}", (int id) =>
{
    var filme = filmes.Find(f => f.Id == id);
    return filme is null ? Results.NotFound() : Results.Ok(filme);
});

app.MapPost("/api/filme", (FilmeEntradaDto dados) =>
{
    int proximoId = filmes.Count + 1;
    var novoFilme = new FilmeDto(proximoId, dados.Titulo);
    filmes.Add(novoFilme);

    return Results.Created($"/api/filme/{novoFilme.Id}", novoFilme);
});

app.MapPut("/api/filme/{id:int}", (int id, FilmeEntradaDto dados) =>
{
    int indice = filmes.FindIndex(filmeDaLista => filmeDaLista.Id == id);
    if (indice == -1)
    {
        return Results.NotFound();
    }

    var FilmeAtualizado = new FilmeDto(id, dados.Titulo);
    filmes[indice] = FilmeAtualizado;
    return Results.Ok(FilmeAtualizado);
});

app.MapDelete("/api/filme/{id:int}", (int id) =>
{
    int indice = filmes.FindIndex(filmeDaLista => filmeDaLista.Id == id);
    if (indice == -1)
    {
        return Results.NotFound();
    }

    filmes.RemoveAt(indice);
    return Results.NoContent();
});

app.Run();

record FilmeDto(int Id, string Titulo);
record FilmeEntradaDto(string Titulo);