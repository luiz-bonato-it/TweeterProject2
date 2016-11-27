using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterProject.Models
{
    public class PostHashtag
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public int HashtagID { get; set; }

        public virtual Hashtag Hashtags {get; set;}
        public virtual Post Posts {get;set;}
    }
}