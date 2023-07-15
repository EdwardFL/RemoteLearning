using iQuest.BooksAndNews.Application.Publications;

namespace iQuest.BooksAndNews.Application.CustomEvents
{
    public class NewspaperPublishedEventArgs
    {
        public Newspaper Newspaper { get; }

        public NewspaperPublishedEventArgs(Newspaper newspaper)
        {
            Newspaper = newspaper;
        }
    }
}