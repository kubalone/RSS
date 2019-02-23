using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS.Data.Model
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
