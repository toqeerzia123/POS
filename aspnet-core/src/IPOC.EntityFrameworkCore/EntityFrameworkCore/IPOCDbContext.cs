using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using IPOC.Authorization.Roles;
using IPOC.Authorization.Users;
using IPOC.MultiTenancy;
using IPOC.POS;
using IPOC.POSManagement;
using IPOC.SaleAndPurchase;
using IPOC.VendorAndCustomer;


namespace IPOC.EntityFrameworkCore
{
    public class IPOCDbContext : AbpZeroDbContext<Tenant, Role, User, IPOCDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public IPOCDbContext(DbContextOptions<IPOCDbContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Location { get; set; }
        public DbSet<PosSetting> PosSettings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryImage> CategoryImages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<StockTransfer> StockTransfers { get; set; }
        public DbSet<ClientLedger> ClientLedgers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorLedgerEntry> VendorLedgerEntries { get; set; }
        public DbSet<BarCode> BarCodes { get; set; }

    }
}
