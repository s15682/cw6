﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw6.DTOs
{

    public class RefreshRequestDto
    { 
        public string Login { get; set; }
        public string Token { get; set; }
    }
}
