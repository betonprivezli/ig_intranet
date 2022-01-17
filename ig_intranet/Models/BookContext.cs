using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnumSample.Models
{
    
    public class BookContext : DbContext
    {
        public DbSet<MyData2> Books { get; set; }
        
    }
}
