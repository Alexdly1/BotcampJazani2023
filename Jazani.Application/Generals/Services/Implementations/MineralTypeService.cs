using Jazani.Application.Generals.Dtos.MineralTypes;
using AutoMapper;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;

namespace Jazani.Application.Generals.Services.Implementations
{
    public class MineralTypeService : IMineralTypeService
    {
        private readonly IMineralTypeRepository _mineralTypeRepository;
        private readonly IMapper _mapper;

        public MineralTypeService(IMineralTypeRepository mineralTypeRepository, IMapper mapper)
        {
            _mineralTypeRepository = mineralTypeRepository;
            _mapper = mapper;
        }

        public async Task<MineralTypeDto> CreateAsync(MineralTypeSavaDto savaDto)
        {
            MineralType mineralType = _mapper.Map<MineralType>(savaDto);

            mineralType.RegistrationDate = DateTime.Now;

            mineralType.State = true;
            
            await _mineralTypeRepository.SaveAsync(mineralType);

            return _mapper.Map<MineralTypeDto>(mineralType);
        }

        public async Task<MineralTypeDto> DisabledAsync(int id)
        {
            MineralType mineralType = await _mineralTypeRepository.FindByIdAsync(id);

            mineralType.State = false;

            await _mineralTypeRepository.SaveAsync(mineralType);

            return _mapper.Map<MineralTypeDto>(mineralType);
        }

        public async Task<MineralTypeDto> EditAsync(int id, MineralTypeSavaDto savaDto)
        {
            MineralType mineralType = await _mineralTypeRepository.FindByIdAsync(id);

            _mapper.Map<MineralTypeSavaDto, MineralType>(savaDto, mineralType);

            await _mineralTypeRepository.SaveAsync(mineralType);

            return _mapper.Map<MineralTypeDto>(mineralType);
        }

        public async Task<IReadOnlyList<MineralTypeDto>> FindAllAsync()
        {
            IReadOnlyList<MineralType> mineralTypes = await _mineralTypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MineralTypeDto>>(mineralTypes);
        }

        public async Task<MineralTypeDto?> FindByIdAsync(int id)
        {
            MineralType mineralType = await _mineralTypeRepository.FindByIdAsync(id);

            return _mapper.Map<MineralTypeDto>(mineralType);

        }
    }
}
