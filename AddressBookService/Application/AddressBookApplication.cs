using AddressBookService.Model;
using EFAddressBook;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookService.Application
{
    public class AddressBookApplication: IAddressBookApplication
    {
        public AddressBookDBContext DbContext { get; set; }
        public Contact ABContact { get; set; }
        public AddressBookApplication(AddressBookDBContext context, Contact abContact)
        {
            context.Database.CommandTimeout = 300;
            DbContext = context;

            ABContact = abContact;
        }

        public IQueryable<Contact> Getcontacts()
        {
            try
            {
                var contact = DbContext.tblAddressBooks.Select(s => new Contact { Address = s.Address, Email = s.Email, Name = s.Name, Id = s.Id, Phone = s.Phone }); ;

                return contact;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IQueryable<Contact> Getcontact(string name)
        {
            try
            {
                var contact = DbContext.tblAddressBooks.Where(s => s.Name.Contains(name)).Select(s => new Contact { Address = s.Address, Email = s.Email, Name = s.Name, Id = s.Id, Phone = s.Phone });

                return contact;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void Addcontact(Contact contact)
        {
            try
            {
                DbContext.tblAddressBooks.Add(new tblAddressBook { Name = contact.Name, Address = contact.Address, Phone = contact.Phone, Email = contact.Email });
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex ;
            }
        }

        public void Updatecontact(Contact contact)
        {
            try
            {
                var resultContact = DbContext.tblAddressBooks.FirstOrDefault(s => s.Id.Equals(contact.Id));

                resultContact.Name = contact.Name;
                resultContact.Address = contact.Address;
                resultContact.Phone = contact.Phone;
                resultContact.Email = contact.Email;

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Deletecontact(int id)
        {
            try
            {
                var contact = DbContext.tblAddressBooks.FirstOrDefault(s => s.Id.Equals(id));

                DbContext.tblAddressBooks.Remove(contact);

                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
