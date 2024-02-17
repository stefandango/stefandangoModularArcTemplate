using Ardalis.GuardClauses;

namespace ModularMonolith.Module1;

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
