using Jazani.Domain.Admins.Models;
using System;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IOfficeRepository
    {
        Task<IReadOnlyList<Office>> FindAllAsync();
        Task<Office?> FindByIdAsync(int Id);
    }
}
