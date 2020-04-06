using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace News.Model
{
   public class BookMarkModel
    {
        public string author { get; set; }
        
       [PrimaryKey]
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public DateTime publishedAt { get; set; }
        public string content { get; set; }
    }
}
