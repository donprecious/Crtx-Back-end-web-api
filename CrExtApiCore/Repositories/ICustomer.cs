using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using CrExtApiCore.Models;

namespace CrExtApiCore.Repositories
{
  public  interface ICustomer
    {
        Task Create(Customers customerDtom);
        //Task Update(int projectId, string name, string description);

        Task Delete(string customerId);
        Task<bool> Find(string customerId);
        Task<Customers> Get(string customerId);

        Task<IEnumerable<Customers>> List();
        //Task<bool> OrganisationHasProject(int organisationId);

        //Task<IEnumerable<Projects>> OrganisationProjects(int organisationId);
        Task<bool> Save();
    }
}
