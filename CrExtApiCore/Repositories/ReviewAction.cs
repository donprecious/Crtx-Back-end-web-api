using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrExtApiCore.Repositories;
using Entities;
using CrExtApiCore.Models;

namespace CrExtApiCore.Repositories
{
    public class ReviewAction : IReviewAction
    {
        readonly CrExtContext _context;
        public ReviewAction(CrExtContext context)
        {
            _context = context;
        }
   
        public async Task Create(ReviewActions reviewAction)
        {
            await _context.ReviewActions.AddAsync(reviewAction);
        }
        public async Task<bool> Find(int reviewId)
        {
          
            if ((await _context.ReviewActions.FindAsync(reviewId)) != null)
            {
                return true;
            }
            return false;
        }
        public async Task<ReviewActions> Get(int reviewId)
        {
           
            return await _context.ReviewActions.FindAsync(reviewId);
        }
        public async Task Delete(int reviewId)
        {
          await Task.Run(() => _context.ReviewActions.Remove(_context.ReviewActions.Find(reviewId)));
        }

        public async Task<IEnumerable<ReviewActions>> List()
        {

            return await Task.Run(() => _context.ReviewActions.ToList());
        }

        public  async Task<bool> Save()
        {
              return ((await _context.SaveChangesAsync()) >= 0);
        }

        Task<Reviews> IReviewAction.Get(int Id)
        {
            throw new NotImplementedException();
        }

      
    }
}
