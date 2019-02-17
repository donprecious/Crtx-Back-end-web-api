using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using CrExtApiCore.Models;

namespace CrExtApiCore.Repositories
{
  public  interface IReviewKind
    {
        Task Create(ReviewKinds reviewKind);
        //Task Update(int projectId, string name, string description);

        Task Delete(int reviewId);
        Task<bool> Find(int reviewId);
        Task<ReviewKinds> Get(int reviewId);

        Task<IEnumerable<ReviewKinds>> List();
    
        Task<bool> Save();
    }
}
