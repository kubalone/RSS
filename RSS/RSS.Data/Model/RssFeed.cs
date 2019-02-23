using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS.Data.Model
{
    public class RssFeed:BaseEntity
    {
        public int URLID { get; set; }
        public bool IsRead { get; set; }    
        public DateTime? PubDate { get; set; }
        public virtual URL URL { get; set; }
    }
}
