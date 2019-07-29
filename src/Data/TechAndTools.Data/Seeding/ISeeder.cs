using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TechAndTools.Data.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(TechAndToolsDbContext dbContext, IServiceProvider serviceProvider);
    }
}
