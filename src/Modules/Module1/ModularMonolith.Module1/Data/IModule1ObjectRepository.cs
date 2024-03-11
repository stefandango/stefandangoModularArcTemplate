namespace ModularMonolith.Module1.Data;

internal interface IModule1ObjectRepository : IReadOnlyModule1ObjectRepository
{
    Task CreateAsync(Module1Object module1Object);
    Task UpdateNameAsync(Guid id, string name);
    Task UpdateValueAsync(Guid id, int value);
    Task DeleteAsync(Module1Object module1Object);
    Task SaveChangesAsync();
}

internal interface IReadOnlyModule1ObjectRepository
{
    Task<Module1Object?> GetAsync(Guid id);
    Task<List<Module1Object>> ListAsync();
}