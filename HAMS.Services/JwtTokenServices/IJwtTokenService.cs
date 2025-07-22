﻿using HAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMS.Services.JwtTokenServices
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
