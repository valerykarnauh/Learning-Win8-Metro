using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.Web.Syndication;

namespace FeedReader
{
    partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetFeedAsync("http://windowsteamblog.com/windows/b/developers/atom.aspx");
        }

        private void ItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeedItem feedItem = (sender as ListView).SelectedItem as FeedItem;
            if (feedItem != null)
                ContentView.NavigateToString(feedItem.Content);
        }

        private async Task GetFeedAsync(string feedUriString)
        {
            var client = new SyndicationClient();
            Uri feedUri = new Uri(feedUriString);

            try
            {
                SyndicationFeed feed = await client.RetrieveFeedAsync(feedUri);
                var feedData = new FeedData();
                feedData.Title = feed.Title.Text;

                foreach (var item in feed.Items)
                {
                    feedData.Items.Add(new FeedItem(item, feed.SourceFormat));
                }
                DataContext = feedData;
                ItemListView.SelectedIndex = 0;
            }
            catch (Exception exception)
            {
                TitleText.Text = exception.ToString();
            }

        }
    }
}
