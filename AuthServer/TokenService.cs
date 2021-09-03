using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace AuthServer
{
    public class TokenService
    {
        private IOptions<Audience> _settings;

        public TokenService(IOptions<Audience> settings)
        {
            _settings = settings;
        }

        public string GenerateToken(User user)
        {
            var _calims = new[] { new Claim("aud", "catalogo"), new Claim("aud", "vendas") };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Value.Secret);

            var _signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(_settings.Value.Iss, null, _calims, DateTime.Now, DateTime.UtcNow.AddMinutes(2), _signingCredentials);

            /*var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _settings.Value.Iss,
                Audience = "[\"catalogo\",\"vendas\"]",
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);*/

            return tokenHandler.WriteToken(token);
        }

    }
}