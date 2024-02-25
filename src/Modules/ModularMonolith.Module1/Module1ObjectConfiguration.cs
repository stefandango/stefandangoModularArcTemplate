using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModularMonolith.Module1;

internal class Module1ObjectConfiguration : IEntityTypeConfiguration<Module1Object>
{
    public void Configure(EntityTypeBuilder<Module1Object> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH).IsRequired();
        builder.HasData(GetSeedData());
    }
    private IEnumerable<Module1Object> GetSeedData()
    {
        Random random = new Random();
        yield return new Module1Object ( Guid.NewGuid(), "Object_1", random.Next(1, 100));
        yield return new Module1Object ( Guid.NewGuid(), "Object_2", random.Next(1, 100));
        yield return new Module1Object ( Guid.NewGuid(), "Object_3", random.Next(1, 100));
    }
}