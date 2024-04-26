using Application.Interfaces.ServiceInterfaces;
using Application.Token;
using Application.ViewModels;
using Data.Contracts;
using Data.Interfaces.RepositoryInterface;
using Domain.Dtos.Token;
using Utils;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;

        public UserService(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            ICompanyRepository companyRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
        }


        public async Task<TokenDto> LoginAsync(UserViewModel userModel)
        {
            var user = await _userRepository.GetOneAsync(
                predicate: p => p.Email == userModel.Email);

            if (user != null && PasswordHasher.VerifyPassword(user?.Password, userModel.Password))
            {
                var token = new TokenJWTBuilder()
                .AddSecurityKey(JwtSecurityKey.Create(Environment.GetEnvironmentVariable("SECRET_TOKEN")))
                .AddSubject("Token")
                .AddIssuer("SocialHub.Security.Bearer")
                .AddAudience("SocialHub.Security.Bearer")
                .AddClaim("UserId", user.Id.ToString())
                .AddClaim("CompanyId", user.CompanyId.ToString())
                .AddExpiry(60)
                .Builder();

                var authenticationResult = new TokenDto
                {
                    AccessToken = token.Value,
                    ExpiresIn = 3600
                };

                return authenticationResult;
            }
            else
                throw new Exception(i18n.Email_Or_Password_Invalid);
        }

        public async Task<bool> RegisterAsync(UserRegisterViewModel userModel)
        {
            if (await _userRepository.AnyAsync(predicate: p => p.Email == userModel.Email))
                throw new Exception(i18n.Email_Already_Registered);

            var passwordHash = PasswordHasher.HashPassword(userModel.Password);

            await _userRepository.AddAsync(new Domain.Entities.User.User()
            {
                Name = userModel.Name,
                Email = userModel.Email,
                Password = passwordHash,
                Role = userModel.Role,
                CompanyId = userModel.CompanyId,
            });
            return await _unitOfWork.CommitAsync();
        }
    }
}
