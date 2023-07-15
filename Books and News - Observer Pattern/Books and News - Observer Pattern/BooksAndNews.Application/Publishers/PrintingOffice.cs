using iQuest.BooksAndNews.Application.DataAccess;
using iQuest.BooksAndNews.Application.Delegates;
using iQuest.BooksAndNews.Application.Publications;
using System;
using iQuest.BooksAndNews.Application.CustomEvents;

namespace iQuest.BooksAndNews.Application.Publishers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is the class that will publish books and newspapers.
    /// It must offer a mechanism through which different other classes can subscribe ether
    /// to books or to newspaper.
    /// When a book or newspaper is published, the PrintingOffice must notify all the corresponding
    /// subscribers.
    /// </summary>
    ///

    public class PrintingOffice
    {
        public event BookPublishedEventHandler CustomBookPublished;
        public event NewspaperPublishedEventHandler CustomNewspaperPublished;

        public event EventHandler<BookPublishedEventArgs> BookPublished;
        public event EventHandler<NewspaperPublishedEventArgs> NewspaperPublished;

        private readonly IBookRepository bookRepository;
        private readonly INewspaperRepository newspaperRepository;
        private readonly ILog log;

        public PrintingOffice(IBookRepository bookRepository, INewspaperRepository newspaperRepository, ILog log)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            this.newspaperRepository = newspaperRepository ?? throw new ArgumentNullException(nameof(newspaperRepository));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void PrintRandom(int bookCount, int newspaperCount)
        {
            for (int i = 0; i < bookCount; i++)
            {
                Book book = bookRepository.GetRandom();
                log.WriteInfo($"{book.Title} book was published!");
                OnBookPublishedEvent(book);
                log.WriteInfo($"{book.Title} book was published! (Using custom event handler)");
                OnCustomBookPublishedEvent(book);
            }

            for (int i = 0; i <= newspaperCount; i++)
            {
                Newspaper newspaper = newspaperRepository.GetRandom();
                log.WriteInfo($"{newspaper.Title} newspaper was published!");
                OnNewspaperPublishedEvent(newspaper);
                log.WriteInfo($"{newspaper.Title} newspaper was published! (Using custom event handler)");
                OnCustomNewspaperPublishedEvent(newspaper);
            }
        }

        protected virtual void OnBookPublishedEvent(Book book)
        {
            EventHandler<BookPublishedEventArgs> bookPublishedEvent = BookPublished;
            bookPublishedEvent?.Invoke(this, new BookPublishedEventArgs(book));
        }

        protected virtual void OnCustomBookPublishedEvent(Book book)
        {
            BookPublishedEventHandler bookPublishedEvent = CustomBookPublished;
            bookPublishedEvent?.Invoke(book);
        }

        protected virtual void OnNewspaperPublishedEvent(Newspaper newspaper)
        {
            EventHandler<NewspaperPublishedEventArgs> newspaperPublishedEvent = NewspaperPublished;
            newspaperPublishedEvent?.Invoke(this, new NewspaperPublishedEventArgs(newspaper));
        }

        protected virtual void OnCustomNewspaperPublishedEvent(Newspaper newspaper)
        {
            NewspaperPublishedEventHandler newspaperPublishedEvent = CustomNewspaperPublished;
            newspaperPublishedEvent?.Invoke(newspaper);
        }
    }
}