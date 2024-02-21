namespace ModularMonolith.Module1;

internal interface IModule1Service
{
    Task<List<Module1Dto>> ListModule1ItemsAsync();
    Task<Module1Dto?> GetModule1ItemAsync(Guid id);
    Task CreateModule1ItemAsync(Module1Dto module1Dto);
    Task UpdateModule1ItemNameAsync(Guid id, string name);
    Task DeleteModule1ItemAsync(Guid id);
}