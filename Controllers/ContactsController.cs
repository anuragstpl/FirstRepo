using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsApi.Models;
using ContactsApi.Repository;
using ContactsApi.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        public IContactsRepository contactsRepository { get; set; }

        ContactsValidator customerRules = new ContactsValidator();

        public ContactsController(IContactsRepository _repo)
        {
            contactsRepository = _repo;
        }

        [HttpGet]
        public IEnumerable<Contacts> GetAllContacts()
        {
            return contactsRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetContactsByName")]
        public IActionResult GetById(string name)
        {
            var item = contactsRepository.Find(name);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult CreateContact([FromBody] Contacts contact)
        {
            ValidationResult results = customerRules.Validate(contact);
            if (results.IsValid)
            {
                if (contact == null)
                {
                    return BadRequest();
                }
                contactsRepository.Add(contact);
                return CreatedAtRoute("GetContactsByName", new { Controller = "Contacts", id = contact.MobilePhone }, contact);
            }
            else
            {
                return new ObjectResult(results.Errors);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateContact(string id,[FromBody] Contacts contact)
        {
            if(contact==null)
            {
                return BadRequest();
            }
            var contactObj = contactsRepository.Find(id);
            if(contactObj==null)
            {
                return NotFound();
            }
            contactsRepository.Update(contact);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            contactsRepository.Remove(id);
        }
    }
}