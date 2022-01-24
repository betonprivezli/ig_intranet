using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnumSample.Models
{
    
    public class UsersImpContext : DbContext
    {
        public DbSet<UsersImp> UsersImp { get; set; }        
        public DbSet<MyData> MyData { get; set; }        

    }
}
