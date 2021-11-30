using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Repositories.IRepository
{
     public  interface IUnitOfWork :IDisposable
     {
          ICategoryRepository Category { get; }
          IArticleRepository Article { get; }
          IUserRepository User { get; }

          Task SaveAsync();
          void Save();

     }
}
