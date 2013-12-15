using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsHelper.Structures
{
    public class Index
    {
        public string IndexNumber { get; set; }
        public List<IndexRow> IndexRows { get; private set; }
        public string Group { get; set; }

        public Index()
        {
            IndexRows = new List<IndexRow>();
        }

        public void addIndexRow(IndexRow i)
        {
            IndexRows.Add(i);
        }

    }
}
