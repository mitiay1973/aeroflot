﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace aeroflot
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        private static Entities _instance;
        public Entities()
            : base("name=Entities")
        {
        }
        public static Entities GetContext()
        {
            if (_instance == null) _instance = new Entities();
            return _instance;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<citys> citys { get; set; }
        public virtual DbSet<klients> klients { get; set; }
        public virtual DbSet<planes> planes { get; set; }
        public virtual DbSet<reis> reis { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
