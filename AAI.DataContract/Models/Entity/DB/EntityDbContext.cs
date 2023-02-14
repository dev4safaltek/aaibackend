using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI.DataContract.Models.Entity.DB
{
    public class EntityDbContext : DbContext
    {

        public EntityDbContext(DbContextOptions<EntityDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           // base.OnModelCreating(builder);
           // builder.Entity<Users>().HasOne(x => x.UserId);
            builder.Entity<Users>().HasKey(x => x.UserId);

            //builder.Entity<Users>(entity =>
            //{
            //    entity.Property(e => e.UserId).HasDefaultValueSql("(newsequentialid())");

            //});
        }
        

        //public virtual DbSet<AAI_ActSection> AAI_ActSection { get; set; }
        //public virtual DbSet<AAI_Allocations> AAI_Allocations { get; set; }
        //public virtual DbSet<AAI_Authorizations> AAI_Authorizations { get; set; }
        //public virtual DbSet<AAI_BondCounsels> AAI_BondCounsels { get; set; }
        //public virtual DbSet<AAI_FundDescription> AAI_FundDescription { get; set; }
        //public virtual DbSet<AAI_Issuance> AAI_Issuance { get; set; }
        //public virtual DbSet<PasteErrors> PasteErrors { get; set; }
        //public virtual DbSet<Sheet1> Sheet1 { get; set; }
        //public virtual DbSet<Switchboard_Items> Switchboard_Items { get; set; }
        //public virtual DbSet<Users> Users { get; set; }

        public virtual DbSet<Users> Users { get; set; }
    }
}
