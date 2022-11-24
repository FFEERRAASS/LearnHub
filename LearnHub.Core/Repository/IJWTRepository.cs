using LearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnHub.Core.Repository
{
    public interface IJWTRepository
    {
        Login Auth(Login login);
    }
}
