using ApiSeuTema.Data;
using ApiSeuTema.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var dbPath = Path.Combine(builder.Environment.ContentRootPath, "filmes.db");
builder.Services.AddDbContext<FilmesDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));
var app = builder.Build();

using (var scope = app.Services.CreateScope())
    scope.ServiceProvider.GetRequiredService<FilmesDbContext>().Database.Migrate();

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapGet("/", () => Results.Redirect("/index.html"));
var api = app.MapGroup("/api/filme");
api.MapGet("/", async (FilmesDbContext db) => Results.Ok(await db.Filmes.AsNoTracking().OrderBy(f => f.Id).ToListAsync()));
api.MapGet("/{id:int}", async (int id, FilmesDbContext db) =>
{
    var filme = await db.Filmes.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
    return filme is null ? Results.NotFound() : Results.Ok(filme);
});
api.MapPost("/", async (FilmeEntradaDto dados, FilmesDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(dados.Titulo)) return Results.BadRequest(new { erro = "O título é obrigatório." });
    var filme = new Filme { Titulo = dados.Titulo.Trim() };
    db.Filmes.Add(filme);
    await db.SaveChangesAsync();
    return Results.Created($"/api/filme/{filme.Id}", filme);
});
api.MapPut("/{id:int}", async (int id, FilmeEntradaDto dados, FilmesDbContext db) =>
{
    var filme = await db.Filmes.FindAsync(id);
    if (filme is null) return Results.NotFound();
    if (string.IsNullOrWhiteSpace(dados.Titulo)) return Results.BadRequest(new { erro = "O título é obrigatório." });
    filme.Titulo = dados.Titulo.Trim();
    await db.SaveChangesAsync();
    return Results.Ok(filme);
});
api.MapDelete("/{id:int}", async (int id, FilmesDbContext db) =>
{
    var filme = await db.Filmes.FindAsync(id);
    if (filme is null) return Results.NotFound();
    db.Filmes.Remove(filme);
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.Run();

record FilmeEntradaDto(string Titulo);
