using System.Linq.Expressions;

namespace TicketManagementSystem_Capstone.Repository.Interfaces
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Adds Entity of type T
        /// </summary>
        /// <param name="entity">The entity used</param>
        public void Add(T entity);

        /// <summary>
        /// Gets all rows from DB of type T
        /// </summary>
        /// <returns>IEnumerable of type T</returns>
        /// 
        public IEnumerable<T> FindAll();
        /// <summary>
        /// Is used to find an Entity of type T by expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>IEnumerable of type T that matches expression</returns>
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Gets entity of type T by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity returned by id.</returns>
        public T GetById(int id);
        /// <summary>
        /// Updates Entity of Type T.
        /// </summary>
        /// <param name="entity">entity to update.</param>
        public void Update(T entity);
        /// <summary>
        /// Deletes Entity of type T
        /// </summary>
        /// <param name="entity">Entity to delete.</param>
        public void Delete(T entity);

    }
}
