﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAPI.Abstraction
{
    public interface ITokenParameters
    { 
        string UserName { get; set; }

        string PasswordHash { get; set; }

        string Id { get; set; }
    }
}
