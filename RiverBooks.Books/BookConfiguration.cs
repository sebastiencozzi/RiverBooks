using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RiverBooks.Books.Data;

namespace RiverBooks.Books;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
  private readonly Guid _book1Id = new Guid("733ba805-73cc-4f9c-9c23-2cd0e549b3f3");
  private readonly Guid _book2Id = new Guid("19fce2dd-7e7a-49aa-8e73-f1780286a9e5");
  private readonly Guid _book3Id = new Guid("f1b9b9f7-f300-48ef-b3b1-826211e3c319");

  public void Configure(EntityTypeBuilder<Book> builder)
  {
    builder.Property(x => x.Title)
      .HasMaxLength(DataSchemaConstant.DEFAULT_NAME_LENGTH)
      .IsRequired();
    builder.Property(x => x.Author)
      .HasMaxLength(DataSchemaConstant.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.HasData(GetSampleBookData());
  }

  private IEnumerable<Book> GetSampleBookData()
  {
    var author = "Jrr Tolkien";
    yield return new Book(_book1Id, "book1", "Description book 1", author, .99m);
    yield return new Book(_book2Id, "book2", "Description book 1", author, 1.99m);
    yield return new Book(_book3Id, "book3", "Description book 1", author, 2.99m);

  }
}
