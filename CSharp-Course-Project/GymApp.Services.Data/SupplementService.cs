namespace GymApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using GymApp.Data;
    using GymApp.Data.Models;
    using GymApp.Services.Data.Interfaces;

    using static GymApp.Common.ExceptionMessages;

    public class SupplementService : ISupplementService
    {
        private readonly GymAppDbContext dbContext;
        public SupplementService(GymAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Supplement> GetSupplemenntByNameAsync(string supplementName)
        {
            Supplement? supplement = await dbContext.Supplements.FirstOrDefaultAsync(p => p.Name == supplementName);
            if (supplement == null)
            {
                throw new ArgumentException(ThereIsNoSupplementWithThisName);
            }

            return supplement;
        }
    }
}
