using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTKDotNet.RestApi;
using System.Collections.Generic;

namespace MTKDotNet.RestApiWithNLayer.Db;
internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }

    public DbSet<BlogModel> Blogs { get; set; }
}