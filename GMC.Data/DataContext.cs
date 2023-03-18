using GMC.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<LigneProduction> LigneProduction { get; set; }
        public DbSet<PickList> PickList { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Produit> Produit { get; set; }
        public DbSet<DetailPickList> DetailPickList { get; set; }
        public DbSet<USPickList> USPickList { get; set; }
        public DbSet<InformationUS> InformationUS { get; set; }
        public DbSet<RemoteUS> RemoteUS { get; set; }
        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetailPickList>()
                .HasKey(d => d.IdPickDetail);

            modelBuilder.Entity<DetailPickList>()
                .HasOne(d => d.PickList)
                .WithMany(p => p.DetailPickLists)
                .HasForeignKey(d => d.PickListId);

            modelBuilder.Entity<DetailPickList>()
                .HasOne(d => d.Produit)
                .WithMany(p => p.DetailPickLists)
                .HasForeignKey(d => d.ProduitId);
          

            modelBuilder.Entity<DetailPickList>()
                .HasOne(d => d.Status)
                .WithMany(s => s.DetailPickLists)
                .HasForeignKey(d => d.StatusId);


            modelBuilder.Entity<Status>()
                .HasKey(s => s.IdStatus);

            modelBuilder.Entity<Status>()
                .HasMany(s => s.PickLists)
                .WithOne(p => p.Status)
                .HasForeignKey(p => p.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Status>()
                .HasMany(s => s.DetailPickLists)
                .WithOne(d => d.Status)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Status>()
                .HasMany(s => s.USPickLists)
                .WithOne(u => u.Status)
                .HasForeignKey(u => u.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<RemoteUS>()
        .HasMany(r => r.USPickLists)
        .WithMany(u => u.RemoteUSs)
        .UsingEntity(j => j.ToTable("RemoteUSUSPickList"));

        }
    }
}
