using AddressBookService.Application;
using AddressBookService.Model;
using EFAddressBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AddressBookAPI.Controllers
{
    public class AddressBookController : ApiController
    {
        public IAddressBookApplication AddressBookService { get; set; }
        public AddressBookController(IAddressBookApplication addressBookService)
        {
            AddressBookService = addressBookService;
        }


        [HttpGet]
        // GET: api/AddressBook
        public IEnumerable<Contact> Get()
        {

            try
            {
                var result = AddressBookService.Getcontacts().ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        // GET: api/AddressBook/5
        public IHttpActionResult Get(string name)
        {
            try
            {
                var result = AddressBookService.Getcontact(name);
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.ServiceUnavailable);
            }
        }

        // POST: api/AddressBook
        [HttpPost]
        public IHttpActionResult Post(Contact contact)
        {
            try
            {

                AddressBookService.Addcontact(contact);
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.ServiceUnavailable);
            }
        }

        [HttpPut]
        // PUT: api/AddressBook/5
        public IHttpActionResult Put(Contact contact)
        {
            try
            {

                AddressBookService.Updatecontact(contact);
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.ServiceUnavailable);
            }
        }

        [HttpDelete]
        // DELETE: api/AddressBook/5
        public IHttpActionResult Delete(int id)
        {
            try
            {

                AddressBookService.Deletecontact(id);
                return StatusCode(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}
