using DripChip.Core.Entities.Abstract;
using DripChip.Core.Interfaces;
using DripChip.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DripChip.Infrastructure.Repositories;

public class EfRepository<T, G> : IRepository<T, G> where T : BaseEntity<G>, new()
{
    public bool AutoSaveChanges { get; set; } = true;

    private readonly DbContext _context;
    private readonly DbSet<T> _Set;

    public EfRepository(ApplicationContext context)
    {
        _context = context;
        _Set = context.Set<T>();
    }


    public virtual IQueryable<T> Items => _Set;

    
    public T Add(T item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        _context.Entry(item).State = EntityState.Added;
        if (AutoSaveChanges)
            _context.SaveChanges();

        return item;
    }
    
    public async Task<T> AddAsync(T item, CancellationToken cancel = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        _context.Entry(item).State = EntityState.Added;
        if (AutoSaveChanges)
            await _context.SaveChangesAsync(cancel).ConfigureAwait(false);

        return item;
    }
    
    public T? Get(long id)
    {
        return Items.SingleOrDefault(item => Equals(item.Id, id));
    }
    
    public T? GetUntracked(long id)
    {
        return Items.AsNoTracking().SingleOrDefault(item => Equals(item.Id, id));
    }
    
    public List<T> GetAll()
    {
        return Items.ToList();
    }
    
    public List<T> GetAllUntracked()
    {
        return Items.AsNoTracking().ToList();
    }
    
    public async Task<T?> GetAsync(long id, CancellationToken cancel = default)
    {
        return await Items.SingleOrDefaultAsync(item => Equals(item.Id, id), cancel).ConfigureAwait(false);
    }
    
    public async Task<T?> GetUntrackedAsync(long id, CancellationToken cancel = default)
    {
        return await Items.AsNoTracking().SingleOrDefaultAsync(item => Equals(item.Id, id), cancel).ConfigureAwait(false);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await Items.ToListAsync();
    }

    public async Task<List<T>> GetAllUntrackedAsync()
    {
        return await Items.AsNoTracking().ToListAsync();
    }

    public T? Remove(long id)
    {
        var item = Get(id);
        if (item is null) return null;

        _context.Remove(item);

        if (AutoSaveChanges)
            _context.SaveChanges();

        return item;
    }

    public async Task<T?> RemoveAsync(long id, CancellationToken cancel = default)
    {
        var item = await GetAsync(id, cancel);
        if (item is null) return null;

        _context.Remove(item);

        if (AutoSaveChanges)
            await _context.SaveChangesAsync(cancel).ConfigureAwait(false);

        return item;
    }

    public void Update(T item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        _context.Entry(item).State = EntityState.Modified;
        if (AutoSaveChanges)
            _context.SaveChanges();
    }

    public async Task UpdateAsync(T item, CancellationToken cancel = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        _context.Entry(item).State = EntityState.Modified;
        if (AutoSaveChanges)
            await _context.SaveChangesAsync(cancel).ConfigureAwait(false);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}