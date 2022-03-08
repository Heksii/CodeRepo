using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Repo;
using System.Net;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void executeSync_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch watch = Stopwatch.StartNew();
            RunDownloadSync();

            watch.Stop();
            long elapsedTime = watch.ElapsedMilliseconds;

            Results.Text += $"Total execution time: {(double)elapsedTime / 1000} seconds";
        }

        private async void executeAsync_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch watch = Stopwatch.StartNew();
            //await RunDownloadAsync();
            await RunDownloadParallelAsync();

            watch.Stop();
            long elapsedTime = watch.ElapsedMilliseconds;

            Results.Text += $"Total execution time: {(double)elapsedTime / 1000} seconds";
        }

        private List<string> PrepData()
        {
            List<string> res = new List<string>();

            Results.Text = "";

            res.Add("https://www.yahoo.com");
            res.Add("https://www.google.com");
            res.Add("https://www.microsoft.com");
            res.Add("https://edition.cnn.com/");
            res.Add("https://www.codeproject.com");
            res.Add("https://www.stackoverflow.com");

            return res;
        }


        private void RunDownloadSync()
        {
            List<string> websites = PrepData();

            foreach(string site in websites)
            {
                WebsiteDataModel results = DownloadWebsite(site);
                ReportWebsiteInfo(results);
            }
        }

        private async Task RunDownloadAsync()
        {
            List<string> websites = PrepData();

            foreach (string site in websites)
            {
                WebsiteDataModel results = await Task.Run(() => DownloadWebsite(site));
                ReportWebsiteInfo(results);
            }
        }

        private async Task RunDownloadParallelAsync()
        {
            List<string> websites = PrepData();
            List<Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>();

            foreach (string site in websites)
            {
                tasks.Add(Task.Run(() => DownloadWebsite(site)));
            }

            var results = await Task.WhenAll(tasks);

            foreach (WebsiteDataModel site in results)
            {
                ReportWebsiteInfo(site);
            }
        }

        private WebsiteDataModel DownloadWebsite(string websiteUrl)
        {
            WebsiteDataModel res = new WebsiteDataModel();
            WebClient client = new WebClient();

            res.WebsiteUrl = websiteUrl;
            res.WebsiteData = client.DownloadString(websiteUrl);

            return res;
        }

        private void ReportWebsiteInfo(WebsiteDataModel data)
        {
            Results.Text += $"{data.WebsiteUrl} downloaded: {data.WebsiteData.Length} characters long.{ Environment.NewLine }";
        }
    }
}
