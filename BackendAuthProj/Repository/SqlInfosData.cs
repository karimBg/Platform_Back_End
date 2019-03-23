using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BackendAuthProj.Data;
using BackEndAuthProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BackendAuthProj.Repository
{
    public class SqlInfosData : IInfoRepository
    {
        private readonly AppDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SqlInfosData(AppDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            this._db = db;
            this._httpContextAccessor = httpContextAccessor;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public GeneralInfo Create(GeneralInfo createdInfo)
        {
            var user = GetCurrentUserId();
            createdInfo.IdUserDb = user;
            _db.Infos.Add(createdInfo);
            return createdInfo;
        }

        public GeneralInfo Delete(int id)
        {
            var info = GetElementById(id);
            if (info != null) {
                _db.Infos.Remove(info);
            }
            return info;
        }

        public GeneralInfo Update(GeneralInfo updatedInfo)
        {
            var entity = _db.Infos.Attach(updatedInfo);
            entity.State = EntityState.Modified;
            return updatedInfo;
        }

        public string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public GeneralInfo GetElementById(int id)
        {
            return _db.Infos.Find(id);
        }

        public IEnumerable<GeneralInfo> GetElementByLocation(string location)
        {
            var userId = GetCurrentUserId();
            var query = _db.Infos.Where(i => i.IdUserDb == userId);
            return from i in query
                   where i.Location.Contains(location) || string.IsNullOrEmpty(location)
                   orderby i.Id
                   select i;
        }
    }
}
