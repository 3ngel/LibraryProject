﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryProject.Assets.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LibraryEntities : DbContext
    {
        public LibraryEntities()
            : base("name=LibraryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<BBK> BBK { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Extradition> Extradition { get; set; }
        public virtual DbSet<Halls> Halls { get; set; }
        public virtual DbSet<HousePublication> HousePublication { get; set; }
        public virtual DbSet<Rank> Rank { get; set; }
        public virtual DbSet<Reader> Reader { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
