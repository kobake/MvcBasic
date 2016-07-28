using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcBasic.Models
{
    public class MvcBasicContext : DbContext
    {
        public MvcBasicContext()
        {
            // this.Database.CommandTimeout = 5;
        }
        public DbSet<Member> Members { get; set; }
    }
}
