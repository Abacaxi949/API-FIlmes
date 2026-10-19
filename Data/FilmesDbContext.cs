using ApiSeuTema.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSeuTema.Data;

public class FilmesDbContext(DbContextOptions<FilmesDbContext> options) : DbContext(options)
{
    public DbSet<Filme> Filmes => Set<Filme>();
}
