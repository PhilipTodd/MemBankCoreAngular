using MemBankCoreAngular.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemBankCoreAngular.DAL
{
    public class MemBankContext : BaseDbContext
    {
        public MemBankContext(DbContextOptions<MemBankContext> options) : base(options)
        {

        }

        public DbSet<CodeItem> CodeItem { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Tag> Tag { get; set; }

    }

}
