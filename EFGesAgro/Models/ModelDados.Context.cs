﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFGesAgro.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EFGESAGROEntities : DbContext
    {
        public EFGESAGROEntities()
            : base("name=EFGESAGROEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Cultura> Cultura { get; set; }
        public DbSet<CustoEstimado> CustoEstimado { get; set; }
        public DbSet<CustoItens> CustoItens { get; set; }
        public DbSet<CustoPrevisto> CustoPrevisto { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Fazenda> Fazenda { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Safra> Safra { get; set; }
        public DbSet<Talhao> Talhao { get; set; }
        public DbSet<Variedade> Variedade { get; set; }
    }
}
