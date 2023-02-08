using DripChip.Core.Entities.Abstract;

namespace DripChip.Core.Interfaces;

/// <summary>
/// Data access object
/// </summary>
/// <typeparam name="T">entity type</typeparam>
/// <typeparam name="G">entity key type</typeparam>
public interface IRepository<T, G> where T : BaseEntity<G>, new()
{
    /// <summary>Is there need to automatically save all changes</summary>
    bool AutoSaveChanges { get; set; }

    /// <summary>Queryable object to access the data with LINQ</summary>
    IQueryable<T> Items { get; }

    /// <summary>
    /// Get item with given id
    /// </summary>
    /// <param name="id">item id</param>
    /// <returns>item with given id or null</returns>
    T? Get(long id);
    
    /// <summary>
    /// Get item with given id untracked (to be able update this)
    /// </summary>
    /// <param name="id">item id</param>
    /// <returns>item with given id or null</returns>
    T? GetUntracked(long id);
    
    /// <summary>
    /// Get all items
    /// </summary>
    /// <returns>all items or empty list</returns>
    List<T> GetAll();
    
    /// <summary>
    /// Get all items untracked (to be able update them)
    /// </summary>
    /// <returns>all items or empty list</returns>
    List<T> GetAllUntracked();

    /// <summary>
    /// Get items paged (to form page with specified amount of items) 
    /// </summary>
    /// <param name="from">count of items that must be skipped</param>
    /// <param name="size">count of items on the page</param>
    /// <returns>specified amount of items or empty list</returns>
    IQueryable<T> GetAllPaged(int from = 0, int size = 10) => Items.Skip(from).Take(size);

    /// <summary>
    /// Get item with given id asynchronously
    /// </summary>
    /// <param name="id">item id</param>
    /// <param name="cancel">cancellation token</param>
    /// <returns>item with given id or null</returns>
    Task<T?> GetAsync(long id, CancellationToken cancel = default);
    
    /// <summary>
    /// Get item with given id asynchronously and untracked (to be able update this)
    /// </summary>
    /// <param name="id">item id</param>
    /// <param name="cancel">cancellation token</param>
    /// <returns>item with given id or null</returns>
    Task<T?> GetUntrackedAsync(long id, CancellationToken cancel = default);
    
    /// <summary>
    /// Get all items asynchronously
    /// </summary>
    /// <returns>all items or empty list</returns>
    Task<List<T>> GetAllAsync();
    
    /// <summary>
    /// Get all items asynchronously and untracked (to be able update this)
    /// </summary>
    /// <returns>all items or empty list</returns>
    Task<List<T>> GetAllUntrackedAsync();
    
    /// <summary>
    /// Add given item
    /// </summary>
    /// <param name="item">item to add</param>
    /// <returns>added item</returns>
    T Add(T item);
    
    /// <summary>
    /// Add given item
    /// </summary>
    /// <param name="item">item to add</param>
    /// <param name="cancel">cancellation token</param>
    /// <returns>added item</returns>
    Task<T> AddAsync(T item, CancellationToken cancel = default);

    /// <summary>
    /// Update given item
    /// </summary>
    /// <param name="item">item to update</param>
    void Update(T item);
    
    /// <summary>
    /// Update given item asynchronously
    /// </summary>
    /// <param name="item">item to update</param>
    /// <param name="cancel">cancellation token</param>
    /// <returns></returns>
    Task UpdateAsync(T item, CancellationToken cancel = default);

    /// <summary>
    /// Remove item with given id
    /// </summary>
    /// <param name="id">id item that needs to be removed</param>
    /// <returns>removed item</returns>
    T? Remove(long id);
    
    /// <summary>
    /// Remove item with given id asynchronously
    /// </summary>
    /// <param name="id">id item that needs to be removed</param>
    /// <param name="cancel"></param>
    /// <returns>removed item</returns>
    Task<T?> RemoveAsync(long id, CancellationToken cancel = default);

    /// <summary>
    /// Save all changes (if auto save is disabled)
    /// </summary>
    void SaveChanges();
    
    /// <summary>
    /// Save all changes asynchronously (if auto save is disabled)
    /// </summary>
    Task SaveChangesAsync();
}