using System;
using System.Collections;
using System.Linq;
using System.Text;
using GMS.Framework.DAL;
using GMS.Framework.DAL.Impl;
using GMS.Core.Config;
using GMS.Core.Log;
using GMS.Loc.Contract;
using System.Data.Entity;
namespace GMS.Loc.DAL.Impl
{
    public class LocRepositoryImpl : BaseRepositoryImpl
    {
        public LocRepositoryImpl()
            :base(CachedConfigContext.Current.DaoConfig.Loc)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<LocRepositoryImpl>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Host> Hosts { get; set; }

        public DbSet<HostPositionStatusView> HostPositionStatusViews { set; get; }

    }
}
