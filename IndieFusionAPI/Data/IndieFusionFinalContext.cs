using IndieFusionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace IndieFusionAPI.Data
{
    public class IndieFusionFinalContextProject : DbContext
    {
        public IndieFusionFinalContextProject(DbContextOptions<IndieFusionFinalContextProject> options)
           : base(options)
        {
        }

        //entidades
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserType { get; set; }
    }
}
