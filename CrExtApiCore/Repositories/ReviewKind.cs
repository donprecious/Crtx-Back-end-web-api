using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrExtApiCore.Repositories;
using Entities;
using CrExtApiCore.Models;

namespace CrExtApiCore.Repositories
{
    public class ReviewKind : IReviewKind
    {
        readonly CrExtContext _context;
        public ReviewKind(CrExtContext context)
        {
            _context = context;
        }
   
        public async Task Create(ReviewKinds reviewkind)
        {
            await _context.ReviewKinds.AddAsync(reviewkind);
        }
        public async Task<bool> Find(int reviewId)
        {
          
            if ((await _context.ReviewKinds.FindAsync(reviewId)) != null)
            {
                return true;
            }
            return false;
        }
        public async Task<ReviewKinds> Get(int reviewId)
        {
           
            return await _context.ReviewKinds.FindAsync(reviewId);
        }
        public async Task Delete(int reviewId)
        {
          await Task.Run(() => _context.ReviewKinds.Remove(_context.ReviewKinds.Find(reviewId)));
        }

        public async Task<IEnumerable<ReviewKinds>> List()
        {

            return await Task.Run(() => _context.ReviewKinds.ToList());
        }

        public  async Task<bool> Save()
        {
              return ((await _context.SaveChangesAsync()) >= 0);
        }


    }
}
