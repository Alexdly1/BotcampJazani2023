using Jazani.Domain.Admins.Models;
using Jazani.Domain.Generals.Models;
using System;

namespace Jazani.Domain.Generals.Repositories
{
    public interface IMineralTypeRepository
    {
        Task<IReadOnlyList<MineralType>> FindAllAsync();
        Task<MineralType?> FindByIdAsync(int Id);
        Task<MineralType> SaveAsync(MineralType mineralType);
    }
}
