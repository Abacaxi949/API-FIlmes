using ApiSeuTema.Data;
using ApiSeuTema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace ApiSeuTema.Migrations;

[DbContext(typeof(FilmesDbContext))]
partial class FilmesDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("ProductVersion", "10.0.0");
        modelBuilder.Entity<Filme>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnType("INTEGER");
            entity.Property(e => e.Titulo).IsRequired().HasColumnType("TEXT");
            entity.HasKey(e => e.Id);
            entity.ToTable("Filmes");
        });
    }
}
