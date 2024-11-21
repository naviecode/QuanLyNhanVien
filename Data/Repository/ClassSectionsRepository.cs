using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ClassSectionsRepository : RepositoryBase<ClassSection>, IClassSectionsRepository
    {
        public ClassSectionsRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
