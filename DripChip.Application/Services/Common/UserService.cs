using DripChip.Application.Dto;
using DripChip.Application.Extensions;
using DripChip.Application.Mappers;
using DripChip.Core.Entities;
using DripChip.Core.Exceptions;
using DripChip.Core.Extensions;
using DripChip.Core.Interfaces;

namespace DripChip.Application.Services.Common;

public class UserService : IUserService
{
    private readonly IRepository<User, int> _userRepository;
    private readonly IRepository<Animal, long> _animalRepository;

    public UserService(IRepository<User, int> userRepository, IRepository<Animal, long> animalRepository)
    {
        _userRepository = userRepository;
        _animalRepository = animalRepository;
    }

    public async Task<Result<UserResponseDto.Info?>> Authenticate(UserRequestDto.Authenticate credentials)
    {
        if (string.IsNullOrEmpty(credentials.Email) || string.IsNullOrEmpty(credentials.Password))
        {
            return new ArgumentException("Credentials are null or empty");
        }

        var user = await Task.Run(() => _userRepository.Items.FirstOrDefault(
            u => u.Email == credentials.Email && u.Password == credentials.Password));
        return ApplicationMapper.Mapper.Map<UserResponseDto.Info>(user);
    }

    public async Task<Result<UserResponseDto.Info>> Registration(UserRequestDto.AccountManagement user)
    {
        if (_userRepository.Items.Any(u => u.Email == user.Email))
        {
            return new EntityExistsException(nameof(User), user.Email);
        }

        var result = await _userRepository.AddAsync(ApplicationMapper.Mapper.Map<User>(user));
        return ApplicationMapper.Mapper.Map<UserResponseDto.Info>(result);
    }

    public async Task<Result<UserResponseDto.Info>> GetInfo(int accountId)
    {
        var user = await _userRepository.GetAsync(accountId);
        if (user == null)
        {
            return new EntityNotFoundException(nameof(User), accountId);
        }

        return ApplicationMapper.Mapper.Map<UserResponseDto.Info>(user);
    }

    public Result<List<UserResponseDto.Info>> SearchUser(UserRequestDto.Search prompt)
    {
        var found = _userRepository.Items.Where(u => IsMatch(u, prompt)).Paged(prompt.From, prompt.Size);
        return ApplicationMapper.Mapper.Map<List<UserResponseDto.Info>>(found.ToList());
    }

    private static bool IsMatch(User user, UserRequestDto.Search prompt)
    {
        var condition = false;

        if (!string.IsNullOrEmpty(prompt.Email))
            condition &= user.Email.Contains(prompt.Email);
        if (!string.IsNullOrEmpty(prompt.FirstName))
            condition &= user.FirstName.Contains(prompt.FirstName);
        if (!string.IsNullOrEmpty(prompt.LastName))
            condition &= user.LastName.Contains(prompt.LastName);

        return condition;
    }

    public async Task<Result<UserResponseDto.Info>> UpdateAccount(int accountId,
        UserRequestDto.AccountManagement newData)
    {
        var currentUser = await _userRepository.GetUntrackedAsync(accountId);

        if (currentUser == null)
        {
            return new AccountAccessException($"Account with this id ({accountId}) not found");
        }

        if (_userRepository.Items.Any(u => u.Email == newData.Email && u.Id != accountId))
        {
            return new EntityExistsException(nameof(User), newData.Email);
        }

        var newUser = ApplicationMapper.Mapper.Map<UserRequestDto.AccountManagement, User>(newData, opt =>
            opt.AfterMap((src, dest) => dest.Id = accountId));

        await _userRepository.UpdateAsync(newUser);
        return ApplicationMapper.Mapper.Map<UserResponseDto.Info>(await _userRepository.GetAsync(accountId));
    }

    public async Task<Result> DeleteAccount(int accountId)
    {
        var currentUser = await _userRepository.GetUntrackedAsync(accountId);

        if (currentUser == null)
        {
            return new AccountAccessException($"Account with this id ({accountId}) not found");
        }

        if (_animalRepository.Items.Any(a => a.Chipper.Id == accountId))
        {
            return new ArgumentException("Cannot delete this account because of the connection with the animal");
        }

        await _userRepository.RemoveAsync(accountId);
        return Result.Success();
    }
}