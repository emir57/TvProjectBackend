using Core.Entities.Concrete;
using Core.Extensions;
using Core.Security.Encryption;
using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public AccessToken CreateToken(User user, List<Role> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signInCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityKeyToken(_tokenOptions, user, signInCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityKeyToken(TokenOptions tokenOptions, User user,
        SigningCredentials signingCredentials, List<Role> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                claims:SetClaims(user,operationClaims),
                notBefore: DateTime.Now,
                expires: _accessTokenExpiration,
                signingCredentials: signingCredentials);
            return jwt;
    }

        private IEnumerable<Claim> SetClaims(User user, List<Role> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    } 
}
