using iQuest.BooksAndNews.Application.Publications;

namespace iQuest.BooksAndNews.Application.CustomEvents
{
    public class BookPublishedEventArgs
    {
        public Book Book { get; }

        public BookPublishedEventArgs(Book book)
        {
            Book = book;
        }
    }
}