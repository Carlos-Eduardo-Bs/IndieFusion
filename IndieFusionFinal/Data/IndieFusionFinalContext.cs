using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IndieFusionFinal.Models;

namespace IndieFusionFinal.Data
{
    public class IndieFusionFinalContext : DbContext
    {
        public IndieFusionFinalContext (DbContextOptions<IndieFusionFinalContext> options)
            : base(options)
        {
        }

        public DbSet<IndieFusionFinal.Models.Game> Game { get; set; } = default!;
        public DbSet<IndieFusionFinal.Models.Review> Reviews { get; set; } = default!;
        public DbSet<IndieFusionFinal.Models.NewsModel> news { get; set; } = default!;
        public DbSet<IndieFusionFinal.Models.User> User { get; set; } = default!;
        public DbSet<IndieFusionFinal.Models.UserType> UserType { get; set; } = default!;
        public DbSet<IndieFusionFinal.Models.Genre> Genre { get; set; } = default!;
        public DbSet<IndieFusionFinal.Models.Classification> Classification { get; set; } = default!;
    }
}
