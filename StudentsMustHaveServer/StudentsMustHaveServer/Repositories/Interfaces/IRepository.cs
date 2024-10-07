﻿using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace StudentsMustHaveServer.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task<bool> SaveChangesAsync();
    }
}
