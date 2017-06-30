using GameWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace GameWeb
{
    public class EFCoreGameWebContext : DbContext
    {
        public DbSet<ScoreBoard> ScoreBoards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=GameWeb.db");
        }

    }
}