using Jazani.Domain.Admins.Models;
using Jazani.Domain.Cores.Repositories;
using System;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IOfficeRepository : ICrudRepository<Office, int>
    {
    }
}
