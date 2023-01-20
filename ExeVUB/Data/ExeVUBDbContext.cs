using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExeVUB.Models;

    public class ExeVUBDbContext : DbContext
    {
        public ExeVUBDbContext (DbContextOptions<ExeVUBDbContext> options)
            : base(options)
        {
        }

        public DbSet<ExeVUB.Models.Project> Project { get; set; } = default!;
    }
