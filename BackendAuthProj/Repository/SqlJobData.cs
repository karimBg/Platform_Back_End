using BackendAuthProj.Data;
using BackEndAuthProj.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BackendAuthProj.Repository
{
    public class SqlJobData : IRepositoryData
    {
        private readonly AppDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SqlJobData(AppDbContext _db, IHttpContextAccessor httpContextAccessor)
        {
            this._db = _db;
            this._httpContextAccessor = httpContextAccessor;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        // Create a New job offer.
        public Job CreateJob(Job createdJob)
        {
            var user = GetCurrentUserId();
            createdJob.IdUserDb = user;
            _db.Jobs.Add(createdJob);
            return createdJob;
        }

        // Delete an existing job offer.
        public Job DeleteJob(int id)
        {
            var job = GetJobById(id);
            if (job != null) {
                _db.Jobs.Remove(job);
            }
            return job;
        }

        /* 
         * Get all existing job offers inside the Db for a specific user.
         * Search for a specific job offer by title.
         */
        public IEnumerable<Job> GetJobByTitle(string title)
        {
            var userId = GetCurrentUserId();
            var query = _db.Jobs.Where(j => j.IdUserDb == userId);
            return from j in query
                   where j.Title.Contains(title) || string.IsNullOrEmpty(title)
                   orderby j.Title
                   select j;
        }

        // Update an existing Job Offer.
        public Job UpdateJob(Job updatedJob)
        {
            var entity = _db.Jobs.Attach(updatedJob);
            entity.State = EntityState.Modified;
            return updatedJob;
        }

        public Job GetJobById(int id)
        {
            return _db.Jobs.Find(id);
        }

        public string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
