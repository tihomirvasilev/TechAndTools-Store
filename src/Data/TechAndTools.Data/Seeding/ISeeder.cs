using System;
using System.Threading.Tasks;

namespace TechAndTools.Data.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(TechAndToolsDbContext dbContext, IServiceProvider serviceProvider);
    }
}
