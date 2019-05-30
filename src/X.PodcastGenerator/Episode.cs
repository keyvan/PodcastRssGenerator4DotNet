using System;

namespace X.PodcastGenerator
{
    public class Episode
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Summary { get; set; }

        public string Permalink { get; set; }

        public string Duration { get; set; }

        public string Keywords { get; set; }

        public DateTime PublicationDate { get; set; }

        public bool IsExplicit { get; set; }

        public string FileUrl { get; set; }

        public int FileLength { get; set; }

        public string FileType { get; set; }
    }
}
