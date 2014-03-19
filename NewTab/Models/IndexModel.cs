using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewTab.Models {
    public class IndexModel {
        public List<Thumbnail> Apps { get; set; }
    }

    public class Thumbnail {
        public string Application { get; set; }
        public string Link { get; set; }
    }
}