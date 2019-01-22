using Microsoft.EntityFrameworkCore;
using Pusaka.DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pusaka.DataService.Contexts
{
    public class PusakaContext : DbContext
    {
        public PusakaContext(DbContextOptions<PusakaContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<School> Schools { get; set; }
    }
}
