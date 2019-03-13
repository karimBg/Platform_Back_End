using BackEndAuthProj.Models;
using System.Collections.Generic;

namespace BackendAuthProj.Repository
{
    public interface IRepositoryData
    {
        IEnumerable<Job> GetJobByTitle(string title);
        Job GetJobById(int id);
        Job UpdateJob(Job updatedJob);
        Job CreateJob(Job createdJob);
        Job DeleteJob(int id);
        int Commit();
    }
}
