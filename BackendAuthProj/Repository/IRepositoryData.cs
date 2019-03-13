using BackEndAuthProj.Models;
using System.Collections.Generic;

namespace BackendAuthProj.Repository
{
    public interface IJobRepository
    {
        IEnumerable<Job> GetElementByTitle(string title);
        Job GetElementById(int id);
        string GetCurrentUserId();
        Job Update(Job updatedJob);
        Job Create(Job createdJob);
        Job Delete(int id);
        int Commit();
    }
}
