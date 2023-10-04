using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class MineralTypeRepository : IMineralTypeRepository
    {
        private readonly ApplicationDbContext _dbContex;

        public MineralTypeRepository(ApplicationDbContext dbContex)
        {
            _dbContex = dbContex;
        }

        public async Task<IReadOnlyList<MineralType>> FindAllAsync()
        {
            return await _dbContex.MineralTypes.AsNoTracking().ToListAsync();
        }

        public async Task<MineralType?> FindByIdAsync(int Id)
        {
            return await _dbContex.MineralTypes.FindAsync(Id);
        }

        public async Task<MineralType> SaveAsync(MineralType mineralType)
        {
            EntityState state = _dbContex.Entry(mineralType).State;
            _ = state switch
            {
                EntityState.Detached => _dbContex.MineralTypes.Add(mineralType),
                EntityState.Modified => _dbContex.MineralTypes.Update(mineralType)
            };

            await _dbContex.SaveChangesAsync();

            return mineralType;
        }
    }
}
