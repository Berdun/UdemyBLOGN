using BLOGN.Data.Repositories.IRepository;
using BLOGN.Models;
using BLOGN.SharedTools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Repositories.Repository
{
     public class UserRepository : IUserRepository
     {
          private ApplicationDbContext _contex;
          private readonly AppSettings _appSettings;
          private readonly DbSet<User> _dbSet;

          public UserRepository(ApplicationDbContext context, IOptions<AppSettings> appsettings)
          {
               _contex =  context;
               _dbSet = _contex.Set<User>();
               _appSettings = appsettings.Value;
          }

          public User Authenticate(string username, string password)
          {
               var user = _dbSet.SingleOrDefault(x=>x.UserName==username && x.Password == password);

               if (user==null)
               {
                    return null;
               }

               var tokenHandler = new JwtSecurityTokenHandler();
               var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
               var tokendDescriptor = new SecurityTokenDescriptor
               {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                         new Claim(ClaimTypes.Name,user.Id.ToString()),
                         new Claim(ClaimTypes.Role,user.Role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(5),
                    SigningCredentials = new SigningCredentials(
                         new SymmetricSecurityKey(key),
                         SecurityAlgorithms.HmacSha256Signature)
               };

               var token = tokenHandler.CreateToken(tokendDescriptor);
               user.Token = tokenHandler.WriteToken(token);
               user.Password = "";
               return user;

          }

          public bool IsUniqueUser(string username)
          {
               var user = _dbSet.SingleOrDefault(x=>x.UserName == username);

               if (user == null)
               {
                    return true;
               }

               return false;
          }

          public User Register(string username, string password)
          {
               User user = new User()
               {
                    UserName = username,
                    Password = password,
                    Role = "Admin",
                    Confirmation = false,
               };

              _dbSet.Add(user);
               return user;
          }
     }
}
