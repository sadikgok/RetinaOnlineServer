using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RetinaOnlineServer.Application.Abstractions;
using RetinaOnlineServer.Domain.AppEntities.Identity;

namespace RetinaOnlineServer.Application.Features.AppFeatures.AppUserFeatures.Login
{
    public sealed class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<AppUser> _userManager;

        public LoginHandler(UserManager<AppUser> userManager, IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.Users.Where(p => p.Email ==
            request.EmailOrUserName || p.UserName ==
            request.EmailOrUserName).FirstOrDefaultAsync();
            if (user == null) throw new Exception("Kullanıcı bulunamadı");

            var checkUser = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!checkUser) throw new Exception("Şifreniz yanlış!");

            List<string> roles = new();
            LoginResponse response = new()
            {
                Email = user.Email,
                NameLastName = user.NameLastName,
                UserId = user.Id,
                Token = await _jwtProvider.CreateTokenAsync(user, roles)
            };
            return response;
        }
    }
}
