using System.Linq.Expressions;
using TicketManagementSystem_Capstone.Data;
using TicketManagementSystem_Capstone.Repository.Interfaces;

namespace TicketManagementSystem_Capstone.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DuraTechDbContext _dbContext;

    public Repository(DuraTechDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(T entity)
    {
        _dbContext.Add(entity);
    }

    public void Delete(T entity)
    {
        _dbContext.Remove(entity);
        // Wont work until save changes is called. Its getting the ticket so no need to delete. TEst later
    }

    public IEnumerable<T> FindAll()
    {
        return _dbContext.Set<T>();
    }

    public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
    {
        return _dbContext.Set<T>().Where(predicate).ToList();
    }

    public T GetById(int id)
    {
        return _dbContext.Set<T>().Find(id);
    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }
}
