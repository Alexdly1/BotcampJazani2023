using Jazani.Domain.Generals.Repositories;
using Jazani.Infrastructure.Cores.Persistences;
using Jazani.Domain.Generals.Models;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class MineralRepository : CrudRepository<Mineral, int>, IMineralRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MineralRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<Mineral>> FindAllAsync()
        {
                                    
            return await _dbContext.Set<Mineral>()
                    .Include(t => t.MineralType)
                    .AsNoTracking()
                    .ToListAsync();
        }

        public override async Task<Mineral?> FindByIdAsync(int Id)
        {
            return await _dbContext.Set<Mineral>()
                .Include(t => t.MineralType)
                .FirstOrDefaultAsync(t => t.Id == Id);
        }

        public async override Task<Mineral> SaveAsync(Mineral entity)
        {
            EntityState state = _dbContext.Entry(entity).State;

            // entity.MineralType = await _dbContext.Set<MineralType>().FindAsync(entity.MineraltypeId);
            _ = state switch
            {
                EntityState.Detached => _dbContext.Set<Mineral>().Add(entity),
                EntityState.Modified => _dbContext.Set<Mineral>().Update(entity)

            };

            await _dbContext.SaveChangesAsync();

            //return entity;

            return await FindByIdAsync(entity.Id);
        }


    }
}
