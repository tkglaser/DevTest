using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Business.Mapping;
using DeveloperTest.Database;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext context;

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public JobModel[] GetJobs()
        {
            return context.Jobs
                .Include(x => x.Customer)
                .Select(x => x.ToModel())
                .ToArray();
        }

        public JobModel GetJob(int jobId)
        {
            return context.Jobs
                .Include(x => x.Customer)
                .Where(x => x.JobId == jobId)
                .Select(x => x.ToModel())
                .SingleOrDefault();
        }

        public JobModel CreateJob(BaseJobModel model)
        {
            var addedJob = context.Jobs.Add(model.ToDbModel());

            context.SaveChanges();

            return GetJob(addedJob.Entity.JobId);
        }
    }
}
