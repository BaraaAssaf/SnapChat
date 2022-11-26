using Core.Data;
using Core.DTO;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Linq;

namespace Infra.Service
{
    public class LoginSvice : ILoginServce
    {
        private readonly ILoginRepository loginRepository;
        private readonly IUserRepository user;
        public LoginSvice(ILoginRepository _loginRepository , IUserRepository user)
        {
            loginRepository = _loginRepository;
            this.user = user;
        }

        public bool CreteLogin(Login login)
        {
            return loginRepository.CreteLogin(login);
        }

        public bool DeleteLogin(Login login)
        {
            return loginRepository.DeleteLogin(login);
        }

        public List<getalluser_dto> GetAllActiveUser()
        {
            return loginRepository.GetAllActiveUser();
        }

        public List<getalluser_dto> GetAllUser()
        {
            return loginRepository.GetAllUser();
        }

        public bool UpdateIsActev(Login login)
        {
            return loginRepository.UpdateIsActev(login);
        }

        public bool UpdateIsBlock(Login login)
        {
            return loginRepository.UpdateIsBlock(login);
        }

        public bool UpdateLogenPassword(Login login)
        {
            return loginRepository.UpdateLogenPassword(login);
        }

        public string Authentication_jwt(Login login)
        {
            var result = loginRepository.Auth(login);

            

           // var rolename = result.role.rolename;

            if (result == null)
            {
                return null;
            }

            var U = user.GetAllUser().FirstOrDefault(x => x.id == result.Userid);

            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]");
            var tokenDescirptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Name,result.Username),
                    new Claim(ClaimTypes.Role, result.Roleid.ToString()),
                    new Claim("Image", U.imagepath),
                     new Claim("isBlock", result.Isblock.ToString(), ClaimValueTypes.Integer32),
                    new Claim("userid", U.id.ToString(), ClaimValueTypes.Integer32) ,
                    new Claim("LoginId", result.ID.ToString(), ClaimValueTypes.Integer32)
                }
                ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.Aes128CbcHmacSha256)
            };

            var generatetoken = tokenhandler.CreateToken(tokenDescirptor);
            return tokenhandler.WriteToken(generatetoken);
        }
    }
    }

