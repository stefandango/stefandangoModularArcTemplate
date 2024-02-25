using Microsoft.EntityFrameworkCore;

namespace ModularMonolith.Module1;


internal class EfModule1Repository : IModule1ObjectRepository
{
    private readonly Module1ObjectDbContext _dbContext;

    public EfModule1Repository(Module1ObjectDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Module1Object?> GetAsync(Guid id)
    {
        return await _dbContext.Module1Objects.FindAsync(id);
    }

    public async Task<List<Module1Object>> ListAsync()
    {
        return await _dbContext.Module1Objects.ToListAsync();
    }

    public Task CreateAsync(Module1Object module1Object)
    {
        _dbContext.AddAsync(module1Object);
        return Task.CompletedTask;
    }

    public async Task UpdateNameAsync(Guid id, string name)
    {
        var module = await _dbContext.Module1Objects.FindAsync(id);
        module!.UpdateName(name);
    }

    public Task DeleteAsync(Module1Object module1Object)
    {
        _dbContext.Remove(module1Object);
        return Task.CompletedTask;
    }

    public async  Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
internal class Module1Service : IModule1Service
{
    private readonly IModule1ObjectRepository _module1Repository;

    public Module1Service(IModule1ObjectRepository module1Repository)
    {
        _module1Repository = module1Repository;
    }

    public async Task<List<Module1Dto>> ListModule1ItemsAsync()
    {
        var items = (await _module1Repository.ListAsync()).Select(x => new Module1Dto(x.Id, x.Name, x.Value)).ToList();
        return items;
    }

    public async Task<Module1Dto?> GetModule1ItemAsync(Guid id)
    {
        var module1Object = await _module1Repository.GetAsync(id);
        return new Module1Dto(module1Object!.Id, module1Object.Name, module1Object.Value);
    }

    public async Task CreateModule1ItemAsync(Module1Dto module1Dto)
    {
        var module1Object = new Module1Object(module1Dto.Id, module1Dto.Name, module1Dto.Value);
        await _module1Repository.CreateAsync(module1Object);
        await _module1Repository.SaveChangesAsync();
    }

    public async Task UpdateModule1ItemNameAsync(Guid id, string name)
    {
        // Validate price
        var module1Object = await _module1Repository.GetAsync(id);

        await _module1Repository.UpdateNameAsync(id, name);
    }

    public async Task DeleteModule1ItemAsync(Guid id)
    {
        var module1ToDelete = await _module1Repository.GetAsync(id);
        if (module1ToDelete != null)
        {
            await _module1Repository.DeleteAsync(module1ToDelete);
            await _module1Repository.SaveChangesAsync();
        }
    }
}