﻿using AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Handler
{
    public interface IJwtManager
    {
        string Authenticate(UserModel model);
    }
}
