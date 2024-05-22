using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Books;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    internal static Guid BookGuid1 = Guid.NewGuid();
    internal static Guid BookGuid2 = Guid.NewGuid();
    internal static Guid BookGuid3 = Guid.NewGuid();

    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(b => b.Title)
            .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();

        builder.Property(b => b.Author)
            .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();

        //builder.HasKey(b => b.Id);
        //builder.Property(b => b.Price);

        builder.HasData(GetSampleBookData());
    }

    private IEnumerable<Book> GetSampleBookData()
    {
        yield return new Book(BookGuid1, "The Fellowship of the Ring", "J.R.R. Tolkien", 9.99m);
        yield return new Book(BookGuid2, "The Two Towers", "J.R.R. Tolkien", 10.99m);
        yield return new Book(BookGuid3, "The Return of the King", "J.R.R. Tolkien", 11.99m);
    }
}
