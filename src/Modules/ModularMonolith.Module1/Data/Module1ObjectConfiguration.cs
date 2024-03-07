using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModularMonolith.Module1.Data;

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

        yield return new Module1Object ( new Guid("04069dc5-c48e-4171-8828-32dd98b074b0"), "Object_1", random.Next(1, 100));
        yield return new Module1Object ( new Guid("d595a08e-4675-434a-9c74-e6d9a76d6d91"), "Object_2", random.Next(1, 100));
        yield return new Module1Object ( new Guid("61b40c33-4640-407e-8b7e-ebb69217f04c"), "Object_3", random.Next(1, 100));
    }
}