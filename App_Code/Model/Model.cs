namespace SA45Team02_SSIS
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    

    public partial class Model : DbContext
    {
        public Model()
            : base("name=SSIS_Team02Model")
        {
        }

        public virtual DbSet<Adjustment> Adjustments { get; set; }
        public virtual DbSet<CollectionPoint> CollectionPoints { get; set; }
        public virtual DbSet<DelegateAuthority> DelegateAuthorities { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ItemCatalog> ItemCatalogs { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<Representative> Representatives { get; set; }
        public virtual DbSet<Requisition> Requisitions { get; set; }
        public virtual DbSet<RequisitionItem> RequisitionItems { get; set; }
        public virtual DbSet<Retrieval> Retrievals { get; set; }
        public virtual DbSet<RetrievalItem> RetrievalItems { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierItem> SupplierItems { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<DisbursementItemView> DisbursementItemViews { get; set; }
        public virtual DbSet<DisbursementView> DisbursementViews { get; set; }
        public virtual DbSet<ItemView> ItemViews { get; set; }
        public virtual DbSet<OrderDetailsView> OrderDetailsViews { get; set; }
        public virtual DbSet<PurchaseOrderView> PurchaseOrderViews { get; set; }
        public virtual DbSet<RequisitionRequest> RequisitionRequests { get; set; }
        public virtual DbSet<StockCardView> StockCardViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollectionPoint>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.CollectionPoint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DelegateAuthority>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.DelegateAuthority)
                .HasForeignKey(e => e.Delegate_ID);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.Department_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Adjustments)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.Employee_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Adjustments1)
                .WithOptional(e => e.Employee1)
                .HasForeignKey(e => e.Acknowledged_By);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.DelegateAuthorities)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.Employee_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.HeadStaff_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Departments1)
                .WithRequired(e => e.Employee1)
                .HasForeignKey(e => e.Representative_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Departments2)
                .WithRequired(e => e.Employee2)
                .HasForeignKey(e => e.ContactStaff_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.PurchaseOrders)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.Employee_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.PurchaseOrders1)
                .WithOptional(e => e.Employee1)
                .HasForeignKey(e => e.Approved_By);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Representatives)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Requisitions)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemCatalog>()
                .HasMany(e => e.Adjustments)
                .WithRequired(e => e.ItemCatalog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemCatalog>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.ItemCatalog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemCatalog>()
                .HasMany(e => e.RequisitionItems)
                .WithRequired(e => e.ItemCatalog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemCatalog>()
                .HasMany(e => e.RetrievalItems)
                .WithRequired(e => e.ItemCatalog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemCatalog>()
                .HasMany(e => e.SupplierItems)
                .WithRequired(e => e.ItemCatalog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.PurchaseOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Requisition>()
                .HasMany(e => e.RequisitionItems)
                .WithRequired(e => e.Requisition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Requisition>()
                .HasMany(e => e.RetrievalItems)
                .WithRequired(e => e.Requisition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Retrieval>()
                .HasMany(e => e.RetrievalItems)
                .WithRequired(e => e.Retrieval)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.PurchaseOrders)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.SupplierItems)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockCardView>()
                .Property(e => e.Transaction_Type)
                .IsUnicode(false);
        }
    }
}
