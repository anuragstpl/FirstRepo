using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsApi.Contexts;
using ContactsApi.Models;

namespace ContactsApi.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        ContactsContext _context;

        public ContactsRepository(ContactsContext context)
        {
            _context = context;
        }

        public void Add(Contacts item)
        {
            _context.Contacts.Add(item);
            _context.SaveChanges();
        }

        public Contacts Find(string key)
        {
            return _context.Contacts.SingleOrDefault(x => x.ID == int.Parse(key));
        }

        public IEnumerable<Contacts> GetAll()
        {
            return _context.Contacts;
        }

        public void Remove(string Id)
        {
            var itemToRemove = _context.Contacts.SingleOrDefault(x => x.ID == int.Parse(Id));
            if (itemToRemove != null)
            {
                _context.Contacts.Remove(itemToRemove);
                _context.SaveChanges();
            }
        }

        public void Update(Contacts item)
        {
            var itemToUpdate = _context.Contacts.SingleOrDefault(r => r.ID == item.ID);
            if (itemToUpdate != null)
            {
                itemToUpdate.FirstName = item.FirstName;
                itemToUpdate.AnniversaryDate = item.AnniversaryDate;
                itemToUpdate.Company = item.Company;
                itemToUpdate.DateOfBirth = item.DateOfBirth;
                itemToUpdate.Email = item.Email;
                itemToUpdate.IsFamilyMember = item.IsFamilyMember;
                itemToUpdate.JobTitle = item.JobTitle;
                itemToUpdate.LastName = item.LastName;
                itemToUpdate.MobilePhone = item.MobilePhone;
                itemToUpdate.ACCESS_LEVEL = item.ACCESS_LEVEL;
                itemToUpdate.READ_ONLY = item.READ_ONLY;
                itemToUpdate.Username = item.Username;
                itemToUpdate.Password = item.Password;
                _context.SaveChanges();
            }
        }
    }
}
