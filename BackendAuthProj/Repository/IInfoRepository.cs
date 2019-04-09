using BackEndAuthProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAuthProj.Repository
{
    public interface IInfoRepository
    {
        IEnumerable<GeneralInfo> GetElementByLocation(string location);
        GeneralInfo GetElementById(int id);
        string GetCurrentUserId();
        GeneralInfo Update(GeneralInfo updatedInfo);
        GeneralInfo Create(GeneralInfo createdInfo);
        GeneralInfo Delete(int id);
        int Commit();
    }
}
