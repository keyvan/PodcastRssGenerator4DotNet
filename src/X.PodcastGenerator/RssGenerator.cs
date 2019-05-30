using System;
using System.Collections.Generic;
using System.Xml;

namespace X.PodcastGenerator
{
    public partial class RssGenerator
    {
        public RssGenerator()
        {
              this.Episodes = new List<Episode>();  
        }
        
        public void Generate(XmlWriter writer)
        {
            ValidatePodcastProperties();

            string itunesUri = "http://www.itunes.com/dtds/podcast-1.0.dtd";

            // Start document
            writer.WriteStartDocument();

            // Start rss
            writer.WriteStartElement("rss");
            writer.WriteAttributeString("xmlns", "itunes", null, itunesUri);
            writer.WriteAttributeString("version", "2.0");

            // Start channel
            writer.WriteStartElement("channel");

            writer.WriteElementString("title", this.Title);
            writer.WriteElementString("description", this.Description);
            writer.WriteElementString("link", this.HomepageUrl);
            writer.WriteElementString("language", this.Language);
            writer.WriteElementString("copyright", this.Copyright);
            writer.WriteElementString("lastBuildDate", DateTime.UtcNow.ToString("r"));
            writer.WriteElementString("pubDate", DateTime.UtcNow.ToString("r"));
            writer.WriteElementString("webMaster", this.AuthorEmail);

            // Start image
            writer.WriteStartElement("image");

            writer.WriteElementString("url", this.ImageUrl);
            writer.WriteElementString("title", this.Title);
            writer.WriteElementString("link", this.HomepageUrl);

            writer.WriteElementString("width", this.ImageWidth.ToString());
            writer.WriteElementString("height", this.ImageHeight.ToString());
            writer.WriteElementString("description", this.Description);


            // End image
            writer.WriteEndElement();

            // Categories
            if (this.Categories != null)
                foreach (string category in this.Categories)
                {
                    writer.WriteElementString("Category", category);
                }

            writer.WriteElementString("author", itunesUri, this.AuthorName);
            writer.WriteElementString("subtitle", itunesUri, this.SubTitle);
            writer.WriteElementString("summary", itunesUri, this.Description);

            // Start itunes:owner
            writer.WriteStartElement("owner", itunesUri);

            writer.WriteElementString("name", itunesUri, this.AuthorName);
            writer.WriteElementString("email", itunesUri, this.AuthorEmail);

            // End  itunes:owner
            writer.WriteEndElement();

            writer.WriteElementString("explicit", itunesUri, (this.IsExplicit ? "Yes" : "No"));

            // Start itunes:image
            writer.WriteStartElement("image", itunesUri);

            writer.WriteAttributeString("href", this.ImageUrl);

            // End itunes:image
            writer.WriteEndElement();

            // iTunes category
            // Start itunes:category
            writer.WriteStartElement("category", itunesUri);
            writer.WriteAttributeString("text", this.iTunesCategory);

            // Start itunes:category
            writer.WriteStartElement("category", itunesUri);
            writer.WriteAttributeString("text", this.iTunesSubCategory);
            // End itunes:category
            writer.WriteEndElement();

            // End itunes:category
            writer.WriteEndElement();

            if (this.Episodes != null)
                foreach (Episode episode in this.Episodes)
                {
                    ValidateEpisodeProperties(episode);

                    // Start podcast item
                    writer.WriteStartElement("item");

                    writer.WriteElementString("title", episode.Title);
                    writer.WriteElementString("link", episode.Permalink);
                    writer.WriteElementString("guid", episode.Permalink);
                    writer.WriteElementString("description", episode.Summary);

                    // Start enclosure 
                    writer.WriteStartElement("enclosure");

                    writer.WriteAttributeString("url", episode.FileUrl);
                    writer.WriteAttributeString("length", episode.FileLength.ToString());
                    writer.WriteAttributeString("type", episode.FileType);

                    // End enclosure
                    writer.WriteEndElement();

                    writer.WriteElementString("pubDate", episode.PublicationDate.ToString("r"));

                    writer.WriteElementString("author", itunesUri, this.AuthorName);
                    writer.WriteElementString("explicit", itunesUri, (episode.IsExplicit ? "Yes" : "No"));
                    writer.WriteElementString("subtitle", itunesUri, episode.SubTitle);
                    writer.WriteElementString("summary", itunesUri, episode.Summary);
                    writer.WriteElementString("duration", itunesUri, episode.Duration);
                    
                    if (!string.IsNullOrEmpty(episode.Keywords))
                        writer.WriteElementString("keywords", itunesUri, episode.Keywords);

                    // End podcast item
                    writer.WriteEndElement();
                }

            // End channel
            writer.WriteEndElement();

            // End rss
            writer.WriteEndElement();

            // End document
            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();
        }

        private void ValidateEpisodeProperties(Episode episode)
        {
            
        }

        private void ValidatePodcastProperties()
        {
            
        }
    }
}
