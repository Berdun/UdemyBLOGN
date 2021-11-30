using BLOGN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Services.IService
{
     public interface IUserService
     {
          bool IsUniqueUser(string username);
          User Authenticate(string username, string password);
          User Register(string username, string password);
     }
}
