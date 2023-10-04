using Jazani.Application.Generals.Dtos.MineralTypes;

namespace Jazani.Application.Generals.Services
{
    public interface IMineralTypeService
    {
        Task<IReadOnlyList<MineralTypeDto>> FindAllAsync();
        Task<MineralTypeDto?> FindByIdAsync(int id);
        Task<MineralTypeDto> CreateAsync(MineralTypeSavaDto savaDto);
        Task<MineralTypeDto> EditAsync(int id, MineralTypeSavaDto savaDto);
        Task<MineralTypeDto> DisabledAsync(int id);
    }
}
