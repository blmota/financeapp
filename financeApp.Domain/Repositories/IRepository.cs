using financeApp.Domain.Abstractions;

namespace financeApp.Domain.Repositories;

public interface IRepository<T> where T : Entity;