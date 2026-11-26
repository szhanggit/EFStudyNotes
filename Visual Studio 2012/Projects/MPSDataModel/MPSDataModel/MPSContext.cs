namespace MPSDataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MPSContext : DbContext
    {
        public MPSContext()
            : base("name=MPSContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountRelation> AccountRelations { get; set; }
        public virtual DbSet<AccountRole> AccountRoles { get; set; }
        public virtual DbSet<MerchantAndShop> MerchantAndShops { get; set; }
        public virtual DbSet<MerchantRelation> MerchantRelations { get; set; }
        public virtual DbSet<MerchantShopWorkKey> MerchantShopWorkKeys { get; set; }
        public virtual DbSet<MessageMapping> MessageMappings { get; set; }
        public virtual DbSet<OperationLog> OperationLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MerchantAndShop>()
                .Property(e => e.ProgramCode)
                .IsUnicode(false);

            modelBuilder.Entity<MerchantAndShop>()
                .Property(e => e.MerchantCode)
                .IsUnicode(false);

            modelBuilder.Entity<MerchantAndShop>()
                .Property(e => e.ShopCode)
                .IsUnicode(false);

            modelBuilder.Entity<MerchantAndShop>()
                .Property(e => e.ShopExternalCode)
                .IsUnicode(false);

            modelBuilder.Entity<MerchantAndShop>()
                .Property(e => e.ShopSecurityKey)
                .IsUnicode(false);

            modelBuilder.Entity<MerchantShopWorkKey>()
                .Property(e => e.ProgramCode)
                .IsUnicode(false);

            modelBuilder.Entity<MerchantShopWorkKey>()
                .Property(e => e.MerchantCode)
                .IsUnicode(false);

            modelBuilder.Entity<MerchantShopWorkKey>()
                .Property(e => e.ShopCode)
                .IsUnicode(false);

            modelBuilder.Entity<MerchantShopWorkKey>()
                .Property(e => e.WorkKey)
                .IsUnicode(false);

            modelBuilder.Entity<OperationLog>()
                .Property(e => e.MethodType)
                .IsUnicode(false);
        }
    }
}
