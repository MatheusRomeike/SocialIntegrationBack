using Application.Interfaces.ServiceInterfaces;
using Application.Token;
using Application.ViewModels;
using Data.Contracts;
using Data.Interfaces.RepositoryInterface;
using Data.Repository;
using Domain.Dtos.Token;
using Domain.Entities.Account;
using Domain.Entities.User;
using Utils;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserService(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork
            )
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<TokenDto> LoginAsync(UserViewModel userModel)
        {
            var user = (await _userRepository.GetAllAsync()).FirstOrDefault();

            if (user != null)
            {
                var token = new TokenJWTBuilder()
                .AddSecurityKey(JwtSecurityKey.Create(Environment.GetEnvironmentVariable("SECRET_TOKEN")))
                .AddSubject("Token")
                .AddIssuer("SocialHub.Security.Bearer")
                .AddAudience("SocialHub.Security.Bearer")
                .AddClaim("UserId", user.Id.ToString())
                .AddExpiry(60 * 12)
                .Builder();

                var authenticationResult = new TokenDto
                {
                    AccessToken = token.Value,
                    ExpiresIn = 60 * 60 * 12
                };

                return authenticationResult;
            }
            else
                throw new UnauthorizedAccessException("Invalid credentials");
        }

        public async Task<bool> RegisterAsync(UserRegisterViewModel userModel)
        {
            if (await _userRepository.AnyAsync(predicate: p => p.Email == userModel.Email))
                throw new Exception("Email already exists");

            var passwordHash = PasswordHasher.HashPassword(userModel.Password);

            await _userRepository.AddAsync(new Domain.Entities.User.User()
            {
                Name = userModel.Name,
                Email = userModel.Email,
                Password = passwordHash,
            });
            return await _unitOfWork.CommitAsync();
        }
    }
}
