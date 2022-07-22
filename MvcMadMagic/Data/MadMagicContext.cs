using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMadMagic.Models;

    public class MadMagicContext : DbContext
    {
        public MadMagicContext (DbContextOptions<MadMagicContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMadMagic.Models.Spell>? Spell { get; set; }
    }
