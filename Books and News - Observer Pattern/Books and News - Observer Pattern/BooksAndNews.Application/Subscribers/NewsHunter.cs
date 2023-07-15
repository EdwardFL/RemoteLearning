using iQuest.BooksAndNews.Application.Publications;
using iQuest.BooksAndNews.Application.Publishers;
using System;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever news
    /// are printed.
    ///
    /// Subscribe to the printing office and log each news that was printed.
    /// </summary>
    public class NewsHunter
    {
        private readonly string name;
        private readonly ILog log;

        public NewsHunter(string name, PrintingOffice printingOffice, ILog log)
        {
            this.name = name; 
            this.log = log ?? throw new ArgumentNullException(nameof(log));

            printingOffice.CustomNewspaperPublished += HandleCustomNewspaperPublishedEvent;
        }
        private void HandleNewspaperPublishedEvent(Newspaper newsPaper)
        {
            log.WriteInfo($"{name} received the following book: {newsPaper.Title}");
        }

        private void HandleCustomNewspaperPublishedEvent(Newspaper newsPaper)
        {
            log.WriteInfo($"{name} received the following newspaper: {newsPaper.Title}");
        }
    }
}