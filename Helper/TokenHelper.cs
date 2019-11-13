using ContactsApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ContactsApi.Helper
{
    public class TokenHelper
    {
        private IEnumerable GetContactsClaims(Contacts contacts)
        {
            IEnumerable claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name,contacts.FirstName+" "+contacts.LastName),
                    new Claim("USERNAME",contacts.Username),
                    new Claim("READ_ONLY",contacts.READ_ONLY.ToString()),
                    new Claim("ACCESS_LEVEL",contacts.ACCESS_LEVEL),
                    new Claim("EMAIL",contacts.Email),
                    new Claim("PHONE",contacts.MobilePhone)
                };
            return claims;
        }
    }
}

