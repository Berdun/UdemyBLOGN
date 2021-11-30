using BLOGN.Data.Repositories.Repository;
using BLOGN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Repositories.IRepository
{
     public interface IArticleRepository:IRepository<Article>
     {
     }
}
