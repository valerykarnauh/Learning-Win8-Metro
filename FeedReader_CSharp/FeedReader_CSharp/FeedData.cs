using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Syndication;

namespace FeedReader
{
    public class FeedData
    {
        public string Title { get; set; }

        private ObservableCollection<FeedItem> _items = new ObservableCollection<FeedItem>();
        
        public ObservableCollection<FeedItem> Items
        { get { return _items; } }
    
    }


}
