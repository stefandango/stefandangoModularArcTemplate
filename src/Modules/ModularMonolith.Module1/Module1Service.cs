namespace ModularMonolith.Module1;

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
        await _module1Repository.SaveChangesAsync();
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