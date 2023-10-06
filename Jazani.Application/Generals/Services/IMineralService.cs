using Jazani.Application.Generals.Dtos.Minerals;
using System;

namespace Jazani.Application.Generals.Services
{
    public interface IMineralService
    {
        Task<IReadOnlyList<MineralDto>> FindAllAsync();
        Task<MineralDto?> FindByIdAsync(int id);
        Task<MineralDto> CreateAsync(MineralSaveDto savaDto);
        Task<MineralDto> EditAsync(int id, MineralSaveDto savaDto);
        Task<MineralDto> DisabledAsync(int id);

    }
}
