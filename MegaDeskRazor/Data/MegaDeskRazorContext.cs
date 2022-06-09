using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazor;

namespace MegaDeskRazor.Data
{
    public class MegaDeskRazorContext : DbContext
    {
        public MegaDeskRazorContext (DbContextOptions<MegaDeskRazorContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskRazor.DeskQuote> DeskQuote { get; set; }
    }
}
