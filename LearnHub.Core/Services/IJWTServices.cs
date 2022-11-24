using LearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnHub.Core.Services
{
    public interface IJWTServices
    {
        string Auth(Login login);
    }
}
