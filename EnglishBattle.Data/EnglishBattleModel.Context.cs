﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnglishBattle.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EnglishBattleEntities : DbContext
    {
        public EnglishBattleEntities()
            : base("name=EnglishBattleEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Joueur> Joueurs { get; set; }
        public virtual DbSet<Partie> Parties { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Verbe> Verbes { get; set; }
        public virtual DbSet<Ville> Villes { get; set; }
    }
}
