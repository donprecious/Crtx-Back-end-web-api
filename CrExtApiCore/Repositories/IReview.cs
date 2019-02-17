using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using CrExtApiCore.Models;

namespace CrExtApiCore.Repositories
{
  public  interface IReview
    {
        Task Create(Reviews review);
        //Task Update(int projectId, string name, string description);

        Task Delete(int reviewId);
        Task<bool> Find(int reviewId);
        Task<Reviews> Get(int reviewId);

        Task<IEnumerable<Reviews>> List();
    
        Task<bool> Save();
    }
}
