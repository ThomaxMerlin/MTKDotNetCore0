using DotNetTrainingBatch4.ConsoleApp.Services;
using Microsoft.EntityFrameworkCore;
using MTKDotNetCore.ConsoleApp.Dtos;

namespace MTKDotNetCore.ConsoleApp.EFCoreExamples
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<BlogDto> Blogs { get; set; }
    }
}


