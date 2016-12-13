using System;
using System.Collections;
using System.Linq;
using System.Text;
using GMS.Framework.DAL;
using GMS.Framework.DAL.Impl;
using GMS.Core.Config;
using GMS.Core.Log;
using GMS.Account.Contract;
using System.Data.Entity;
namespace GMS.Account.DAL.Impl
{
    public class AccountRepositoryImpl : BaseRepositoryImpl
    {
        public AccountRepositoryImpl()
            :base(CachedConfigContext.Current.DaoConfig.Account)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AccountRepositoryImpl>(null);
            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Users)
                .Map(m =>
                {
                    m.ToTable("UserRole");
                    m.MapLeftKey("UserID");
                    m.MapRightKey("RoleID");
                });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LoginInfo> LoginInfos { get; set; }

        public DbSet<VerifyCode> VerifyCodes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
       

    }
}
