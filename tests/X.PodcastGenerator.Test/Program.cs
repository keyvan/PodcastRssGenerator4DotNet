using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X.PodcastGenerator;

namespace PodcastRssGenerator4DotNet.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            XmlWriterSettings settings = new XmlWriterSettings {Encoding = Encoding.UTF8};


            const string contentType = "application/rss+xml";

            var stringWriter = new StringWriter();
            var writer = XmlWriter.Create(stringWriter, settings);

            var generator = new RssGenerator();
            generator.Title = "Keyvan.FM";
            generator.SubTitle = generator.Description = "The online podcast channel of Keyvan Nayyeri.";
            generator.HomepageUrl = "http://keyvan.fm";
            generator.AuthorName = "Keyvan Nayyeri";
            generator.AuthorEmail = "i@keyvan.fm";
            generator.Language = "en-us";
            generator.Copyright = string.Format("Copyright {0} Keyvan Nayyeri. All rights reserved.", DateTime.UtcNow.Year);
            generator.ImageUrl = "http://keyvan.fm/content/images/feed-logo.png";
            generator.IsExplicit = false;
            generator.iTunesCategory = "Technology";
            generator.iTunesSubCategory = "Software How-To";

           
            
            generator.Episodes.Add(new Episode()
            {
                Title = "Introduction",
                Summary = "In this first and short episode, I introduce myself, Keyvan.FM, and the type of content that I'm going to publish on this podcast.",
                SubTitle = "In this first and short episode, I introduce myself, Keyvan.FM, and the type of content that I'm going to publish on this podcast.",
                Permalink = "http://keyvan.fm/introduction",
                FileUrl = "http://keyvan.fm/downloads/episode0001/keyvantv_0001_medium.mp3",
                FileType = "audio/mpeg",
                FileLength = 4940509,
                PublicationDate = DateTime.Parse("Tue, 13 Mar 2012 00:40:28 GMT"),
                Duration = "00:05:06",
                IsExplicit = false
            });


            generator.Generate(writer);

            Console.WriteLine(stringWriter.ToString());

            
            Console.ReadLine();
        }
    }
}