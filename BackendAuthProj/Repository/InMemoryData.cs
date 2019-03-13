using BackEndAuthProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackendAuthProj.Repository
{
    public class InMemoryData : IRepositoryData
    {
        private readonly List<Job> _jobs;

        public InMemoryData()
        {
            _jobs = new List<Job>() {
                 new Job() {
                        Id = 1,
                        Title = "Job1",
                        Description = "First Job Description",
                        ExpirationDate = DateTime.Now,
                        Department = Department.BusinessDevelopment
                    },
                    new Job() {
                        Id = 2,
                        Title = "Job2",
                        Description = "2nd Job Description",
                        ExpirationDate = DateTime.Now
                    }
            };
        }

        public Job GetJobById(int id)
        {
            return _jobs.SingleOrDefault(j => j.Id == id);
        }

        public IEnumerable<Job> GetJobByTitle(string title)
        {
            return from j in _jobs
                   where string.IsNullOrEmpty(title) || j.Title.Contains(title)
                   orderby j.Title
                   select j;
        }

        public Job UpdateJob(Job updatedJob)
        {
            var job = _jobs.SingleOrDefault(j => j.Id == updatedJob.Id);
            if(job != null) {
                job.Title = updatedJob.Title;
                job.Description = updatedJob.Description;
                job.ExpirationDate = updatedJob.ExpirationDate;
                job.Department = updatedJob.Department;
            }
            return job;
        }

        public void CreateJob(Job createdJob)
        {
            createdJob.Id = _jobs.Max(j => j.Id) + 1;
            _jobs.Add(createdJob);
        }

        public int Commit()
        {
            return 0;
        }

        Job IRepositoryData.CreateJob(Job createdJob)
        {
            throw new NotImplementedException();
        }

        public Job DeleteJob(int id)
        {
            var job = _jobs.FirstOrDefault(j => j.Id == id);
            if(job != null) {
                _jobs.Remove(job);
            }
            return job;
        }
    }
}
