using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodePepperInterview.DAL.EF.Contexts
{
    public class UrfSampleContextFactory : IDesignTimeDbContextFactory<UrfSampleContext>
    {
        public UrfSampleContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UrfSampleContext>();
            optionsBuilder.UseSqlServer(@"Data Source =./; initial catalog = CodePepperInterview; Integrated Security = True; MultipleActiveResultSets = True");
            return new UrfSampleContext(optionsBuilder.Options);
        }
    }
}