﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Usuarios.Application.DTO
{
    public class UserDto
    {
        public int? UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
   
        public string UserName { get; set; }
        public string Password { get; set; }

        public string? Token { get; set; }
    }
}
