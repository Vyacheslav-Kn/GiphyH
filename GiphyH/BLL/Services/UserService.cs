using AutoMapper;
using GiphyH.BLL.DTO;
using GiphyH.BLL.Interfaces;
using GiphyH.DAL.Entities;
using GiphyH.DAL.UserCommands;
using GiphyH.DAL.UserInterfaces;
using GiphyH.DAL.UserQueries;
using System.Threading.Tasks;

namespace GiphyH.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserCommandHandler _commandHandler;
        private readonly IUserQueryHandler _queryHandler;
        private readonly IMapper _mapper;
        private readonly ICryptoService _cryptoService;

        public UserService(IUserCommandHandler commandHandler, IUserQueryHandler queryHandler,
            IMapper mapper, ICryptoService cryptoService)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
            _mapper = mapper;
            _cryptoService = cryptoService;
        }

        public async Task<UserDTO> GetById(int id)
        {
            User user = await _queryHandler.Find(new FindById {
                Id = id
            });

            return _mapper.Map<User, UserDTO>(user);
        }

        public async Task<UserDTO> GetByName(string name)
        {
            User user = await _queryHandler.Find(new FindByName
            {
                Name = name
            });

            return _mapper.Map<User, UserDTO>(user);
        }

        public async Task Add(UserDTO user)
        {
            Add addCommand = _mapper.Map<UserDTO, Add>(user);
            addCommand.PasswordHash = _cryptoService.CreatePasswordHash(user.Password);

            await _commandHandler.Handle(addCommand);
        }

        public async Task Delete(int id)
        {
            await _commandHandler.Handle(new Delete {
                Id = id
            });
        }
    }
}
