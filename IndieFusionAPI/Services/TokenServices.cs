using IndieFusionAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IndieFusionAPI.Services
{
    public class TokenService
    {
        //campo de apoio
        private readonly IConfiguration _configuration;

        //contrutor
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //metodo
        public string GerarToken(User user)
        {
            //iniciando o jwt
            var tokenHandler = new JwtSecurityTokenHandler();

            //convertendo a chave em bytes
            var chave = Encoding.ASCII.GetBytes(_configuration.GetSection("chave").Get<string>());

            //configurando perfis
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Name.ToString()),
                new Claim(ClaimTypes.Role, user.UserTp.ToString())
                }
                ),
                //tempo session
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(chave), SecurityAlgorithms.
                    HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
