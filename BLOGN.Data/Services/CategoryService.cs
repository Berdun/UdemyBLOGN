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
     public class CategoryService : Services<Category>, ICategoryService
     {
          public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
          {
          }

     }
}
