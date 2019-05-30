using System.Collections.Generic;

namespace X.PodcastGenerator
{
    public partial class RssGenerator
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public string HomepageUrl { get; set; }

        public string AuthorName { get; set; }

        public string AuthorEmail { get; set; }

        public string Copyright { get; set; }

        public string Language { get; set; }

        public string ImageUrl { get; set; }

        public int ImageWidth { get; set; }

        public int ImageHeight { get; set; }

        public List<string> Categories { get; set; }

        public string iTunesCategory { get; set; }

        public string iTunesSubCategory { get; set; }

        public bool IsExplicit { get; set; }

        public List<Episode> Episodes { get; set; }
    }
}
