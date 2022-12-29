using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Presistance.Contexts
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RecognitionDB;Trusted_Connection=True;MultipleActiveResultSets=true;");

            return new ApplicationDbContext(optionBuilder.Options);
        }
    }
}
