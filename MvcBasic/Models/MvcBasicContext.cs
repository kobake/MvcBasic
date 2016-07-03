using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcBasic.Models
{
    public class MvcBasicContext
    {
        public DbSet<Member> Members { get; set; }
    }
}
