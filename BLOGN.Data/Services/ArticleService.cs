using BLOGN.Data.Repositories.IRepository;
using BLOGN.Data.Services.IService;
using BLOGN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Services
{
     public class ArticleService : Services<Article>, IArticleService
     {
          public ArticleService(IUnitOfWork unitOfWork, IRepository<Article> repository) : base(unitOfWork, repository)
          {
          }
     }
}
