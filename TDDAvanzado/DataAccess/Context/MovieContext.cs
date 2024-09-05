using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieContext() { }

        public MovieContext(DbContextOptions options) : base(options) { }
    }
}
