﻿using AutoInventoryPro.Models.Interfaces.Repositorires;
using AutoInventoryPro.Models.Interfaces.Services;

namespace AutoInventoryPro.Services.Services;

public class BaseService<T>(IBaseRepository<T> repository) : IBaseService<T> where T : class
{
    private readonly IBaseRepository<T> _repository = repository;

    public async Task AddAsync(T entity) => await _repository.AddAsync(entity);

    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<T> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task UpdateAsync(T entity) => await _repository.UpdateAsync(entity);
}
