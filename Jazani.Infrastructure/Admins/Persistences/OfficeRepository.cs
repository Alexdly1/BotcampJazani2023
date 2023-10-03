using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;


namespace Jazani.Infrastructure.Admins.Persistences
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public OfficeRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IReadOnlyList<Office>> FindAllAsync()
        {
            return await _dbcontext.Offices.ToListAsync();
        }

        public async Task<Office?> FindByIdAsync(int Id)
        {
            return await _dbcontext.Offices
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Office> SaveAsync(Office office)
        {
            EntityState state = _dbcontext.Entry(office).State;

            _ = state switch
            {
                EntityState.Detached => _dbcontext.Offices.Add(office),
                EntityState.Modified => _dbcontext.Offices.Update(office),
            };

            await _dbcontext.SaveChangesAsync();

            return office;
        }
    }
}
