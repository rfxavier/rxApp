﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rxApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class getlockEntities : DbContext
    {
        public getlockEntities()
            : base("name=getlockEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<cofre> cofre { get; set; }
        public virtual DbSet<cofre_user> cofre_user { get; set; }
        public virtual DbSet<loja> loja { get; set; }
        public virtual DbSet<message> message { get; set; }
        public virtual DbSet<movimento> movimento { get; set; }
        public virtual DbSet<rede> rede { get; set; }
        public virtual DbSet<message_view> message_view { get; set; }
    }
}
