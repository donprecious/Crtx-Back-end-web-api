 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using CrExtApiCore.Models;

namespace CrExtApiCore.Repositories
{
  public  interface IReviewNotification
    {
        Task Create(ReviewNotifications reviewNotificationDto);
        //Task Update(int projectId, string name, string description);

        Task Delete(int id);
        Task<bool> Find(int id);
        Task<ReviewNotifications> Get(int id);

        Task<IEnumerable<ReviewNotifications>> List();
        //Task<bool> OrganisationHasProject(int organisationId);

        //Task<IEnumerable<Projects>> OrganisationProjects(int organisationId);
        Task<bool> Save();
    }
}
