
namespace RiverBooks.Books;


internal class BookService : IBookService
{ 
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task CreateBookAsync(BookDto book)
    {
        await _bookRepository.AddAsync(new Book(book.Id, book.Title, book.Author, book.Price));
        await _bookRepository.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(Guid id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book is not null)
        {
            await _bookRepository.DeleteAsync(book);
            await _bookRepository.SaveChangesAsync();
        }
    }

    public async Task<BookDto> GetBookByIdAsync(Guid id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        //TODO: Handle null book
        return new BookDto(book!.Id, book.Title, book.Author, book.Price);
    }

    public async Task<List<BookDto>> ListBooksAsync()
    {
        return (await _bookRepository.GetAllAsync())
        .Select(book => new BookDto(book.Id, book.Title, book.Author, book.Price))
            .ToList();
    }

    public async Task UpdateBookPriceAsync(Guid id, decimal newPrice)
    {
        //TODO:Validate newPrice
        var book = await _bookRepository.GetByIdAsync(id);

        //TODO: Handle null book
        book!.UpdatePrice(newPrice);
        await _bookRepository.SaveChangesAsync();
    }
}
