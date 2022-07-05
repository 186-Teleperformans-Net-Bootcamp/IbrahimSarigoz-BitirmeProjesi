﻿
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Domain.Entities.Identity
{
    public class Role : IdentityRole<string>
    {
        public string NameSurname { get; set; }
    }
}
