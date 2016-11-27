using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterProject.Models
{
    public class Hashtag
    {
        public int ID { get; set; }
        public string texto { get; set; }
        public string PostID { get; set; }

        public virtual Post Posts { get; set; }
    }
}