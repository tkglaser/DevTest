using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.Business.Mapping
{
    public static class JobExtensions
    {
        public static JobModel ToModel(this Job job)
        {
            return new JobModel
            {
                JobId = job.JobId,
                Engineer = job.Engineer,
                When = job.When,
                Customer = job.Customer?.ToModel()
            };
        }

        public static Job ToDbModel(this BaseJobModel model)
        {
            return new Job
            {
                Engineer = model.Engineer,
                When = model.When,
                CustomerId = model.CustomerId
            };
        }
    }
}