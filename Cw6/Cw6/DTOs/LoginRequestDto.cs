using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw6.DTOs
{
    public class LoginRequestDto
    { 
        public string Login { get; set; }
        public string Haslo { get; set; }
    }
}
