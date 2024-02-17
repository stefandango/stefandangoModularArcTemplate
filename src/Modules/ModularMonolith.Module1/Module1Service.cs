namespace ModularMonolith.Module1;

internal class Module1Service : IModule1Service
{
    public List<Module1Dto> ListModule1Items()
    {
        return [
            new Module1Dto(Guid.NewGuid(), "Module1 Item 1", new Random().Next(1, 100)),
            new Module1Dto(Guid.NewGuid(), "Module1 Item 2", new Random().Next(1, 100)),
            new Module1Dto(Guid.NewGuid(), "Module1 Item 3", new Random().Next(1, 100))
        ];
    }
}
