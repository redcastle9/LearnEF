namespace AWContextLibrary.AWModels.Sales
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SalesContext : DbContext
    {
        public SalesContext()
            : base("name=SalesContext")
        {
        }

        public virtual DbSet<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CurrencyRate> CurrencyRates { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderTracking> OrderTrackings { get; set; }
        public virtual DbSet<PersonCreditCard> PersonCreditCards { get; set; }
        public virtual DbSet<SalesOrder_json> SalesOrder_json { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual DbSet<SalesOrderDetail_inmem> SalesOrderDetail_inmem { get; set; }
        public virtual DbSet<SalesOrderDetail_ondisk> SalesOrderDetail_ondisk { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public virtual DbSet<SalesOrderHeader_inmem> SalesOrderHeader_inmem { get; set; }
        public virtual DbSet<SalesOrderHeader_ondisk> SalesOrderHeader_ondisk { get; set; }
        public virtual DbSet<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; }
        public virtual DbSet<SalesPerson> SalesPersons { get; set; }
        public virtual DbSet<SalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; }
        public virtual DbSet<SalesReason> SalesReasons { get; set; }
        public virtual DbSet<SalesTaxRate> SalesTaxRates { get; set; }
        public virtual DbSet<SalesTerritory> SalesTerritories { get; set; }
        public virtual DbSet<SalesTerritoryHistory> SalesTerritoryHistories { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual DbSet<SpecialOffer> SpecialOffers { get; set; }
        public virtual DbSet<SpecialOffer_inmem> SpecialOffer_inmem { get; set; }
        public virtual DbSet<SpecialOffer_ondisk> SpecialOffer_ondisk { get; set; }
        public virtual DbSet<SpecialOfferProduct> SpecialOfferProducts { get; set; }
        public virtual DbSet<SpecialOfferProduct_inmem> SpecialOfferProduct_inmem { get; set; }
        public virtual DbSet<SpecialOfferProduct_ondisk> SpecialOfferProduct_ondisk { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<TrackingEvent> TrackingEvents { get; set; }
        public virtual DbSet<CustomerPII> CustomerPIIs { get; set; }
        public virtual DbSet<vIndividualCustomer> vIndividualCustomers { get; set; }
        public virtual DbSet<vPersonDemographic> vPersonDemographics { get; set; }
        public virtual DbSet<vSalesPerson> vSalesPersons { get; set; }
        public virtual DbSet<vSalesPersonSalesByFiscalYear> vSalesPersonSalesByFiscalYears { get; set; }
        public virtual DbSet<vStoreWithAddress> vStoreWithAddresses { get; set; }
        public virtual DbSet<vStoreWithContact> vStoreWithContacts { get; set; }
        public virtual DbSet<vStoreWithDemographic> vStoreWithDemographics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryRegionCurrency>()
                .Property(e => e.CurrencyCode)
                .IsFixedLength();

            modelBuilder.Entity<CreditCard>()
                .HasMany(e => e.PersonCreditCards)
                .WithRequired(e => e.CreditCard)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .Property(e => e.CurrencyCode)
                .IsFixedLength();

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.CountryRegionCurrencies)
                .WithRequired(e => e.Currency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.CurrencyRates)
                .WithRequired(e => e.Currency)
                .HasForeignKey(e => e.FromCurrencyCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.CurrencyRates1)
                .WithRequired(e => e.Currency1)
                .HasForeignKey(e => e.ToCurrencyCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CurrencyRate>()
                .Property(e => e.FromCurrencyCode)
                .IsFixedLength();

            modelBuilder.Entity<CurrencyRate>()
                .Property(e => e.ToCurrencyCode)
                .IsFixedLength();

            modelBuilder.Entity<CurrencyRate>()
                .Property(e => e.AverageRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CurrencyRate>()
                .Property(e => e.EndOfDayRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Customer>()
                .Property(e => e.AccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.SalesOrderHeaders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SalesOrder_json>()
                .Property(e => e.CreditCardApprovalCode)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrder_json>()
                .Property(e => e.SubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrder_json>()
                .Property(e => e.TaxAmt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrder_json>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrder_json>()
                .Property(e => e.TotalDue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(e => e.UnitPriceDiscount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(e => e.LineTotal)
                .HasPrecision(38, 6);

            modelBuilder.Entity<SalesOrderDetail_inmem>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderDetail_inmem>()
                .Property(e => e.UnitPriceDiscount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderDetail_ondisk>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderDetail_ondisk>()
                .Property(e => e.UnitPriceDiscount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader>()
                .Property(e => e.CreditCardApprovalCode)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrderHeader>()
                .Property(e => e.SubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader>()
                .Property(e => e.TaxAmt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader>()
                .Property(e => e.TotalDue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader_inmem>()
                .Property(e => e.CreditCardApprovalCode)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrderHeader_inmem>()
                .Property(e => e.SubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader_inmem>()
                .Property(e => e.TaxAmt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader_inmem>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader_inmem>()
                .HasMany(e => e.SalesOrderDetail_inmem)
                .WithRequired(e => e.SalesOrderHeader_inmem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SalesOrderHeader_ondisk>()
                .Property(e => e.CreditCardApprovalCode)
                .IsUnicode(false);

            modelBuilder.Entity<SalesOrderHeader_ondisk>()
                .Property(e => e.SubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader_ondisk>()
                .Property(e => e.TaxAmt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader_ondisk>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesOrderHeader_ondisk>()
                .HasMany(e => e.SalesOrderDetail_ondisk)
                .WithRequired(e => e.SalesOrderHeader_ondisk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SalesPerson>()
                .Property(e => e.SalesQuota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesPerson>()
                .Property(e => e.Bonus)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesPerson>()
                .Property(e => e.CommissionPct)
                .HasPrecision(10, 4);

            modelBuilder.Entity<SalesPerson>()
                .Property(e => e.SalesYTD)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesPerson>()
                .Property(e => e.SalesLastYear)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesPerson>()
                .HasMany(e => e.SalesOrderHeaders)
                .WithOptional(e => e.SalesPerson)
                .HasForeignKey(e => e.SalesPersonID);

            modelBuilder.Entity<SalesPerson>()
                .HasMany(e => e.SalesPersonQuotaHistories)
                .WithRequired(e => e.SalesPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SalesPerson>()
                .HasMany(e => e.SalesTerritoryHistories)
                .WithRequired(e => e.SalesPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SalesPerson>()
                .HasMany(e => e.Stores)
                .WithOptional(e => e.SalesPerson)
                .HasForeignKey(e => e.SalesPersonID);

            modelBuilder.Entity<SalesPersonQuotaHistory>()
                .Property(e => e.SalesQuota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesReason>()
                .HasMany(e => e.SalesOrderHeaderSalesReasons)
                .WithRequired(e => e.SalesReason)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SalesTaxRate>()
                .Property(e => e.TaxRate)
                .HasPrecision(10, 4);

            modelBuilder.Entity<SalesTerritory>()
                .Property(e => e.SalesYTD)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesTerritory>()
                .Property(e => e.SalesLastYear)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesTerritory>()
                .Property(e => e.CostYTD)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesTerritory>()
                .Property(e => e.CostLastYear)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalesTerritory>()
                .HasMany(e => e.SalesTerritoryHistories)
                .WithRequired(e => e.SalesTerritory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SpecialOffer>()
                .Property(e => e.DiscountPct)
                .HasPrecision(10, 4);

            modelBuilder.Entity<SpecialOffer>()
                .HasMany(e => e.SpecialOfferProducts)
                .WithRequired(e => e.SpecialOffer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SpecialOffer_inmem>()
                .Property(e => e.DiscountPct)
                .HasPrecision(10, 4);

            modelBuilder.Entity<SpecialOffer_inmem>()
                .HasMany(e => e.SpecialOfferProduct_inmem)
                .WithRequired(e => e.SpecialOffer_inmem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SpecialOffer_ondisk>()
                .Property(e => e.DiscountPct)
                .HasPrecision(10, 4);

            modelBuilder.Entity<SpecialOffer_ondisk>()
                .HasMany(e => e.SpecialOfferProduct_ondisk)
                .WithRequired(e => e.SpecialOffer_ondisk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SpecialOfferProduct>()
                .HasMany(e => e.SalesOrderDetails)
                .WithRequired(e => e.SpecialOfferProduct)
                .HasForeignKey(e => new { e.SpecialOfferID, e.ProductID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SpecialOfferProduct_inmem>()
                .HasMany(e => e.SalesOrderDetail_inmem)
                .WithRequired(e => e.SpecialOfferProduct_inmem)
                .HasForeignKey(e => new { e.SpecialOfferID, e.ProductID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SpecialOfferProduct_ondisk>()
                .HasMany(e => e.SalesOrderDetail_ondisk)
                .WithRequired(e => e.SpecialOfferProduct_ondisk)
                .HasForeignKey(e => new { e.SpecialOfferID, e.ProductID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.Store)
                .HasForeignKey(e => e.StoreID);

            modelBuilder.Entity<vPersonDemographic>()
                .Property(e => e.TotalPurchaseYTD)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vSalesPerson>()
                .Property(e => e.SalesQuota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vSalesPerson>()
                .Property(e => e.SalesYTD)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vSalesPerson>()
                .Property(e => e.SalesLastYear)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vSalesPersonSalesByFiscalYear>()
                .Property(e => e.C2002)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vSalesPersonSalesByFiscalYear>()
                .Property(e => e.C2003)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vSalesPersonSalesByFiscalYear>()
                .Property(e => e.C2004)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vStoreWithDemographic>()
                .Property(e => e.AnnualSales)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vStoreWithDemographic>()
                .Property(e => e.AnnualRevenue)
                .HasPrecision(19, 4);
        }
    }
}
