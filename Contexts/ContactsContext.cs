using ContactsApi.DBEntities;
using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi.Contexts
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options) { }
        public ContactsContext() { }
        public DbSet<Contacts> Contacts { get; set; }
    }
}
