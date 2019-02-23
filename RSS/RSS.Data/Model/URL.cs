using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS.Data.Model
{
    public class URL: BaseEntity
    {
      
        public string Link { get; set; }
        public virtual ICollection<RssFeed> RSSFeeds { get; set; }
    }
}
