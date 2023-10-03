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
    }
}
