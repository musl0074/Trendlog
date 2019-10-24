using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcTrendlog.Models;
using Newtonsoft.Json;
using static MvcTrendlog.Models.TrendlogApiModel;

namespace MvcTrendlog.Controllers
{
    public class HomeController : Controller
    {
        private MvcTrendlogContext _myContext;

        public HomeController(MvcTrendlogContext context)
        {
            _myContext = context;
        }

        public IActionResult Index()
        {
            string responseFromServer;
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(
              "https://api.trendlog.io/V1/channels/20/feeds/p1_cnt?apikey=GUZ5VO4I39GM");
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                responseFromServer = reader.ReadToEnd();
            }

            // Close the response.  
            response.Close();

            var deserializedRootObject = JsonConvert.DeserializeObject<RootObject>(responseFromServer);
            Alarmsettings deserializedAlarmSettings = JsonConvert.DeserializeObject<Alarmsettings>(responseFromServer);
            Feed deserializedFeed = JsonConvert.DeserializeObject<Feed>(responseFromServer);
            Channel deserializedChannel = JsonConvert.DeserializeObject<Channel>(responseFromServer);

            _myContext.RootObjectModel.Add(deserializedRootObject);

            _myContext.AlarmSettingModel.Add(deserializedAlarmSettings);

            _myContext.FeedModel.Add(deserializedFeed);

            _myContext.ChannelModel.Add(deserializedChannel);

            foreach (var item in deserializedRootObject.channel.feeds[0].points)
            {
                _myContext.PointModel.Add(item);
            }

            _myContext.SaveChanges();

            var authors = _myContext.AuthorModel.ToList();

            HomeModel statisticObject = new HomeModel
            {
                GeneratedLeads = 100,
                ServerAllocations = 50,
                SubmittedTickers = 60,
                GeneratedLeases = 32,
                Authors = authors
            };
            return View(statisticObject);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
