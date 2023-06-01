using Data.EntityMapper;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MyContext : DbContext
    {
        //空构造函数要在非空构造函数前面申明。
        public MyContext() : base() { }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

      

        public DbSet<Article>? acticles;
        public DbSet<Comment>? comments;
        public DbSet<City> Cities;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=corebase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommentCfg());
            modelBuilder.Entity<Article>().ToTable("T_ArticleS");
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Article>().HasData(new Article[] {
                new Article(){ Id=Guid.NewGuid(), Author="jack", CreateUser="admin", Description="crm", Title="迅达crm",UpdateUser="admin"},
                new Article(){ Id=Guid.NewGuid(), Author="jimmiy", CreateUser="admin", Description="efrqc", Title="efrqc",UpdateUser="admin"},
                new Article(){ Id=Guid.NewGuid(), Author="rock", CreateUser="admin", Description="tuoxin", Title="tuoxin",UpdateUser="admin"},
                new Article(){ Id=Guid.NewGuid(), Author="john", CreateUser="admin", Description="good", Title="good",UpdateUser="admin"},

            });
        }


    }
}
