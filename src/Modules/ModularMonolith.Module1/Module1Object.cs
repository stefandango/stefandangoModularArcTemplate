using Ardalis.GuardClauses;

namespace ModularMonolith.Module1;

internal interface IModule1ObjectRepository : IReadOnlyModule1ObjectRepository
{
    Task CreateAsync(string name, int value);
    Task UpdateNameAsync(Guid id, string name);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}

internal interface IReadOnlyModule1ObjectRepository
{
    Task<Module1Object?> GetAsync(Guid id);
    Task<List<Module1Object>> ListAsync();
}

internal class  Module1Object
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    public int Value { get; private set; }

    internal Module1Object(Guid id, string name, int value)
    {
        Id = Guard.Against.Default(id);
        Name = Guard.Against.NullOrEmpty(name);
        Value = Guard.Against.Negative(value);
    }

    internal void UpdateName(string name)
    {
        Name = Guard.Against.NullOrEmpty(name);
    }

}