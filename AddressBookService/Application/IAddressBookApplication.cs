using AddressBookService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookService.Application
{
    public interface IAddressBookApplication
    {
        IQueryable<Contact> Getcontacts();
        IQueryable<Contact> Getcontact(string name);
        void Addcontact(Contact contact);
        void Updatecontact(Contact contact);
        void Deletecontact(int id);

    }
}
