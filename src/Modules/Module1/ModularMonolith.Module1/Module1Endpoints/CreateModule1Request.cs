namespace ModularMonolith.Module1.Endpoints;

public class CreateModule1Request
{
    public Guid? Id { get; set; }
    public String Name { get; set; } = String.Empty;
    public int Value { get; set; }
}
