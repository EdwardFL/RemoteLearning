using iQuest.BooksAndNews.Application.Publications;
using iQuest.BooksAndNews.Application.Publishers;
using System;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever a book
    /// is printed.
    ///
    /// Subscribe to the printing office and log each book that was printed.
    /// </summary>
    public class BookLover
    {
        private readonly string name;
        private readonly ILog log;

        public BookLover(string name, PrintingOffice printingOffice, ILog log)
        {
            this.name = name; 
            this.log = log ?? throw new ArgumentNullException(nameof(log));

            printingOffice.CustomBookPublished += HandleBookPublishedEvent;
            printingOffice.CustomBookPublished += HandleCustomBookPublishedEvent;
        }

        private void HandleBookPublishedEvent(Book book)
        {
            log.WriteInfo($"{name} received the following book: {book.Title}");
        }

        private void HandleCustomBookPublishedEvent(Book book)
        {
            log.WriteInfo($"{name} received the following book: {book.Title}");
        }
    }
}