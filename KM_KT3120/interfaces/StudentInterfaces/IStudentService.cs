﻿using KM_KT3120.Database;
using KM_KT3120.Filters.StudentFilters;
using KM_KT3120.Models;
using Microsoft.EntityFrameworkCore;

namespace KM_KT3120.interfaces.StudentInterfaces
{
   
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsAsync(CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
        public Task<Student> GetStudentAsync(int id, CancellationToken cancellationToken);
        public Task AddStudentAsync(Student student, CancellationToken cancellationToken);
        public Task UpdateStudentAsync(Student student, CancellationToken cancellationToken);
        public Task DeleteStudentAsync(Student student, CancellationToken cancellationToken);
       
    }

    public class StudentFilterService : IStudentService
    {
        private readonly KondratevDbContext _dbContext;

        public StudentFilterService(KondratevDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Student[]> GetStudentsAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Students.ToArrayAsync();
        }
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);
           return students;

        }
        public async Task<Student> GetStudentAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Students.FindAsync(id);
        }

        public async Task AddStudentAsync(Student student, CancellationToken cancellationToken = default)
        {
            var group = await _dbContext.Groups.FindAsync(student.GroupId);
            student.Group = group;

            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Student student, CancellationToken cancellationToken = default)
        {
            var group = await _dbContext.Groups.FindAsync(student.GroupId);
            student.Group = group;

            _dbContext.Students.Update(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(Student student, CancellationToken cancellationToken = default)
        {
            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
        }
    }
}
