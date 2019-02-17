using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrExtApiCore.Repositories;
using Entities;
using CrExtApiCore.Models;

namespace CrExtApiCore.Repositories
{
    public class Customer : ICustomer
    {
        readonly CrExtContext _context;
        public Customer(CrExtContext context)
        {
            _context = context;
        }
   
        public async Task Create(Customers customer)
        {
            await _context.Customers.AddAsync(customer);
        }
        public async Task<bool> Find(string cutomerId)
        {
            Guid id = Guid.Parse(cutomerId);
            if ((await _context.Customers.FindAsync(id)) != null)
            {
                return true;
            }
            return false;
        }
        public async Task<Customers> Get(string customerId)
        {
            Guid id = Guid.Parse(customerId);
            return await _context.Customers.FindAsync(id);
        }
        public async Task Delete(string customerId)
        {
          await Task.Run(() => _context.Customers.Remove(_context.Customers.Find(customerId)));
        }

        public async Task<IEnumerable<Customers>> List()
        {

            return await Task.Run(() => _context.Customers.ToList());
        }

    

    
        public  async Task<bool> Save()
        {
              return ((await _context.SaveChangesAsync()) >= 0);
        }

       

        //public async Task Update(int projectId, string name, string description)
        //{
        //    var project = await _context.Projects.FindAsync(projectId);
        //    if (project != null)
        //    {
        //        project.Description = description;
        //        project.Name = name;
        //        _context.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    }
        //}


    }
}
