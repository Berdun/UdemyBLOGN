using BLOGN.Data.Repositories.IRepository;
using BLOGN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Repositories.Repository
{
     internal class ArticleRepository : Repository<Article>, IArticleRepository
     {
          private ApplicationDbContext _context;
          public ArticleRepository(ApplicationDbContext context) : base(context)
          {
               _context = context;
          }
     }
}
