using BackEndAuthProj.Models;
using System.Collections.Generic;

namespace BackendAuthProj.Repository
{
    public interface IRepositoryData
    {
        IEnumerable<Job> GetElementByTitle(string title);
        Job GetElementById(int id);
        Job Update(Job updatedJob);
        Job Create(Job createdJob);
        Job Delete(int id);
        int Commit();
    }
}
