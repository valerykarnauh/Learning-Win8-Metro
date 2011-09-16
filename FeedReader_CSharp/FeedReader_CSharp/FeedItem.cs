using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Syndication;

namespace FeedReader
{
    public class FeedItem
    {
        public FeedItem(ISyndicationItem item, SyndicationFormat sourceFormat)
        {
            Title = item.Title.Text;
            PubDate = item.PublishedDate.DateTime;
            Author = item.Authors[0].Name;
            Content = sourceFormat == SyndicationFormat.Atom10 ? item.Content.Text : item.Summary.Text;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Content { get; private set; }
        public DateTime PubDate { get; private set; }
    }
}
