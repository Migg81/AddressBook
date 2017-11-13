namespace EFAddressBook
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AddressBookDBContext : DbContext
    {
        public AddressBookDBContext()
            : base("name=AddressBookDBContext")
        {
        }

        public virtual DbSet<tblAddressBook> tblAddressBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblAddressBook>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<tblAddressBook>()
                .Property(e => e.Phone)
                .IsFixedLength();
        }
    }
}
