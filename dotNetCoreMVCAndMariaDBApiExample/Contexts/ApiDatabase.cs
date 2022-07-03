using System;
using dotNetCoreMVCAndMariaDBApiExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotNetCoreMVCAndMariaDBApiExample.Contexts
{

    /**
     * Created by Okan Bahadır Soygür 03.07.2022
     * 
     * Java Spring'den farkları;
     * DbContex sınıfı Repositorylerden daha kapsamlı bir sınıftır. Java Spring'den farklı olarak Context'de bütün tablo ve her tablo için kolon tanımlamaları yapılır(primary key, colon properties...)
     * Controller üzerinden direk context'e ulaşmak bana çok mantıklı gelmiyor. Java Spring Standartları gibi Controller -> Services -> Repository -> Context şeklinde soyutlama/katman yapılması gerekiyor.
     * Burda bu soyutlamayı yapmayıp basit örnek yapmak için direk context üzerinden veri ekleme/silme/listeleme/düzenleme işlemlerini yapacağım.
     */
    public class ApiDatabase : DbContext
    {

        public DbSet<Computers> computers { get; set; }

        public ApiDatabase(DbContextOptions<ApiDatabase> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Map entities to tables  
             modelBuilder.Entity<Computers>().ToTable("computers");

            // primary key belirleylelim
             modelBuilder.Entity<Computers>().HasKey(c => c.id).HasName("PK_Computers");

             // indexleri belirleyelim
             modelBuilder.Entity<Computers>().HasIndex(c => c.name).HasName("index_name");
 
            //kolonları tnaımlayalım
              modelBuilder.Entity<Computers>().Property(c => c.id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
              modelBuilder.Entity<Computers>().Property(c => c.name).HasColumnType("nvarchar(50)").IsRequired();
              modelBuilder.Entity<Computers>().Property(c => c.data).HasColumnType("nvarchar(100)").IsRequired();
              modelBuilder.Entity<Computers>().Property(c => c.price).HasColumnType("double").IsRequired();
            


        }

    }
}
