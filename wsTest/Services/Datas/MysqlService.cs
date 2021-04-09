using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using wsTest.Helpers;
using wsTest.Models.Data;

namespace wsTest.Models.Services.Datas
{
    public class MysqlService : IDBService
    {
        AppSettings _appSettings;
        public MysqlService(IOptions<AppSettings> appSettings)
        {
            this._appSettings = appSettings.Value;
        }

        public async Task<List<User>> GetAll()
        {
            List<User> res = new List<User>();
            res.Add(new User(1, "Roberto", "roberto@daint.it"));
            res.Add(new User(2, "Stefano", "stefano@daint.it"));
            res.Add(new User(3, "Matteo", "matteo@daint.it"));
            res.Add(new User(4, "Riky", "ricky@daint.it"));
            return res;
        }

        public async Task<LoginResult> GetById(int id)
        {
            LoginResult res = new LoginResult();
            res.token = "";
            res.id = id;
            res.userName = "gas";
            res.password = "gas";               
            res.dtLog = DateTime.Now;
            return res;
        }

        public async Task<LoginResult> login(Login credentials)
        {
            LoginResult res = new LoginResult();
            res.token = "";
            if (credentials.userName == "gas")
            {
                credentials.id = 1;
                res.userName = credentials.userName;
                res.password = credentials.password;
                res.token = generateJwtToken(credentials);
                res.dtLog = DateTime.Now;
            }
            return res;
        }



        private string generateJwtToken(Login user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            try
            {
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }
    }
}
