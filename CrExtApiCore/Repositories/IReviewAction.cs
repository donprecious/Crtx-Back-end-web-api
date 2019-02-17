using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using CrExtApiCore.Models;

namespace CrExtApiCore.Repositories
{
  public  interface IReviewAction
    {
        Task Create(ReviewActions reviewAction);
        //Task Update(int projectId, string name, string description);

        Task Delete(int Id);
        Task<bool> Find(int Id);
        Task<Reviews> Get(int Id);

        Task<IEnumerable<ReviewActions>> List();
    
        Task<bool> Save();
    }
}
