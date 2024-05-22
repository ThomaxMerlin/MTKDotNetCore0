using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace MTKDotNet.RestApi.Db;
internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<BlogModel> Blogs { get; set; }
}
