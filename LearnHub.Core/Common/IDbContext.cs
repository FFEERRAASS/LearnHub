using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace LearnHub.Core.Common
{
    public interface IDbContext
    {
        public DbConnection Connection { get; }

    }
}
