using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnumSample.Models
{

    public class UsersDoContext : DbContext
    {
              public DbSet<UsersDo> UsersDo { get; set; }

    }
}