using AutoMapper;
using BusinessLogic.IService;
using BusinessLogic.IService.IRoleService;
using BusinessLogic.IService.IRoleService.Dto;
using Data.Entities;
using Data.IRepository;

namespace BusinessLogic.Services.UserService
{
    public class RoleServices : IRoleServices
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public RoleServices(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public ResponseDataDto<RoleReadDto> GetCombobox()
        {
            var result = _repositoryManager.RolesRepository.GetAll();
            int totalItem = result.Count();
            return new ResponseDataDto<RoleReadDto>(_mapper.Map<List<Roles>, List<RoleReadDto>>(result), totalItem);

        }
    }
}
