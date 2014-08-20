namespace Server
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.ThriftInterface;

    /// <summary>
    /// Concrete implementation of the thrift-generated LibraryService interface.
    /// </summary>
    internal class LibraryServiceHandler : LibraryService.Iface
    {
        private readonly List<BookInfo> books;

        public LibraryServiceHandler()
        {
            // Initialize with dummy data
            books = new List<BookInfo>
            {
                new BookInfo {Id = 1, Author = "Author 1", Title = "Book 1"},
                new BookInfo {Id = 2, Author = "Author 2", Title = "Book 2"},
                new BookInfo {Id = 3, Author = "Author 3", Title = "Book 3"},
            };
        }

        public List<BookInfo> GetAllBooks()
        {
            return books;
        }

        public BookInfo GetBook(int bookId)
        {
            return books.First(book => book.Id == bookId);
        }
    }
}
