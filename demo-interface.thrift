namespace * Common.ThriftInterface

struct BookInfo
{
  1: i32 Id,
  2: string Author,
  3: string Title
}

service LibraryService
{
  list<BookInfo> GetAllBooks();
  BookInfo GetBook(1: i32 bookId);
}