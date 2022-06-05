using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Data
{
    public class Category
    {
        public String name { get; set; }
        public String id { get; set; }
    }

    public class SongList
    {
        public String name { get; set; }
        public String url { get; set; }
        public String id { get; set; }
        public SongItem[] songs { get; set; }
    }

    public class SongItem
    {
        public string id { get; set; }
        public string avatar { get; set; }
        public string bgImage { get; set; }
        public string coverImage { get; set; }
        public string creator { get; set; }
        public string lyric { get; set; }
        public string music { get; set; }
        public string title { get; set; }
        public string url { get; set; }

    }
}
